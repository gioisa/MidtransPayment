//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Midtrans.Payment.Core.Request
{
    public partial class NotificationRequest
    {
		[Required]
		public string Description{ get; set; }
		[Required]
		public Guid IdUser{ get; set; }
		[Required]
		public string Navigation{ get; set; }
		[Required]
		public string Subject{ get; set; }
		[Required]
		public string UserFullname{ get; set; }
		public string UserMail{ get; set; }
		public string UserPhone{ get; set; }

    }
}

