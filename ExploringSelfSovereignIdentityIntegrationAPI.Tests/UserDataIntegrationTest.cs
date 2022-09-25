using ExploringSelfSovereignIdentityAPI.Models;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using System.Numerics;
using Attribute = ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain.Attribute;

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
            //string res = "success";
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

            /*UserDataModel res = await _userDataService.GetUserData(_user);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Id, _user.Id);
            Assert.AreEqual(res.Hash, _user.Hash);*/
        }


        [TestMethod]
        public async Task TestGetUser()
        {
            string userId = "aaa";

            try
            {
                GetUserDataOutputDTO res = await _userDataService.getUserData(userId);
                Assert.IsNotNull(res);
                Assert.IsInstanceOfType(res, typeof(GetUserDataOutputDTO));
                Assert.AreEqual(res.ReturnValue1.Id, userId);
            }
            catch(Exception e)
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



        [TestMethod]
        public async Task TestgetAttributesForTransaction()
        {
            string userId = "aaa";
            List<Attribute> attributes = new List<Attribute>();
            attributes.Add(new Attribute());


            try
            {
                GetAttributesTransactionOutputDTO res = await _userDataService.getAttributesForTransaction(userId, attributes);
                Assert.IsNotNull(res);
                Assert.IsInstanceOfType(res, typeof(GetAttributesTransactionOutputDTO));
                Assert.AreEqual(res, attributes);
            }
            catch (Exception e)
            {

            }

        }


        [TestMethod]
        public async Task TestupdateUserData()
        {
            
            UpdateGen2 update = new UpdateGen2();
            update.Id = "test";

            AttributeUpdate item = new AttributeUpdate();




            try
            {
                if(update != null)
                {
                    GetUserDataOutputDTO res = await _userDataService.updateUserData(update);
                    Assert.IsNotNull(res);
                    Assert.IsInstanceOfType(res, typeof(GetUserDataOutputDTO));
                    Assert.AreEqual(res, update);
                }

            }
            catch (Exception e)
            {

            }

        }



        [TestMethod]
        public async Task TestnewTransactionRequest()
        {

            TransactionRequest request = new TransactionRequest();
            request.Stamp.ToID = "1234";
            request.Stamp.FromID = "4321";
            request.Stamp.Message = "Test";
            request.Stamp.Date = "Date";
            request.Stamp.Status = "Status";

            List<string> attrs = new List<string>();

            for (int i = 0; i < request.Attributes.Count; i++)
            {
                attrs.Add(request.Attributes[i]);
            }


            try
            {
                if (request != null)
                {
                    string res = await _userDataService.newTransactionRequest(request);
                    Assert.IsNotNull(res);
                    Assert.IsInstanceOfType(res, typeof(string));
                    Assert.AreEqual(res, request);
                }

            }
            catch (Exception e)
            {

            }

        }



    }
}