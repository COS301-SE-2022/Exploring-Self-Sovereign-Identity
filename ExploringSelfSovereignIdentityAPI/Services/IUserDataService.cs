using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System.Threading.Tasks;



namespace ExploringSelfSovereignIdentityAPI.Services.UserDataService
{

    public interface IUserDataService
    {

        Task<UserDataModel> GetUser(UserDataModel e);

        Task<UserDataModel> GetUserData(UserDataModel e);

        Task<UserDataModel> UpdateUserData(UserDataModel e);

        Task<UserDataModel> Add(UserDataModel e);
    }
}
