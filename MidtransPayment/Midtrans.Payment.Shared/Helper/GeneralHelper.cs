﻿using Midtrans.Payment.Shared.Interface;
using DocumentFormat.OpenXml;
using Newtonsoft.Json;
using System.Text;

namespace Midtrans.Payment.Shared.Helper
{
    public class GeneralHelper : IGeneralHelper
    {
        public GeneralHelper()
        {
        }

        #region PasswordEncrypt
        public string PasswordEncrypt(string text)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +
            }
        }
        #endregion

        #region Validate Password
        public bool ValidatePassword(string password)
        {
            if (password.Length >= 8 &&
                password.Any(char.IsUpper) &&
                (password.Any(char.IsSymbol) || password.Any(char.IsPunctuation)) &&
                password.Any(char.IsNumber))
                return true;
            else
                return false;

        }
        #endregion

        #region Clone
        public T Clone<T>(T obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }));
        }
        #endregion

        #region Encode Header Basic Auth
        public string EncodeBasicAuth(string toEncode)
        {
            byte[] bytes = Encoding.GetEncoding(28591).GetBytes(toEncode);
            string toReturn = System.Convert.ToBase64String(bytes);
            return toReturn;
        }
        #endregion
    }
}
