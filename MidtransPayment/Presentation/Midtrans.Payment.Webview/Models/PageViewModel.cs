using Midtrans.Payment.Shared.Attributes;

namespace Midtrans.Payment.Webview.Models
{
	#region Page Model
	public class PageObject
	{
		public int Id { get; set; }
		public bool Active { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
		public string Kode { get; set; }
		public string Nama { get; set; }
		public string Navigation { get; set; }
		public int Sort { get; set; }
		public string UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
		public List<PageAdditionalObjectt> Additional { get; set; }
	}
	public class PageAdditionalObjectt
	{
		public int Id { get; set; }
		public string Kode { get; set; }
		public string Nama { get; set; }
		public string Navigation { get; set; }
	}
	public class PageModel : PageObject
	{
		public List<PageObject> Childs { get; set; }
	}
	public class ModulModel
	{
		public string ModulName { get; set; }
		public List<PageModel> Pages { get; set; }
	}
	#endregion

	#region Page Role Model
	public class RolePageModel
	{
		public Guid Id { get; set; }
		public int IdPage { get; set; }
		public int IdRole { get; set; }
		public ReferensiObject Modul { get; set; }
		public PageModel Page { get; set; }
		public ReferensiObject Role { get; set; }
	}
	#endregion

	#region Page Model
	public class PageViewModel
	{
		public int IdRole { get; set; }
		public List<ModulModel> Pages { get; set; }
	}
	#endregion


	#region Permission

	public class PermissionModel
	{
		public Guid Id { get; set; }
		public ReferensiObject Permission { get; set; }
		public ReferensiObject Role { get; set; }
	}
	#endregion
}
