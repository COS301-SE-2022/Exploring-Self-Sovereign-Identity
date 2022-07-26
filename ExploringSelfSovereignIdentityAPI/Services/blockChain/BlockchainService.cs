using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using System;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.blockChain
{
   public class BlockchainService: IBlockchainService
    {
        private readonly Web3 Web3Instance = new Web3("http://127.0.0.1:7545");

        private readonly string senderAddress = "0xD6059FB76172C8d7f4845c94a0D8b2F74620105b";

        private readonly string contractAddress = "0xf84F284bb25bE2Bae65908BD0b63c263EEFDa41D";

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
                //string s = "id, [[[\"name\",\"Johan\"],false],[[\"surname\",\"Smit\"],false],[[\"age\",\"21\"],false]], []";

                var createUserFunction = contract.GetFunction("getUserData");
                try
                {
                    return await createUserFunction.SendTransactionAsync(senderAddress, new HexBigInteger(900000), null, "id");
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
