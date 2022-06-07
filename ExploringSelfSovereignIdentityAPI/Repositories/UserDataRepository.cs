using ExploringSelfSovereignIdentityAPI.Data;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly ApplicationDbContext _context;
        public UserDataModel(ApplicationDbContext context)
        {
            this._context = context;
        }
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

            await _context.UserDataModels.AddAsync(e);

            return e;
        }
    }
}
