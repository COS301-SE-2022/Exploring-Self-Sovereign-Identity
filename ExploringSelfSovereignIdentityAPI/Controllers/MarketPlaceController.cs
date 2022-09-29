using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MarketPlaceController
    {
        private readonly IMarketPlaceService mps;

        public MarketPlaceController(IMarketPlaceService mps)
        {
            this.mps = mps;
        }

        [HttpPost]
        [Route("createOrg")]
        public async Task<string> create([FromBody] CreateOrgRequest request)
        {
            return await mps.createOrganization(request);
        }

        [HttpPost]
        [Route("getOrg")]
        public async Task<GetOrganizationOutputDTO2> get([FromBody] CreateOrgRequest request)
        {
            return await mps.getOrganization(request);
        }

        [HttpPost]
        [Route("buyData")]
        public async Task<BuyDataOutputDTO2> buy([FromBody] BuyDataRequest request)
        {
            return await mps.buyData(request);
        }

        [HttpPost]
        [Route("addData")]
        public async Task<string> add([FromBody] AddDataPackRequest2 request)
        {
            return await mps.addDataPack(request);
        }

        [HttpPost]
        [Route("getAllOrganizations")]
        public async Task<GetAllOrganizationsOutputDTO2> getAll([FromBody] RegisterRequest request)
        {
            return await mps.getAllOrganizations(request.id);
        }
    }
}
