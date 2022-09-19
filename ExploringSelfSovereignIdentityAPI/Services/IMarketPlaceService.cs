using ExploringSelfSovereignIdentityAPI.Models.Request;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public interface IMarketPlaceService
    {
        public Task<string> createOrganization(CreateOrgRequest request);

        public Task<GetOrganizationOutputDTO> getOrganization(CreateOrgRequest request);
        public Task<string> addDataPack(AddDataPackRequest request);
        public Task<string> buyData(BuyDataRequest request);
    }
}
