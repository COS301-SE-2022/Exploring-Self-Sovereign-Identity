using ExploringSelfSovereignIdentityAPI.Models.Example;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.Example
{
    public interface IExampleRepository
    {
        Task<ExampleModel> Add(ExampleModel e);
        Task<string> Get();
    }
}
