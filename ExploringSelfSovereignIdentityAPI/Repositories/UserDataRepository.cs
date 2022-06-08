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
        public UserDataRepository(ApplicationDbContext context)
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

       /* public async Task<UserDataModel> DeleteUserData(UserDataModel e)
        {
            e.DeleteAttribute("Name");
            e.DeleteAttribute("Surname");
            e.DeleteAttribute("Email");
            e.DeleteAttribute("Number");

            await _context.UserDataModels.AddAsync(e);

            return e;

        }*/

        public async Task<UserDataModel> UpdateUserData(UserDataModel e)
        {
            UserDataModel userFromDB = await _context.UserDataModels.FindAsync(e.Id); //fetch user from db 
            
            userFromDB.Profile_version = e.Profile_version; 

            await _context.SaveChangesAsync(); 

            return e;

        }
    }
}
