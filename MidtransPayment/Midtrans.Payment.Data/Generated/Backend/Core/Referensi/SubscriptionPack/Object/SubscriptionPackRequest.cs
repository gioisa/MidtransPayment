//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Midtrans.Payment.Core.Request
{
    public partial class SubscriptionPackRequest
    {
		[Required]
		public int DurationHour{ get; set; }
		[Required]
		public Guid IdSubscription{ get; set; }
		[Required]
		public bool IsAdditionalService{ get; set; }
		[Required]
		public string SubscriptionPackName{ get; set; }

    }
}
