using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace Midtrans.Payment.Web.Helpers
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _LocalStorageService;

        public CustomAuthStateProvider(ILocalStorageService localStorageService)
        {
            _LocalStorageService = localStorageService;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();

            try
            {
                var token = await _LocalStorageService.GetItemAsStringAsync("Token");
                if (string.IsNullOrEmpty(token))
                    return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));

                identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
                identity.AddClaim(new Claim("raw_token", token));

                string exp = identity.Claims.FirstOrDefault(d => d.Type == "exp")?.Value;
                DateTime expiredDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp)).UtcDateTime;
                if (expiredDate <= DateTime.Now)
                {
                    identity = new ClaimsIdentity();
                    await _LocalStorageService.ClearAsync();
                }

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));

            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
            }
        }

        public async Task UpdateAuthenticationState(string token)
        {
            ClaimsPrincipal claimsPrincipal;

            if (!string.IsNullOrEmpty(token))
            {
                await _LocalStorageService.SetItemAsStringAsync("Token", token);
                var identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
                claimsPrincipal = new ClaimsPrincipal(identity);
            }
            else
            {
                await _LocalStorageService.ClearAsync();
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
