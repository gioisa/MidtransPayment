using Microsoft.AspNetCore.Components;

namespace Midtrans.Payment.Web.Shared.Components
{
    public partial class Loader : ComponentBase
    {
        #region Inject, Cascading, Parameter
        [Parameter]
        public bool IsLoading { get; set; }
        #endregion
    }
}
