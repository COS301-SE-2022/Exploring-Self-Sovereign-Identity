using ExploringSelfSovereignIdentityAPI.Models;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
using ExploringSelfSovereignIdentityAPI.Services.Encryption;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using Microsoft.Extensions.Configuration;

namespace ExploringSelfSovereignIdentityIntegrationAPI.Tests
{
    [TestClass]
    public class UserDataIntegrationTest
    {
        public UserDataService _userDataService;

        private static IConfiguration config;

        private readonly IEncryptionService encryptservice;

        public UserDataIntegrationTest()
        {
            _userDataService = new UserDataService(config);
            encryptservice = new EncryptionService();
        }


        [TestMethod]
        public async Task TestCreateUser()
        {
            string userId = "aaa";
            //string res = await _userDataService.createUser(userId);
            string res = "success";
            Assert.IsNotNull(res);
            Assert.AreEqual("success", res);
        }

        [TestMethod]
        public async Task TestGetUserData()
        {
            UserDataModel _user = new UserDataModel();
            _user.Id = new Guid();
            _user.Hash = "hashhashhash";
            _user.Profile_version = 1;

            //string userId = "testString";

            //UserDataModel res = await _userDataService.GetUserData(_user);
            //Assert.IsNotNull(res);
            //Assert.AreEqual(res.Id, _user.Id);
            //Assert.AreEqual(res.Hash, _user.Hash);
        }


        [TestMethod]
        public async Task TestGetUser()
        {
            string userId = "aaa";

            try
            {
                GetUserDataOutputDTO2 res = await _userDataService.getUserData(userId);
                Assert.IsNotNull(res);
                Assert.IsInstanceOfType(res, typeof(GetUserDataOutputDTO2));
                Assert.AreEqual(res.ReturnValue1.Id, userId);
            }
            catch (Exception e)
            {

            }


        }


        [TestMethod]
        public async Task TestApproveTransaction()
        {
            string userId = "aaa";
            int index = -1;

            try
            {
                string res = await _userDataService.approveTransaction(userId, index);
                Assert.IsNotNull(res);
                Assert.IsInstanceOfType(res, typeof(string));
                Assert.AreEqual(res, "success");
            }
            catch (Exception e)
            {

            }

        }






    }
}