namespace Midtrans.Payment.Shared.Interface
{
    public interface IGeneralHelper
    {
        bool ValidatePassword(string password);
        string PasswordEncrypt(string text);
        T Clone<T>(T obj);
        string EncodeBasicAuth(string toEncode);
    }
}

