using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Services.UserDataService;

namespace ExploringSelfSovereignIdentityIntegrationAPI.Tests
{
    [TestClass]
    public class UserDataIntegrationTest
    {
        public UserdataService _userDataService;

        public UserDataIntegrationTest()
        {
            //_userDataService = new UserdataService();
        }

        [TestMethod]
        public async Task TestGetUserData()
        {
            UserDataModel _user = new UserDataModel();
            _user.Id = new Guid();
            _user.Hash = "hashhashhash";
            _user.Profile_version = 1;

            string userId = "testString";

            UserDataModel res = await _userDataService.GetUserData(_user);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Id, _user.Id);
            Assert.AreEqual(res.Hash, _user.Hash);
        }
    }
}