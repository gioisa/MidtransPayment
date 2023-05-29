using Midtrans.Payment.Core.Helper;
using Midtrans.Payment.Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Midtrans.Payment.Core.Request
{
    public partial class RepositoryRequest
    {
        [Required]
        public ModulType Modul { get; set; }
        [Required]
        public FileObject File { get; set; }
        [Required]
		public string Code{ get; set; }
		public string Description{ get; set; }
		[Required]
		public bool IsPublic{ get; set; }

    }
}

