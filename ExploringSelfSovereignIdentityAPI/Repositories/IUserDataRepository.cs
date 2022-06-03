using ExploringSelfSovereignIdentityAPI.Models.Entity; 
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository
{
    public interface IUserDataRepository
    {
        Task<UserDataModel> GetUserData (UserDataModel e);
        Task<UserDataModel> Add(UserDataModel e);
        Task<string> Get();
    }
}
