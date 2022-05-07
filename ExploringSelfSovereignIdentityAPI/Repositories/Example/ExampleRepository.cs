using ExploringSelfSovereignIdentityAPI.Models.Example;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.Example
{
    public class ExampleRepository : IExampleRepository
    {
        public async Task Add(ExampleModel e)
        {
            await Task.FromResult("Example data");
        }

        public async Task<string> Get()
        {
            return await Task.FromResult("Example data");
        }
    }
}
