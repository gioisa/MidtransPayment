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
    public partial class SubscriptionResponse: IMapResponse<SubscriptionResponse, Midtrans.Payment.Data.Model.TrsSubscription>
    {
		public Guid Id{ get; set; }
		public int DurationOfUse{ get; set; }
		public Guid? IdGuest{ get; set; }
		public Guid IdSubscription{ get; set; }
		public Guid? IdUser{ get; set; }
		public string PaymentMethod{ get; set; }
		public string PaymentStatus{ get; set; }
		public DateTime ScheduledDate{ get; set; }
		public System.TimeSpan ScheduledHours{ get; set; }
		public DateTime TransactionDate{ get; set; }


        public void Mapping(IMappingExpression<Midtrans.Payment.Data.Model.TrsSubscription, SubscriptionResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

