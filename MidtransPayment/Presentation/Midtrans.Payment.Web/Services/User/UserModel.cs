using Midtrans.Payment.Shared.Attributes;

namespace Midtrans.Payment.Web.Services.User
{
    #region Request
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterRequest
    {
        public string Fullname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    #endregion

    #region Response
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastSynchronize { get; set; }
        public string Status { get; set; }
    }

    public class UserDetailResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }
        public string Token { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public int AccessFailedCount { get; set; }
        public List<ReferensiStringObject> Roles { get; set; }
        public DateTime LastSynchronize { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    #endregion
}
