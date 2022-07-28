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
        public /*async Task<UserDataResponse>*/ UserDataResponse UpdateAttributes([FromBody] UserDataResponse request)
        {
            //return await blockchainService.updateAttributes(request.id, request.attributes);
            //await uds.updateAttributes(request.id, request.attributes);
            //return await uds.getUserData(request.id);

            for (int i=0; i<request.Attributes.Count; i++)
            {
                
                if (i < response.Attributes.Count)
                {
                    response.Attributes[i].Name = request.Attributes[i].Name;
                    response.Attributes[i].Value = request.Attributes[i].Value;
                    continue;
                }

                Services.NetheriumBlockChain.Attribute a1 = new Services.NetheriumBlockChain.Attribute();
                a1.Name = request.Attributes[i].Name;
                a1.Value = request.Attributes[i].Value;

                response.Attributes.Add(a1);
                
            }

            return response;
        }

        [HttpPost]
        [Route("updateCredential")]
        public /*async Task<UserDataResponse>*/ UserDataResponse UpdateCredentials([FromBody] CredentialRequestBC request)
        {
            
            /*for (int i=0; i<request.credentials.Length; i++)
            {
                for (int k=0; lock< request.credentials[i])
            }*/

            return response;
        }
    }
}
