using Nethereum.Contracts;
using Nethereum.Web3;
using System;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.blockChain
{
   public class BlockchainService: IBlockchainService
    {
        private readonly Web3 Web3Instance = new Web3("http://127.0.0.1:8545");

        private readonly string senderAddress = "0xeE07Cf444e5044295228083C652aA46F9fefA44A";

        private readonly string contractAddress = "0x38Bfc64aA1d9D8e5DaFb08f252F7619Cd31705B7";

        private readonly Contract contract;


        public BlockchainService()
        {
           contract = Web3Instance.Eth.GetContract("", contractAddress);
        }

        public async Task<string> createUser(string id)
        {

            try
            {
                //id, [[["name","Johan"],false],[["surname","Smit"],false],[["age","21"],false]], []
                string s = "id, [[[\"name\",\"Johan\"],false],[[\"surname\",\"Smit\"],false],[[\"age\",\"21\"],false]], []";

                var createUserFunction = contract.GetFunction("getUserData");
                try
                {
                    return await createUserFunction.SendTransactionAsync(senderAddress, "id");
                }
                catch (Exception e)
                {
                    return "Failed on 2nd call: " + e.Message;
                }
            }
            catch (Exception e)
            {
                return "Failed on 1st call: " + e.Message;
            }
            

            

          
            
        }
    }
}
