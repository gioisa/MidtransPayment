//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Midtrans.Payment.Data;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Core.Helper;
using Midtrans.Payment.Core.Request;
using Midtrans.Payment.Core.MidtransResponseTransaction.Object;
using Midtrans.Payment.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Midtrans.Payment.Core.MidtransResponseTransaction.Command
{

    #region Request
    public class AddPaymentMidtransResponseTransactionMapping : Profile
    {
        public AddPaymentMidtransResponseTransactionMapping()
        {
            CreateMap<PaymentMidtransTransactionRequest, PaymentTransactionRequest>().ReverseMap();
        }
    }
    public class PaymentMidtransTransactionRequest : PaymentTransactionRequest,IRequest<StatusResponse>
    {
    }
    #endregion

    internal class PaymentMidtransTransactionHandler : IRequestHandler<PaymentMidtransTransactionRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public PaymentMidtransTransactionHandler(
            ILogger<PaymentMidtransTransactionHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(PaymentMidtransTransactionRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var check_payment_statyus = await _context.Entity<TrsMidtransResponseTransaction>()
                    .Where(x => x.PaymentType == request.payment_type).Where(x => x.OrderId == request.order_id)
                    .Where(x => x.MerchantId == request.merchant_id).FirstOrDefaultAsync();

                if(check_payment_statyus == null)
                {
                    #region Add Data
                    Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction data_payment = new();
                    data_payment.Issuer = request.issuer;

                    DateTime transaction_time = DateTime.Now;
                    if (DateTime.TryParse(request.transaction_time, out transaction_time))
                        data_payment.TransactionTime = transaction_time;

                    data_payment.TransactionStatus = request.transaction_status;
                    data_payment.TransactionId = request.transaction_id;
                    data_payment.StatusMessage = request.status_message;
                    data_payment.StatusCode = request.status_code;
                    data_payment.SignatureKey = request.signature_key;
                    data_payment.PaymentType = request.payment_type;
                    data_payment.OrderId = request.order_id;
                    data_payment.MerchantId = request.merchant_id;
                    data_payment.MaskedCard = request.masked_card;
                    data_payment.GrossAmount = request.gross_amount;
                    data_payment.FraudStatus = request.fraud_status;
                    data_payment.Eci = request.eci;
                    data_payment.TransactionType = request.transaction_type;

                    DateTime settlement_time = DateTime.Now;
                    if (DateTime.TryParse(request.transaction_time, out settlement_time))
                        data_payment.SettlementTime = settlement_time;

                    data_payment.Currency = request.currency;
                    data_payment.Acquirer = request.acquirer;
                    data_payment.ChannelResponseMessage = request.channel_response_message;
                    data_payment.ChannelResponseCode = request.channel_response_code;
                    data_payment.CardType = request.card_type;
                    data_payment.Bank = request.bank;
                    data_payment.ApprovalCode = request.approval_code;

                    if (!string.IsNullOrEmpty(request.permata_va_number))
                    {
                        data_payment.VaNumber = request.permata_va_number;
                        data_payment.Bank = "permata";
                    }


                    if (request.va_numbers.Count > 0)
                    {
                        var data_va = request.va_numbers.FirstOrDefault();
                        data_payment.VaNumber = data_va.va_number;
                        data_payment.Bank = data_va.bank;
                    }

                    if (request.payment_amounts.Count > 0)
                    {
                        var payment = request.payment_amounts.FirstOrDefault();
                        data_payment.PaymentAmount = payment.amount;

                        DateTime paid_at = DateTime.Now;
                        if (DateTime.TryParse(request.transaction_time, out paid_at))
                            data_payment.PaidAt = paid_at;
                        else
                            data_payment.PaidAt = null;
                    }

                    data_payment.BillerCode = request.biller_code;
                    data_payment.BillKey = request.bill_key;
                    data_payment.Store = request.store;
                    data_payment.PaymentCode = request.payment_code;

                    DateTime expiry_time = DateTime.Now;
                    if (DateTime.TryParse(request.transaction_time, out expiry_time))
                        data_payment.ExpiryTime = expiry_time;
                    else
                        data_payment.ExpiryTime = null;


                    var add = await _context.AddSave(data_payment);
                    if (add.Success)
                        result.OK();
                    else
                        result.BadRequest(add.Message);
                    #endregion
                } else
                {

                    check_payment_statyus.Issuer = request.issuer;

                    DateTime transaction_time = DateTime.Now;
                    if (DateTime.TryParse(request.transaction_time, out transaction_time))
                        check_payment_statyus.TransactionTime = transaction_time;

                    check_payment_statyus.TransactionStatus = request.transaction_status;
                    check_payment_statyus.TransactionId = request.transaction_id;
                    check_payment_statyus.StatusMessage = request.status_message;
                    check_payment_statyus.StatusCode = request.status_code;
                    check_payment_statyus.SignatureKey = request.signature_key;
                    check_payment_statyus.PaymentType = request.payment_type;
                    check_payment_statyus.OrderId = request.order_id;
                    check_payment_statyus.MerchantId = request.merchant_id;
                    check_payment_statyus.MaskedCard = request.masked_card;
                    check_payment_statyus.GrossAmount = request.gross_amount;
                    check_payment_statyus.FraudStatus = request.fraud_status;
                    check_payment_statyus.Eci = request.eci;
                    check_payment_statyus.TransactionType = request.transaction_type;

                    DateTime settlement_time = DateTime.Now;
                    if (DateTime.TryParse(request.transaction_time, out settlement_time))
                        check_payment_statyus.SettlementTime = settlement_time;

                    check_payment_statyus.Currency = request.currency;
                    check_payment_statyus.Acquirer = request.acquirer;
                    check_payment_statyus.ChannelResponseMessage = request.channel_response_message;
                    check_payment_statyus.ChannelResponseCode = request.channel_response_code;
                    check_payment_statyus.CardType = request.card_type;
                    check_payment_statyus.Bank = request.bank;
                    check_payment_statyus.ApprovalCode = request.approval_code;

                    if (!string.IsNullOrEmpty(request.permata_va_number))
                    {
                        check_payment_statyus.VaNumber = request.permata_va_number;
                        check_payment_statyus.Bank = "permata";
                    }


                    if (request.va_numbers.Count > 0)
                    {
                        var data_va = request.va_numbers.FirstOrDefault();
                        check_payment_statyus.VaNumber = data_va.va_number;
                        check_payment_statyus.Bank = data_va.bank;
                    }

                    if (request.payment_amounts.Count > 0)
                    {
                        var payment = request.payment_amounts.FirstOrDefault();
                        check_payment_statyus.PaymentAmount = payment.amount;

                        DateTime paid_at = DateTime.Now;
                        if (DateTime.TryParse(request.transaction_time, out paid_at))
                            check_payment_statyus.PaidAt = paid_at;
                        else
                            check_payment_statyus.PaidAt = null;
                    }

                    check_payment_statyus.BillerCode = request.biller_code;
                    check_payment_statyus.BillKey = request.bill_key;
                    check_payment_statyus.Store = request.store;
                    check_payment_statyus.PaymentCode = request.payment_code;

                    DateTime expiry_time = DateTime.Now;
                    if (DateTime.TryParse(request.transaction_time, out expiry_time))
                        check_payment_statyus.ExpiryTime = expiry_time;
                    else
                        check_payment_statyus.ExpiryTime = null;


                    var update = await _context.UpdateSave(check_payment_statyus);
                    if (update.Success)
                    {
                        result.OK();
                    }
                    else
                    {
                        result.BadRequest(update.Message);
                    }
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add MidtransResponseTransaction", request);
                result.Error("Failed Add MidtransResponseTransaction", ex.Message);
            }
            return result;
        }
    }
}

