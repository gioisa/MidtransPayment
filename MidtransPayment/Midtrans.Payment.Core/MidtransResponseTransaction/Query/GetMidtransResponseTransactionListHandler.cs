//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Midtrans.Payment.Data;
using Midtrans.Payment.Data.Model;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Core.Response;
using Midtrans.Payment.Core.Helper;

namespace Midtrans.Payment.Core.MidtransResponseTransaction.Query
{
    public class GetMidtransResponseTransactionListRequest : ListRequest,IListRequest<GetMidtransResponseTransactionListRequest>,IRequest<ListResponse<MidtransResponseTransactionResponse>>
    {
    }
    internal class GetMidtransResponseTransactionListHandler : IRequestHandler<GetMidtransResponseTransactionListRequest, ListResponse<MidtransResponseTransactionResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetMidtransResponseTransactionListHandler(
            ILogger<GetMidtransResponseTransactionListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<MidtransResponseTransactionResponse>> Handle(GetMidtransResponseTransactionListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<MidtransResponseTransactionResponse> result = new ListResponse<MidtransResponseTransactionResponse>();
            try
            {
				var query = _context.Entity<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction>().AsQueryable();

				#region Filter
				Expression<Func<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction, object>> column_sort = null;
				List<Expression<Func<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction, bool>>> where = new List<Expression<Func<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction, bool>>>();
				if (request.Filter != null && request.Filter.Count > 0)
				{
					foreach (var f in request.Filter)
					{
						var obj = ListExpression(f.Search, f.Field, true);
						if (obj.where != null)
							where.Add(obj.where);
					}
				}
				if (where != null && where.Count() > 0)
				{
					foreach (var w in where)
					{
						query = query.Where(w);
					}
				}
				if (request.Sort != null)
                {
					column_sort = ListExpression(request.Sort.Field, request.Sort.Field, false).order!;
					if(column_sort != null)
						query = request.Sort.Type == SortTypeEnum.ASC ? query.OrderBy(column_sort) : query.OrderByDescending(column_sort);
					else
						query = query.OrderBy(d=>d.Id);
				}
				#endregion

				var query_count = query;
				if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
					query = query.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value);
				var data_list = await query.ToListAsync();

				result.List = _mapper.Map<List<MidtransResponseTransactionResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List MidtransResponseTransaction", request);
                result.Error("Failed Get List MidtransResponseTransaction", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction, bool>> where, Expression<Func<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction, object>> result_order = null;
			Expression<Func<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
					case "acquirer" : 
						if(is_where){
							result_where = (d=>d.Acquirer.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Acquirer);
					break;
					case "approvalcode" : 
						if(is_where){
							result_where = (d=>d.ApprovalCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.ApprovalCode);
					break;
					case "bank" : 
						if(is_where){
							result_where = (d=>d.Bank.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Bank);
					break;
					case "billkey" : 
						if(is_where){
							result_where = (d=>d.BillKey.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BillKey);
					break;
					case "billercode" : 
						if(is_where){
							result_where = (d=>d.BillerCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BillerCode);
					break;
					case "cardtype" : 
						if(is_where){
							result_where = (d=>d.CardType.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.CardType);
					break;
					case "channelresponsecode" : 
						if(is_where){
							result_where = (d=>d.ChannelResponseCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.ChannelResponseCode);
					break;
					case "channelresponsemessage" : 
						if(is_where){
							result_where = (d=>d.ChannelResponseMessage.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.ChannelResponseMessage);
					break;
					case "currency" : 
						if(is_where){
							result_where = (d=>d.Currency.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Currency);
					break;
					case "eci" : 
						if(is_where){
							result_where = (d=>d.Eci.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Eci);
					break;
					case "expirytime" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _ExpiryTime))
								result_where = (d=>d.ExpiryTime == _ExpiryTime);
						}
						else
							result_order = (d => d.ExpiryTime);
					break;
					case "fraudstatus" : 
						if(is_where){
							result_where = (d=>d.FraudStatus.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FraudStatus);
					break;
					case "grossamount" : 
						if(is_where){
							result_where = (d=>d.GrossAmount.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.GrossAmount);
					break;
					case "id" : 
						if(is_where){
							if (Guid.TryParse(search, out var _Id))
								result_where = (d=>d.Id == _Id);
								else
								result_where = (d=>d.Id == Guid.Empty);
						}
						else
							result_order = (d => d.Id);
					break;
					case "issuer" : 
						if(is_where){
							result_where = (d=>d.Issuer.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Issuer);
					break;
					case "maskedcard" : 
						if(is_where){
							result_where = (d=>d.MaskedCard.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.MaskedCard);
					break;
					case "merchantid" : 
						if(is_where){
							result_where = (d=>d.MerchantId.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.MerchantId);
					break;
					case "orderid" : 
						if(is_where){
							result_where = (d=>d.OrderId.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.OrderId);
					break;
					case "paidat" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _PaidAt))
								result_where = (d=>d.PaidAt == _PaidAt);
						}
						else
							result_order = (d => d.PaidAt);
					break;
					case "paymentamount" : 
						if(is_where){
							result_where = (d=>d.PaymentAmount.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.PaymentAmount);
					break;
					case "paymentcode" : 
						if(is_where){
							result_where = (d=>d.PaymentCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.PaymentCode);
					break;
					case "paymenttype" : 
						if(is_where){
							result_where = (d=>d.PaymentType.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.PaymentType);
					break;
					case "settlementtime" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _SettlementTime))
								result_where = (d=>d.SettlementTime == _SettlementTime);
						}
						else
							result_order = (d => d.SettlementTime);
					break;
					case "signaturekey" : 
						if(is_where){
							result_where = (d=>d.SignatureKey.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.SignatureKey);
					break;
					case "statuscode" : 
						if(is_where){
							result_where = (d=>d.StatusCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.StatusCode);
					break;
					case "statusmessage" : 
						if(is_where){
							result_where = (d=>d.StatusMessage.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.StatusMessage);
					break;
					case "store" : 
						if(is_where){
							result_where = (d=>d.Store.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Store);
					break;
					case "transactionstatus" : 
						if(is_where){
							result_where = (d=>d.TransactionStatus.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.TransactionStatus);
					break;
					case "transactiontime" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _TransactionTime))
								result_where = (d=>d.TransactionTime == _TransactionTime);
						}
						else
							result_order = (d => d.TransactionTime);
					break;
					case "transactiontype" : 
						if(is_where){
							result_where = (d=>d.TransactionType.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.TransactionType);
					break;
					case "vanumber" : 
						if(is_where){
							result_where = (d=>d.VaNumber.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.VaNumber);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

