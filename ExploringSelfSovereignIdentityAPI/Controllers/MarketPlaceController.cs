using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<GetOrganizationOutputDTO> get([FromBody] CreateOrgRequest request)
        {
            return await mps.getOrganization(request);
        }

        [HttpPost]
        [Route("buyData")]
        public async Task<string> buy([FromBody] BuyDataRequest request)
        {
            return await mps.buyData(request);
        }

        [HttpPost]
        [Route("addData")]
        public async Task<string> add([FromBody] AddDataPackRequest request)
        {
            return await mps.addDataPack(request);
        }
    }
}
