using Microsoft.AspNetCore.Components;
using Midtrans.Payment.Web.Services.User;
using Midtrans.Payment.Web.Shared;
using Midtrans.Payment.Shared.Attributes;

namespace Midtrans.Payment.Web.Pages.User
{
    public partial class Index : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _ = GetUserItems();
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [CascadingParameter]
        private MainLayout _MainLayout { get; set; }
        [Inject]
        private IUserService _UserService { get; set; }
        #endregion

        #region Field
        private List<UserResponse> _UserItems = new List<UserResponse>();
        private bool _ItemLoading = false;
        #endregion

        #region Method
        private async Task GetUserItems()
        {
            _ItemLoading = true;
            StateHasChanged();

            try
            {
                var token = await _MainLayout._AuthorizeService.GetToken();
                var param = new ListRequest
                {
                    Start = 0,
                    Length = 0,
                    Filter = new List<FilterRequest>(),
                    Sort = new SortRequest("fullname", SortTypeEnum.ASC)
                };

                var res = await _UserService.List(param, token);

                if (res.Succeeded)
                {
                    _UserItems = res.List;
                }
                else
                {
                    Console.WriteLine(res.GetErrorMessage());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            _ItemLoading = false;
            StateHasChanged();
        }
        #endregion
    }
}
