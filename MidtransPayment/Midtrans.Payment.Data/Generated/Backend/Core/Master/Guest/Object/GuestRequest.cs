//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Midtrans.Payment.Core.Request
{
    public partial class GuestRequest
    {
		[Required]
		public string Email{ get; set; }
		[Required]
		public string FullName{ get; set; }
		[Required]
		public string PhoneNumber{ get; set; }

    }
}

