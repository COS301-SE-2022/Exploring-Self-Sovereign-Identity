using ExploringSelfSovereignIdentityAPI.Models;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;

namespace ExploringSelfSovereignIdentityIntegrationAPI.Tests
{
    [TestClass]
    public class UserDataIntegrationTest
    {
        public UserDataService _userDataService;

        public UserDataIntegrationTest()
        {
            _userDataService = new UserDataService();
        }


        [TestMethod]
        public async Task TestCreateUser()
        {
            string userId = "aaa";
            string res = await _userDataService.createUser(userId);
            Assert.IsNotNull(res);
            Assert.AreEqual("success", res);
        }





    }
}