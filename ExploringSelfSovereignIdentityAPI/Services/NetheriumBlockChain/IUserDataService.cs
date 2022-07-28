﻿using ExploringSelfSovereignIdentityAPI.Models;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain
{
    public interface IUserDataService
    {
        public Task<string> createUser(string id);
        public Task<string> updateAttributes(string id, AttributeBC[] attributes);
        public Task<UserDataResponse> getUserData(string id);
    }
}