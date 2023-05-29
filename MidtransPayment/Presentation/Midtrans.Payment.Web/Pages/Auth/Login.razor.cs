using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.ComponentModel.DataAnnotations;
using Midtrans.Payment.Web.Helpers;
using Midtrans.Payment.Web.Services.User;

namespace Midtrans.Payment.Web.Pages.Auth
{
    public class LoginFormModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }


    public partial class Login : ComponentBase
    {
        #region Override
        protected override async Task OnInitializedAsync()
        {
            var auth = await _AuthStateProvider.GetAuthenticationStateAsync();

            if (auth != null && auth.User.Claims.Any())
                _NavManager.NavigateTo("/", true);

            await base.OnInitializedAsync();
        }
        #endregion

        #region Inject
        [Inject]
        private NavigationManager _NavManager { get; set; }
        [Inject]
        private AuthenticationStateProvider _AuthStateProvider { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        #endregion

        #region Field
        private bool _IsLoading = false;
        private bool _IsError = false;
        private string _MessageError = string.Empty;
        private LoginFormModel _LoginFormModel = new LoginFormModel();
        #endregion

        #region Method
        private async Task DoLogin()
        {
            _IsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _UserService.Login(new LoginRequest
                {
                    Username = _LoginFormModel.Username,
                    Password = _LoginFormModel.Password
                });

                if (res.Succeeded)
                {
                    var customAuthStateProvider = (CustomAuthStateProvider)_AuthStateProvider;
                    await customAuthStateProvider.UpdateAuthenticationState(res.Data.RawToken);
                    _NavManager.NavigateTo("/", true);
                }
                else
                {
                    _IsError = true;
                    _MessageError = res.GetErrorMessage();
                }
            }
            catch (Exception ex)
            {
                _IsError = true;
                _MessageError = ex.ToString();
            }

            _IsLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
