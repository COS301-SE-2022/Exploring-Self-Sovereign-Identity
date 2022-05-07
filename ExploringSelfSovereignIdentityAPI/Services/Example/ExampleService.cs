using ExploringSelfSovereignIdentityAPI.Models.Example;
using ExploringSelfSovereignIdentityAPI.Repositories.Example;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.Example
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository _repo;

        public ExampleService (IExampleRepository repository)
        {
            _repo = repository;
        }
        public async Task Add(ExampleModel e)
        {
            await _repo.Add(e);
        }

        public async Task<string> Get()
        {
           return await _repo.Get();
        }
    }
}
