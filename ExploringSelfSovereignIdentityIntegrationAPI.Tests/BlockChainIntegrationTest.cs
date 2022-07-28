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

        [TestMethod]
        public async Task TestCreateUser()
        {
            string userId = "aaa";
            string res = await _blockChainService.createUser(userId);
            Assert.IsNotNull(res);
            Assert.AreEqual(userId, res);
        }
    }
}
