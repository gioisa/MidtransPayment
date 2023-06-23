using Midtrans.Payment.Shared.Attributes;

namespace Midtrans.Payment.Webview.Helpers
{
	public class HelperClient
	{
		public const string COOKIES_API = "midtrans.homeplate.api";
		public const string COOKIES_TOKEN = "midtrans.homeplate.token";
		public static bool GetCookies(HttpRequest request)
		{
			bool auth = false;
			var token = request.Cookies[COOKIES_TOKEN];
			if (token != null)
			{
				var data_token = DecodeToken(token);
				if (data_token.Success)
				{
					if (data_token.Result.ExpiredAt >= DateTime.Now)
						auth = true;
				}
			}
			return auth;
		}
		public static (bool Success, TokenObject Result) GetToken(HttpRequest request)
		{
			var token = request.Cookies[COOKIES_TOKEN];
			if (token != null)
			{
				return DecodeToken(token);
			}
			else
				return (false, null);
		}
		public static (bool Success, TokenObject Result) DecodeToken(string token)
		{
			try
			{
				int numberChars = token.Length;
				byte[] bytes = new byte[numberChars / 2];
				for (int i = 0; i < numberChars; i += 2)
				{
					bytes[i / 2] = System.Convert.ToByte(token.Substring(i, 2), 16);
				}
				var serializedObject = System.Text.Encoding.Unicode.GetString(bytes);
				var data = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenObject>(serializedObject)!;
				return (true, data);
			}
			catch
			{
				return (false, null);
			}
		}

	}
}
