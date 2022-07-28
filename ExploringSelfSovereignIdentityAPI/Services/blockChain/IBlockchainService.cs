using ExploringSelfSovereignIdentityAPI.Models;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.blockChain
{
    public interface IBlockchainService
    {
        Task<string> createUser(string id);
        Task<string> updateAttributes(string id, AttributeBC[] attributes);
        Task<string> getUserData(string id);
    }
}
