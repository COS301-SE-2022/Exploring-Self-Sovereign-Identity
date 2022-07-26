using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
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

        private readonly string abi = @"[{'inputs':[{'internalType':'string','name':'_id','type':'string'}],'name':'createUser','outputs':[],'stateMutability':'nonpayable','type':'function'},{'inputs':[{'internalType':'string','name':'_id','type':'string'},{'components':[{'components':[{'internalType':'string','name':'name','type':'string'},{'internalType':'string','name':'value','type':'string'}],'internalType':'struct UserDataContract.Attribute','name':'attribute','type':'tuple'},{'internalType':'bool','name':'isUpdate','type':'bool'}],'internalType':'struct UserDataContract.AttributeUpdate[]','name':'attributes','type':'tuple[]'},{'components':[{'internalType':'string','name':'organization','type':'string'},{'internalType':'bool','name':'isUpdate','type':'bool'},{'components':[{'internalType':'string','name':'name','type':'string'},{'internalType':'string','name':'value','type':'string'}],'internalType':'struct UserDataContract.Attribute[]','name':'attributes','type':'tuple[]'}],'internalType':'struct UserDataContract.CredentialUpdate[]','name':'credentials','type':'tuple[]'}],'name':'updateUser','outputs':[],'stateMutability':'nonpayable','type':'function'},{'inputs':[{'internalType':'string','name':'_id','type':'string'}],'name':'getUserData','outputs':[{'components':[{'internalType':'string','name':'id','type':'string'},{'components':[{'internalType':'string','name':'name','type':'string'},{'internalType':'string','name':'value','type':'string'}],'internalType':'struct UserDataContract.Attribute[]','name':'attributes','type':'tuple[]'},{'components':[{'internalType':'string','name':'organization','type':'string'},{'components':[{'internalType':'string','name':'name','type':'string'},{'internalType':'string','name':'value','type':'string'}],'internalType':'struct UserDataContract.Attribute[]','name':'attributes','type':'tuple[]'}],'internalType':'struct UserDataContract.CredentialResponse[]','name':'credentials','type':'tuple[]'}],'internalType':'struct UserDataContract.UserDataResponse','name':'','type':'tuple'}],'stateMutability':'view','type':'function','constant':true}]";

        private readonly Contract contract;


        public BlockchainService()
        {
           contract = Web3Instance.Eth.GetContract(abi, contractAddress);
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
                    //var gas = await createUserFunction.EstimateGasAsync(senderAddress, null, null, addressTo, value);
                    //var tx = await createUserFunction.SendTransactionAndWaitForReceiptAsync(senderAddress, gas, null, null, addressTo, value);
                    return await createUserFunction.SendTransactionAsync(senderAddress, new HexBigInteger(60), new HexBigInteger(60), new HexBigInteger(60), "id");
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
