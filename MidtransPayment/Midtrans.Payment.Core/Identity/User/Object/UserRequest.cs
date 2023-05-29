using System.ComponentModel.DataAnnotations;
using Midtrans.Payment.Shared.Attributes;

namespace Midtrans.Payment.Core.Request
{
    public class UserInfoRequest
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
