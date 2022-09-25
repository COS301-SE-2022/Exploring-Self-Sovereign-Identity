using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Services.blockChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityIntegrationAPI.Tests
{
    [TestClass]
    public class BlockChainIntegrationTest
    {
        public BlockchainService _blockChainService;

        public BlockChainIntegrationTest()
        {
            _blockChainService = new BlockchainService();
        }

        [TestMethod]
        public async Task TestCreateUser()
        {
            string userId = "aaa";
            string res = await _blockChainService.createUser(userId);
            Assert.IsNotNull(res);
            Assert.AreEqual("success", res);
        }

        [TestMethod]
        public async Task TestGetUserData()
        {
            string userId = "aaa";
            var res = await _blockChainService.getUserData(userId);
            Assert.IsNotNull(res);
            Assert.AreEqual("success", res);
        }

        [TestMethod]
        public async Task TesUpdateAttributes()
        {
            string userId = "aaa";
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
            string res = await _blockChainService.updateAttributes(userId, attributes);

            Assert.IsNotNull(res);
            Assert.AreEqual("success", res);
        }
    }
}
