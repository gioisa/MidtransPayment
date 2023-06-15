using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Midtrans.Payment.Data.Model 
{
    public partial class MstMidtransResponseTransaction : IEntity
    {
        public Guid Id { get; set; }
        public string Acquirer { get; set; }
        public string ApprovalCode { get; set; }
        public string Bank { get; set; }
        public string BillKey { get; set; }
        public string BillerCode { get; set; }
        public string CardType { get; set; }
        public string ChannelResponseCode { get; set; }
        public string ChannelResponseMessage { get; set; }
        public string Currency { get; set; }
        public string Eci { get; set; }
        public DateTime? ExpiryTime { get; set; }
        public string FraudStatus { get; set; }
        public string GrossAmount { get; set; }
        public string Issuer { get; set; }
        public string MaskedCard { get; set; }
        public string MerchantId { get; set; }
        public string OrderId { get; set; }
        public DateTime? PaidAt { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentCode { get; set; }
        public string PaymentType { get; set; }
        public DateTime? SettlementTime { get; set; }
        public string SignatureKey { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Store { get; set; }
        public string TransactionId { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionTime { get; set; }
        public string TransactionType { get; set; }
        public string VaNumber { get; set; }
    }
}
