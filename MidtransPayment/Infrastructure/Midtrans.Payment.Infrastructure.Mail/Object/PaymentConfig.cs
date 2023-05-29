using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midtrans.Payment.Infrastructure.Mail.Object
{
    public class PaymentConfig
    {
        public DataPayment transaction_details { get; set; }
    }

    public class DataPayment
    {
        public string order_id { get; set; }
        public decimal gross_amount { get; set; }
    }

    public class PaymentResponse
    {
        public string token { get; set; }
        public string redirect_url { get; set; }
    }

    public class PaymentStatusResponse
    {
        public string transaction_time { get; set; }
        public string gross_amount { get; set; }
        public string currency { get; set; }
        public string order_id { get; set; }
        public string payment_type { get; set; }
        public string signature_key { get; set; }
        public string status_code { get; set; }
        public string transaction_id { get; set; }
        public string transaction_status { get; set; }
        public string fraud_status { get; set; }
        public string expiry_time { get; set; }
        public string status_message { get; set; }
        public string merchant_id { get; set; }
        public string acquirer { get; set; }
    }
}
