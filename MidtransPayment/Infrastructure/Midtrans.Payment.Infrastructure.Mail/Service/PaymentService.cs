using Microsoft.Extensions.Logging;
using Midtrans.Payment.Infrastructure.Mail.Interface;
using Midtrans.Payment.Infrastructure.Mail.Object;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Shared.Interface;

namespace Midtrans.Payment.Infrastructure.Mail.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly ILogger _logger;
        private readonly IHttpRequest _request;

        public PaymentService(ILogger<PaymentService> logger, IHttpRequest request)
        {
            _logger = logger;
            _request = request;
        }

        public async Task<ObjectResponse<PaymentStatusResponse>> PaymentCheckStatus(string request)
        {
            ObjectResponse<PaymentStatusResponse> result = new();
            try
            {
                var (IsSuccess, ErrorMessage, Result, ex) = await _request.DoRequestData<PaymentStatusResponse>(HttpMethod.Get, "SB-Mid-server-4g6S8xbVsr5g8iterUjrstUe:", EnumHttpRequest.Basic_Auth, "https://api.sandbox.midtrans.com/v2/"+request+"/status", null);
                if (IsSuccess)
                {
                    result.Data = Result;
                    result.OK();
                }
                else
                {
                    result.BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Payment ", ex.Message);
                result.Error("Failed Payment", ex.Message);
            }
            return result;
        }

        public async Task<ObjectResponse<PaymentResponse>> PaymentMethodToMidtrans(PaymentConfig request)
        {
            ObjectResponse<PaymentResponse> result = new();
            try
            {
                var (IsSuccess, ErrorMessage, Result, ex) = await _request.DoRequestData<PaymentResponse>(HttpMethod.Post, "SB-Mid-server-4g6S8xbVsr5g8iterUjrstUe:", EnumHttpRequest.Basic_Auth, "https://app.sandbox.midtrans.com/snap/v1/transactions", request);
                if (IsSuccess)
                {
                    result.Data = Result;
                    result.OK();
                } else
                {
                    result.BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Payment ", ex.Message);
                result.Error("Failed Payment", ex.Message);
            }
            return result;
        }
    }
}
