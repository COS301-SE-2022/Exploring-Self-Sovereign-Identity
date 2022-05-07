using ExploringSelfSovereignIdentityAPI.Models.Example;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.Example
{
    public interface IExampleRepository
    {
        Task Add(ExampleModel e);
        Task<string> Get();
    }
}
