using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midtrans.Payment.Core.MidtransResponseTransaction.Object
{ 
    public class PaymentTransactionRequest
    {
        public string transaction_time { get; set; }
        public string transaction_status { get; set; }
        public string transaction_id { get; set; }
        public string status_message { get; set; }
        public string status_code { get; set; }
        public string signature_key { get; set; }
        public string payment_type { get; set; }
        public string order_id { get; set; }
        public string merchant_id { get; set; }
        public string masked_card { get; set; }
        public string gross_amount { get; set; }
        public string fraud_status { get; set; }
        public string eci { get; set; }
        public string transaction_type { get; set; }
        public string settlement_time { get; set; }
        public string issuer { get; set; }
        public string currency { get; set; }
        public string acquirer { get; set; }
        public string channel_response_message { get; set; }
        public string channel_response_code { get; set; }
        public string card_type { get; set; }
        public string bank { get; set; }
        public string approval_code { get; set; }
        public string permata_va_number { get; set; }
        public List<VaNumber> va_numbers { get; set; }
        public List<PaymentAmount> payment_amounts { get; set; }
        public string biller_code { get; set; }
        public string bill_key { get; set; }
        public string store { get; set; }
        public string payment_code { get; set; }
        public string expiry_time { get; set; }
    }

    public class VaNumber
    {
        public string va_number { get; set; }
        public string bank { get; set; }
    }

    public class PaymentAmount
    {
        public string paid_at { get; set; }
        public string amount { get; set; }
    }
}
