//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Midtrans.Payment.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Midtrans.Payment.Data.Model;

namespace Midtrans.Payment.Core.Response
{
    public partial class MidtransResponseTransactionResponse: IMapResponse<MidtransResponseTransactionResponse, Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction>
    {
		public string Acquirer{ get; set; }
		public string ApprovalCode{ get; set; }
		public string Bank{ get; set; }
		public string BillKey{ get; set; }
		public string BillerCode{ get; set; }
		public string CardType{ get; set; }
		public string ChannelResponseCode{ get; set; }
		public string ChannelResponseMessage{ get; set; }
		public string Currency{ get; set; }
		public string Eci{ get; set; }
		public DateTime? ExpiryTime{ get; set; }
		public string FraudStatus{ get; set; }
		public string GrossAmount{ get; set; }
		public Guid Id{ get; set; }
		public string Issuer{ get; set; }
		public string MaskedCard{ get; set; }
		public string MerchantId{ get; set; }
		public string OrderId{ get; set; }
		public DateTime? PaidAt{ get; set; }
		public string PaymentAmount{ get; set; }
		public string PaymentCode{ get; set; }
		public string PaymentType{ get; set; }
		public DateTime? SettlementTime{ get; set; }
		public string SignatureKey{ get; set; }
		public string StatusCode{ get; set; }
		public string StatusMessage{ get; set; }
		public string Store{ get; set; }
		public string TransactionStatus{ get; set; }
		public DateTime TransactionTime{ get; set; }
		public string TransactionType{ get; set; }
		public string VaNumber{ get; set; }


        public void Mapping(IMappingExpression<Midtrans.Payment.Data.Model.TrsMidtransResponseTransaction, MidtransResponseTransactionResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

