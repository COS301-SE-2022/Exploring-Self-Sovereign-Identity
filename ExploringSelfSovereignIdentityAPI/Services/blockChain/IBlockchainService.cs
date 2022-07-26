using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.blockChain
{
    public interface IBlockchainService
    {
        Task<string> createUser(string id);
    }
}
