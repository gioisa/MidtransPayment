using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Midtrans.Payment.Data.Model 
{
    public partial class RefSubscriptionPack : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdSubscription { get; set; }
        public string SubscriptionPackName { get; set; }
        public bool IsAdditionalService { get; set; }
        public int DurationHour { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }

        public virtual RefSubscription IdSubscriptionNavigation { get; set; }
    }
}
