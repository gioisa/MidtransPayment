using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Midtrans.Payment.Data.Model 
{
    public partial class MstGuest : IEntity
    {
        public MstGuest()
        {
            TrsSubscription = new HashSet<TrsSubscription>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<TrsSubscription> TrsSubscription { get; set; }
    }
}
