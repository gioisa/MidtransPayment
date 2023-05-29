using DocumentFormat.OpenXml.Office2016.Excel;
using Midtrans.Payment.Shared.Attributes;
using Midtrans.Payment.Shared.Interface;

namespace Midtrans.Payment.Web.Services.User
{
    public interface IUserService
    {
        Task<StatusResponse> Register(RegisterRequest request);
        Task<ObjectResponse<TokenObject>> Login(LoginRequest request);
        Task<StatusResponse> Logout(string token);
        Task<ListResponse<UserResponse>> List(ListRequest request, string token);
        Task<ObjectResponse<UserDetailResponse>> Detail(Guid id, string token);
    }

    public class UserService : IUserService
    {
        #region Fields and Constructor
        private readonly IWrapperHelper _Wrapper;
        private readonly IHttpRequest _HttpRequest;
        private string _BaseURL;
        public UserService(
            IWrapperHelper wrapper,
            IHttpRequest httpRequest,
            IConfiguration configuration)
        {
            _Wrapper = wrapper;
            _HttpRequest = httpRequest;
            _BaseURL = configuration.GetValue<string>("BaseURL");
        }
        #endregion

        public async Task<StatusResponse> Register(RegisterRequest request)
        {
            return _Wrapper.Response(await _HttpRequest.DoRequestData<StatusResponse>(HttpMethod.Post, "", $"{_BaseURL}v1/User/register", request));
        }

        public async Task<ObjectResponse<TokenObject>> Login(LoginRequest request)
        {
            return _Wrapper.Response(await _HttpRequest.DoRequestData<ObjectResponse<TokenObject>>(HttpMethod.Post, "", $"{_BaseURL}v1/User/login", request));
        }

        public async Task<StatusResponse> Logout(string token)
        {
            return _Wrapper.Response(await _HttpRequest.DoRequestData<StatusResponse>(HttpMethod.Post, token, $"{_BaseURL}v1/User/logoff", null));
        }

        public async Task<ListResponse<UserResponse>> List(ListRequest request, string token)
        {
            return _Wrapper.Response(await _HttpRequest.DoRequestData<ListResponse<UserResponse>>(HttpMethod.Post, token, $"{_BaseURL}v1/User/list", request));
        }

        public async Task<ObjectResponse<UserDetailResponse>> Detail(Guid id, string token)
        {
            return _Wrapper.Response(await _HttpRequest.DoRequestData<ObjectResponse<UserDetailResponse>>(HttpMethod.Get, token, $"{_BaseURL}v1/User/get/{id}", null));
        }
    }
}
