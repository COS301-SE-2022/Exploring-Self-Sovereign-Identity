using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository
{
    public class UserDataRepository : IUserDataRepository
    {
        public Task<UserDataModel> Add(UserDataModel e)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDataModel> GetUserData(UserDataModel e)
        {
            e.AddAttribute("Name", true);
            e.AddAttribute("Surname", false);
            e.AddAttribute("Email", true);
            e.AddAttribute("Number", false);

            return await Task.FromResult(e);
        }
    }
}
