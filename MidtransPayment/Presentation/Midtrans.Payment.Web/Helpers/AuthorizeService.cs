using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Midtrans.Payment.Web.Helpers
{
    public interface IAuthorizeService
    {
        Task<string> GetToken();
        Task ClearToken();
    }

    public class AuthorizeService : IAuthorizeService
    {
        private readonly AuthenticationStateProvider _AuthStateProvider;
        private readonly NavigationManager _NavManager;

        public AuthorizeService(AuthenticationStateProvider authStateProvider, NavigationManager navManager)
        {
            _AuthStateProvider = authStateProvider;
            _NavManager = navManager;
        }

        public async Task<string> GetToken()
        {
            string result = string.Empty;
            var auth = await _AuthStateProvider.GetAuthenticationStateAsync();
            if (auth != null && auth.User.Claims.Any())
            {
                result = auth.User.Claims.FirstOrDefault(d => d.Type == "raw_token")?.Value ?? null;

                string exp = auth.User.Claims.FirstOrDefault(d => d.Type == "exp")?.Value;
                DateTime expiredDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp)).UtcDateTime;

                if (string.IsNullOrEmpty(result) || expiredDate <= DateTime.Now)
                    _NavManager.NavigateTo("/Auth/Login", true);
            }
            else
                _NavManager.NavigateTo("/Auth/Login", true);

            return result;
        }

        public async Task ClearToken()
        {
            var customAuthStateProvider = (CustomAuthStateProvider)_AuthStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(null);
        }
    }
}
