using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
using System.Threading.Tasks;

   
namespace ExploringSelfSovereignIdentityAPI.Services.UserDataService
{
    public class UserdataService : IUserDataService
    {
        private readonly IUserDataRepository _repo;

        public UserdataService(UserDataRepository repository)
        {
            _repo = repository;
        }
        public async Task<UserDataModel> Add(UserDataModel e)
        {
            return await _repo.Add(e);
        }

        public async Task<UserDataModel> GetUser(UserDataModel e, UserDataModel f)
        {
            return await _repo.GetUser(e, f); 
        }

        public async Task<UserDataModel> GetUserData (UserDataModel e)
        {
            return await (_repo.GetUserData(e)); 
        }

       
    }
    
}
