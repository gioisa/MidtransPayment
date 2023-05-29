using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Midtrans.Payment.Web.Helpers;

namespace Midtrans.Payment.Web.Shared
{
    [Authorize]
    public partial class MainLayout : LayoutComponentBase
    {
        #region Override

        #endregion

        #region Inject
        [Inject]
        public NavigationManager _NavManager { get; set; }
        [Inject]
        public IAuthorizeService _AuthorizeService { get; set; }
        #endregion

        #region Field

        #endregion

        #region Method

        #endregion
    }
}
