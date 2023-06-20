using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Midtrans.Payment.Data.Model 
{
    public partial class RefSubscription : IEntity
    {
        public RefSubscription()
        {
            TrsSubscription = new HashSet<TrsSubscription>();
        }

        public Guid Id { get; set; }
        public string NameSubscription { get; set; }
        public decimal Pricing { get; set; }
        public string TypeSubscription { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }

        public virtual ICollection<TrsSubscription> TrsSubscription { get; set; }
    }
}
