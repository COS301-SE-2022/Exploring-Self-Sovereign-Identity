namespace ExploringSelfSovereignIdentityAPI.Services.Encryption
{
    public interface IEncryptionService
    {
        string EncryptString(string userID, string plainText);
        string DecryptString(string userID, string plainText);
    }
}
