using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.ComponentModel.DataAnnotations;
using Midtrans.Payment.Web.Services.User;

namespace Midtrans.Payment.Web.Pages.Auth
{
    public class RegisterFormModel
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[0-9])(?=.*?[A-Z])(?=.*?[#?!@$%^&*-]).{8,15}$", ErrorMessage = "Password Must be at Least 8 Character But no More Than 15 and Contains Upper Case, Symbol and Numeric!")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
    }

    public partial class Register : ComponentBase
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
        private RegisterFormModel _RegisterFormModel = new RegisterFormModel();
        #endregion

        #region Method
        private async Task DoRegister()
        {
            _IsLoading = true;
            StateHasChanged();

            try
            {
                var res = await _UserService.Register(new RegisterRequest
                {
                    Fullname = _RegisterFormModel.Fullname,
                    Mail = _RegisterFormModel.Mail,
                    PhoneNumber = _RegisterFormModel.PhoneNumber,
                    Username = _RegisterFormModel.Username,
                    Password = _RegisterFormModel.Password
                });

                if (res.Succeeded)
                {
                    _NavManager.NavigateTo("/Auth/Login", true);
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
