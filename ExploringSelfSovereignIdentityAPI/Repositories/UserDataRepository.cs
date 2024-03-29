﻿using ExploringSelfSovereignIdentityAPI.Data;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly ApplicationDbContext _context;
        public UserDataRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<UserDataModel> Add()
        {
            //throw new System.NotImplementedException();
            
            UserDataModel usr1 = new();
            
            var newUser = await _context.UserDataModels.AddAsync(usr1);
            await _context.SaveChangesAsync();

            //newUser = await _context.UserDataModels.FindAsync(newUser);

            return newUser.Entity;
        }

        public Task<string> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDataModel> GetUserData(UserDataModel e)
        {
            e.AddAttribute("Name", true);
            e.AddAttribute("Surname", false);
            e.AddAttribute("Email", true);
            e.AddAttribute("Number", false);

            await _context.UserDataModels.AddAsync(e);

            return e;
        }

       public async Task<UserDataModel> GetUser(Guid e)
        {
            return await _context.UserDataModels.FindAsync(e); 
        }

        /*public async Task<UserDataModel> AddUser(UserDataModel f)
        {
           
        }*/

        public async Task<UserDataModel> UpdateUserData(UserDataModel e)
        {
            UserDataModel userFromDB = await _context.UserDataModels.FindAsync(e.Id); //fetch user from db 
            
            userFromDB.Profile_version = e.Profile_version; 

            await _context.SaveChangesAsync(); 

            return e;

        }
    }
}
