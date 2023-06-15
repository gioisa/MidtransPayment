using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Midtrans.Payment.Core.Role.Query;
using Midtrans.Payment.Infrastructure.Mail.Interface;
using Midtrans.Payment.Infrastructure.Mail.Object;
using Midtrans.Payment.Shared.Attributes;

namespace Midtrans.Payment.API.Controllers.V1.Payment
{
    public class PaymentMethodController : BaseController<RoleController>
    {
        public readonly IPaymentService _paymentServices;

        public PaymentMethodController(IPaymentService paymentServices)
        {
            _paymentServices = paymentServices;
        }

        [AllowAnonymous]
        [HttpPost(template: "pay")]
        public async Task<ObjectResponse<PaymentResponse>> Payment(PaymentConfig request)
        {
            return await _paymentServices.PaymentMethodToMidtrans(request);
        }

        [AllowAnonymous]
        [HttpGet(template: "check_payment")]
        public async Task<ObjectResponse<PaymentStatusResponse>> CheckOrderPayment(string request)
        {
            return await _paymentServices.PaymentCheckStatus(request);
        }
    }
}
