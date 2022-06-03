using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.UserDataService
{
    public interface IUserDataService
    {
        Task<string> Get();

        Task<UserDataModel> Add(UserDataModel e);
    }
}
