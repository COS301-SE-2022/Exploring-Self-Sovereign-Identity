using ExploringSelfSovereignIdentityAPI.Models.Request;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services
{
    public interface IMarketPlaceService
    {
        public Task<string> createOrganization(CreateOrgRequest request);

        public Task<GetOrganizationOutputDTO2> getOrganization(CreateOrgRequest request);
        public Task<string> addDataPack(AddDataPackRequest2 request);
        public Task<BuyDataOutputDTO2> buyData(BuyDataRequest request);
        public Task<GetAllOrganizationsOutputDTO2> getAllOrganizations();
    }
}
