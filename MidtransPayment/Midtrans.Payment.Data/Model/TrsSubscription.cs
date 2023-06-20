using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Midtrans.Payment.Data.Model 
{
    public partial class TrsSubscription : IEntity
    {
        public Guid Id { get; set; }
        public Guid? IdUser { get; set; }
        public Guid? IdGuest { get; set; }
        public Guid IdSubscription { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime ScheduledDate { get; set; }
        public TimeSpan ScheduledHours { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public int DurationOfUse { get; set; }

        public virtual MstGuest IdGuestNavigation { get; set; }
        public virtual RefSubscription IdSubscriptionNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
