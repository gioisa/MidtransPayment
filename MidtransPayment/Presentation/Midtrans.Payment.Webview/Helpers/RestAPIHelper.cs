using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Webview.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Midtrans.Payment.Webview.Helpers
{
	public interface IRestAPIHelper
	{
		#region Identity
		Task<StatusResponse> RefreshToken(string token);
		Task<StatusResponse> Logoff(string token);
		Task<ObjectResponse<PageViewModel>> Page(int id_role);
		Task<StatusResponse> CheckId(Guid Id);
		#endregion

	}
	public class RestAPIHelper : IRestAPIHelper
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ILogger<RestAPIHelper> _logger;
		private List<PageViewModel> _pages = new List<PageViewModel>();
		private string BASE_URL = "";
		private string VERSIONING = "v1";
		public RestAPIHelper(IHttpContextAccessor httpContextAccessor, ILogger<RestAPIHelper> logger, IConfiguration configuration)
		{
			_httpContextAccessor = httpContextAccessor;
			_logger = logger;
			BASE_URL = configuration.GetValue<string>("APIBaseUrl");
		}

		#region Identity
		public async Task<StatusResponse> RefreshToken(string token)
		{
			string url = $"{BASE_URL}/{VERSIONING}/user/refresh_token";
			return await DoRequest<ObjectResponse<TokenObject>>(url, Method.POST, new { token = token }, false);
		}
		public async Task<StatusResponse> Logoff(string token)
		{
			string url = $"{BASE_URL}/{VERSIONING}/user/logoff";
			return await DoRequest<StatusResponse>(url, Method.POST, new { token = token }, false);
		}
		public async Task<StatusResponse> CheckId(Guid Id)
		{
			string url = $"{BASE_URL}/{VERSIONING}/user/list";
			return await DoRequest<StatusResponse>(url, Method.POST, new { Id = Id }, false);
		}
		#endregion

		#region Page
		public async Task<ObjectResponse<PageViewModel>> Page(int id_role)
		{
			var result = new ObjectResponse<PageViewModel>();
			string url = $"{BASE_URL}/{VERSIONING}/RolePage/list_detail";
			var list_request = new ListRequest()
			{
				Sort = new SortRequest()
				{
					Field = "Page.Sort",
					Type = SortTypeEnum.ASC
				},
				Filter = new List<FilterRequest>()
				{
					new FilterRequest()
					{
						Field = "idRole",
						Search = id_role.ToString()
					},new FilterRequest()
					{
						Field = "Page.Active",
						Search = "true"
					}
				}
			};
			if (_pages != null && _pages.Any(d => d.IdRole == id_role))
			{
				result.Data =  _pages.Where(d => d.IdRole == id_role).FirstOrDefault();
				result.OK();
			}
			else
			{
				var request = await DoRequest<ListResponse<RolePageModel>>(url, Method.POST, list_request, false);
				if (request == null || !request.Succeeded)
				{
					result.BadRequest(request.Message);
				}
				else
				{
					result.Data = new PageViewModel()
					{
						IdRole = request.List.Select(d => d.IdRole).FirstOrDefault(),
						Pages = request.List.GroupBy(d => d.Modul?.Nama).Select(d => new ModulModel()
						{
							ModulName = d.Key,
							Pages = d.Select(d => d.Page).ToList()
						}).ToList()
					};
					_pages.Add(result.Data);
					result.OK();
				}
			}
			return result;
		}
		#endregion

		#region Do Request Utility
		private async Task<T> DoRequest<T>(string url, Method method, object body, bool isAnnonymous) where T : class
		{
			try
			{
				var client = new RestClient(url);
				var request = new RestRequest(method);
				client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
				request.AddHeader("Content-Type", "application/json");
				client.Timeout = -1;
				if (body != null)
				{
					var reqBody = JsonConvert.SerializeObject(body);
					request.AddParameter("application/json",
								reqBody,
								ParameterType.RequestBody);
				}
				if (!isAnnonymous)
				{
					string token = _httpContextAccessor.HttpContext.Request.Cookies[HelperClient.COOKIES_TOKEN];
					request.AddHeader("Authorization", $"Bearer {token}");
				}
				IRestResponse response = await client.ExecuteAsync(request);
				return JsonConvert.DeserializeObject<T>(response.Content);
			}
			catch (Exception)
			{
				return null;
			}
		}
		#endregion
	}
}
