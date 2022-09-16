namespace ExploringSelfSovereignIdentityAPI.Services.Encryption
{
    public interface IEncryptionService
    {
        string EncryptString(string key, string plainText);
        string DecryptString(string key, string plainText);
    }
}
