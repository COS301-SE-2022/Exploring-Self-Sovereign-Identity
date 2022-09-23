using ExploringSelfSovereignIdentityAPI.Models;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using Nethereum.RPC.Eth.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain
{
    public interface IUserDataService
    {
        public Task<string> createUser(string id);
        public Task<GetUserDataOutputDTO2> getUserData(string id);
        public Task<GetUserDataOutputDTO2> updateUserData( UpdateGen2 update);
        public Task<string> newTransactionRequest(TransactionRequest request);
        public Task<string> approveTransaction(string id, int index);
        public Task<string> declineTransaction(string id, int index);
    }
}
