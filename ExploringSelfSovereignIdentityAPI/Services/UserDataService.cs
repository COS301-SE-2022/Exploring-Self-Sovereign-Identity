using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
using System.Threading.Tasks;

   
namespace ExploringSelfSovereignIdentityAPI.Services.UserDataService
{
    public class UserdataService : IUserDataService
    {
        private readonly IUserDataRepository _repo;

        public UserdataService(IUserDataRepository repository)
        {
            _repo = repository;
        }
        public async Task<UserDataModel> Add(UserDataModel e)
        {
            return await _repo.Add(e);
        }

        public async Task<string> Get()
        {
            return await _repo.Get();
        }
    }
    
}
