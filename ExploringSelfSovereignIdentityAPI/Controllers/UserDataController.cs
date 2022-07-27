using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories; 
using Microsoft.AspNetCore.Http;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExploringSelfSovereignIdentityAPI.Services;
using ExploringSelfSovereignIdentityAPI.Services.UserDataService;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
using System;
using ExploringSelfSovereignIdentityAPI.Services.blockChain;
using ExploringSelfSovereignIdentityAPI.Models.Request;

namespace ExploringSelfSovereignIdentityAPI.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : Controller
    {

        private readonly IBlockchainService blockchainService;

        public UserDataController(IBlockchainService blockchainService)
        {
            this.blockchainService = blockchainService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<string> Register([FromBody] RegisterRequest request)
        {
            return await blockchainService.createUser(request.id);
        }

        [HttpPost]
        [Route("getUserData")]
        public async Task<string> GetUserData([FromBody] RegisterRequest request)
        {
            return await blockchainService.getUserData(request.id);
        }

        [HttpPost]
        [Route("updateAttributes")]
        public async Task<string> UpdateAttributes([FromBody] AttributeRequestBC request)
        {
            return await blockchainService.updateAttributes(request.id, request.attributes);
        }
    }
}
