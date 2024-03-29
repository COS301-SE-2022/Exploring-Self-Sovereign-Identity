﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using System;
using ExploringSelfSovereignIdentityAPI.Services.blockChain;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using Microsoft.AspNetCore.Authorization;

namespace ExploringSelfSovereignIdentityAPI.Controllers.UserData
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : Controller
    {

        private readonly IUserDataService uds;

        public UserDataController(IBlockchainService blockchainService, IUserDataService uds)
        {
            this.uds = uds;
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public async Task<string> Register([FromBody] RegisterRequest request)
        {
            return await uds.createUser(request.id);
        }

        //[Authorize]
        [HttpPost]
        [Route("get")]
        public async Task<GetUserDataOutputDTO2> GetUserData([FromBody] RegisterRequest request)
        {
            return await uds.getUserData(request.id);
        }

        //[Authorize]
        [HttpPost]
        [Route("update")]
        public async Task<GetUserDataOutputDTO2> UpdateCredentials([FromBody] UpdateGen2 request )
        {
            return await uds.updateUserData(request);
        }

        //Transactions

        //[Authorize]
        [HttpPost]
        [Route("newTransaction")]
        public async Task<String> newTransaction([FromBody] TransactionRequest request)
        {
            return await uds.newTransactionRequest(request);
        }

        //[Authorize]
        [HttpPost]
        [Route("approveTransaction")]
        public async Task<String> approveTransaction([FromBody] ApproveTransactionRequest request)
        {
            return await uds.approveTransaction(request.id, request.index);
        }

        //[Authorize]
        [HttpPost]
        [Route("declineTransaction")]
        public async Task<String> declineTransaction([FromBody] ApproveTransactionRequest request)
        {
            return await uds.declineTransaction(request.id, request.index);
        }
    }
}
