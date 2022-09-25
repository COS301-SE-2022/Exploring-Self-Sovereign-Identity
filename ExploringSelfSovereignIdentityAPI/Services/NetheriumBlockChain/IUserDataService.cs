using ExploringSelfSovereignIdentityAPI.Commands;
using ExploringSelfSovereignIdentityAPI.Models;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using Nethereum.RPC.Eth.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain
{
    public interface IUserDataService
    {
        public Task<string> createUser(string id);
        public Task<GetUserDataOutputDTO> getUserData(string id);
        public Task<GetUserDataOutputDTO> updateUserData( UpdateGen2 update);

        Task<string> newTransactionRequest(TransactionRequest request);
    }
}
