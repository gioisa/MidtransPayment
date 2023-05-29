using Midtrans.Payment.Infrastructure.Mail.Object;
using Midtrans.Payment.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midtrans.Payment.Infrastructure.Mail.Interface
{
    public interface IPaymentService
    {
        Task<ObjectResponse<PaymentResponse>> PaymentMethodToMidtrans(PaymentConfig request);
        Task<ObjectResponse<PaymentStatusResponse>> PaymentCheckStatus(string request);

    }
}
