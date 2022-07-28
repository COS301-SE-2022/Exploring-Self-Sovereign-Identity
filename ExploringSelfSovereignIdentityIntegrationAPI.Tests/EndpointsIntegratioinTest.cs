using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exploring_self_sovereign_identity_api;
using ExploringSelfSovereignIdentityAPI.Models;
using ExploringSelfSovereignIdentityAPI.Services.UserDataService;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ExploringSelfSovereignIdentityIntegrationAPI.Tests
{
    [TestClass]
    public class EndpointsIntegratioinTest
    {
        public UserdataService _userDataService;
        //public IUserDataService _userRepo = new IUserDataService();
        public EndpointsIntegratioinTest()
        {
           // _userDataService = new UserdataService ();
        }

        [TestMethod]
        public async Task TestRegister()
        {
          var webAppFactory = new WebApplicationFactory<Startup>();
            string id = "aaa";

            var httpClient = webAppFactory.CreateDefaultClient();
            var response = await httpClient.GetAsync("api/UserData/test");
            var result = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("success", result);
        }

        [TestMethod]
        public async Task TestGetUserData()
        {

           /* var webAppFactory = new WebApplicationFactory<UserdataService>();
            var httpClient = webAppFactory.CreateDefaultClient();
            var response = await httpClient.GetAsync("");
            var result = await response.Content.ReadAsStringAsync();
            Assert.AreEqual( "aaa" , result );*/ 
            

        }

        [TestMethod]
        public async Task TestUpdateAttributes()
        {
           /*string userId = "aaa";
            AttributeBC name = new AttributeBC();
            name.name = "name";
            name.value = "TestName";
            name.index = 0;

            AttributeBC surname = new AttributeBC();
            surname.name = "surname";
            surname.value = "TestSurname";
            surname.index = 1;

            AttributeBC[] attributes = new AttributeBC[2];
            attributes[0] = name;
            attributes[1] = surname;
            string res = await UserdataService.UpdateUserData(userId, attributes);

            Assert.IsNotNull(res);
            Assert.AreEqual("success", res);*/

        }


    }
}
