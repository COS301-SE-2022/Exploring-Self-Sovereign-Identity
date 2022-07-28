using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories; 
using Microsoft.AspNetCore.Http;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExploringSelfSovereignIdentityAPI.Services;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
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
        private readonly IUserDataService uds;

        private UserDataResponse response = new UserDataResponse();

        public UserDataController(IBlockchainService blockchainService, IUserDataService uds)
        {
            this.blockchainService = blockchainService;
            this.uds = uds;

            response.Id = "aaa";

            response.Attributes = new List<Services.NetheriumBlockChain.Attribute>();
            response.Credentials = new List<CredentialResponse>();

            Services.NetheriumBlockChain.Attribute a1 = new Services.NetheriumBlockChain.Attribute();
            Services.NetheriumBlockChain.Attribute a2 = new Services.NetheriumBlockChain.Attribute();
            Services.NetheriumBlockChain.Attribute a3 = new Services.NetheriumBlockChain.Attribute();

            a1.Name = "name";
            a1.Value = "Johan";

            a2.Name = "surname";
            a2.Value = "Smit";

            a3.Name = "age";
            a3.Value = "21";

            response.Attributes.Add(a1);
            response.Attributes.Add(a2);
            response.Attributes.Add(a3);

            CredentialResponse c1 = new CredentialResponse();
            c1.Organization = "Google";
            c1.Attributes = new List<Services.NetheriumBlockChain.Attribute>();

            Services.NetheriumBlockChain.Attribute ca1 = new Services.NetheriumBlockChain.Attribute();
            Services.NetheriumBlockChain.Attribute ca2 = new Services.NetheriumBlockChain.Attribute();
            ca1.Name = "email";
            ca1.Value = "JohanSmit@gmail.com";
            ca2.Name = "number";
            ca2.Value = "0823255012";

            c1.Attributes.Add(ca1);
            c1.Attributes.Add(ca2);

            response.Credentials.Add(c1);
        }

        [HttpPost]
        [Route("create")]
        public /*async Task<string>*/ string Register([FromBody] RegisterRequest request)
        {
            //return await blockchainService.createUser(request.id);
            //return await uds.createUser(request.id);
            response.Id = request.id;
            return "success";
        }

        [HttpPost]
        [Route("get")]
        public UserDataResponse GetUserData([FromBody] RegisterRequest request)
        {
            //await blockchainService.getUserData(request.id);
            //return await uds.getUserData(request.id);
            return response;
        }

        [HttpPost]
        [Route("updateAttribute")]
        public /*async Task<UserDataResponse>*/ UserDataResponse UpdateAttributes([FromBody] AttributeRequestBC request)
        {
            //return await blockchainService.updateAttributes(request.id, request.attributes);
            //await uds.updateAttributes(request.id, request.attributes);
            //return await uds.getUserData(request.id);

            for (int i=0; i<request.attributes.Length; i++)
            {
                if (request.attributes[i].index == -1)
                {
                    Services.NetheriumBlockChain.Attribute attr = new Services.NetheriumBlockChain.Attribute();
                    attr.Name = request.attributes[i].name;
                    attr.Value = request.attributes[i].value;

                    response.Attributes.Add(attr);

                    continue;
                }

                response.Attributes[request.attributes[i].index].Name = request.attributes[i].name;
                response.Attributes[request.attributes[i].index].Value = request.attributes[i].value;
            }

            return response;
        }

        [HttpPost]
        [Route("updateAttribute")]
        public /*async Task<UserDataResponse>*/ UserDataResponse UpdateCredentials([FromBody] CredentialRequestBC request)
        {
            
            for (int i=0; i<request.credentials.Length; i++)
            {
                
            }

            return response;
        }
    }
}
