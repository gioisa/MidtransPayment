using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Midtrans.Payment.Web.Helpers;
using Midtrans.Payment.Web.Services.User;

namespace Midtrans.Payment.Web.Pages.Auth
{
    public partial class Logout : ComponentBase
    {
        #region Override
        protected override async Task OnInitializedAsync()
        {
            var auth = await _AuthStateProvider.GetAuthenticationStateAsync();
            if (auth != null && auth.User.Claims.Any())
            {
                var token = await _AuthorizeService.GetToken();
                var res = await _UserService.Logout(token);

                if (res.Succeeded)
                {
                    await _AuthorizeService.ClearToken();
                    _NavManager.NavigateTo("/Auth/Login", true);
                }
            }
            else
                _NavManager.NavigateTo("/Auth/Login", true);

            await base.OnInitializedAsync();
        }
        #endregion

        #region Inject
        [Inject]
        private NavigationManager _NavManager { get; set; }
        [Inject]
        private AuthenticationStateProvider _AuthStateProvider { get; set; }
        [Inject]
        private IAuthorizeService _AuthorizeService { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        #endregion
    }
}
