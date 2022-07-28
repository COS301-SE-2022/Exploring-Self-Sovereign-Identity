using ExploringSelfSovereignIdentityAPI.Models;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.Transactions;
using Nethereum.Web3;
using System;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.blockChain
{
    public class BlockchainService : IBlockchainService
    {

        private readonly Web3 Web3Instance = new Web3("http://127.0.0.1:8545");
        private readonly string senderAddress = "0xeE07Cf444e5044295228083C652aA46F9fefA44A";
        private readonly string contractAddress = "0xf84F284bb25bE2Bae65908BD0b63c263EEFDa41D";

        private readonly string abi = @"[ { 'inputs': [ { 'internalType': 'string', 'name': '_id', 'type': 'string' } ], 'name': 'createUser', 'outputs': [], 'stateMutability': 'nonpayable', 'type': 'function' }, { 'inputs': [ { 'internalType': 'string', 'name': '_id', 'type': 'string' }, { 'components': [ { 'components': [ { 'internalType': 'string', 'name': 'name', 'type': 'string' }, { 'internalType': 'string', 'name': 'value', 'type': 'string' } ], 'internalType': 'struct UserDataContract.Attribute', 'name': 'attribute', 'type': 'tuple' }, { 'internalType': 'bool', 'name': 'isUpdate', 'type': 'bool' } ], 'internalType': 'struct UserDataContract.AttributeUpdate[]', 'name': 'attributes', 'type': 'tuple[]' }, { 'components': [ { 'internalType': 'string', 'name': 'organization', 'type': 'string' }, { 'internalType': 'bool', 'name': 'isUpdate', 'type': 'bool' }, { 'components': [ { 'internalType': 'string', 'name': 'name', 'type': 'string' }, { 'internalType': 'string', 'name': 'value', 'type': 'string' } ], 'internalType': 'struct UserDataContract.Attribute[]', 'name': 'attributes', 'type': 'tuple[]' } ], 'internalType': 'struct UserDataContract.CredentialUpdate[]', 'name': 'credentials', 'type': 'tuple[]' } ], 'name': 'updateUser', 'outputs': [], 'stateMutability': 'nonpayable', 'type': 'function' }, { 'inputs': [ { 'internalType': 'string', 'name': '_id', 'type': 'string' }, { 'internalType': 'uint256', 'name': 'index', 'type': 'uint256' }, { 'internalType': 'string', 'name': 'name', 'type': 'string' }, { 'internalType': 'string', 'name': 'value', 'type': 'string' } ], 'name': 'updateAttribute', 'outputs': [], 'stateMutability': 'nonpayable', 'type': 'function' }, { 'inputs': [ { 'internalType': 'string', 'name': '_id', 'type': 'string' }, { 'internalType': 'string', 'name': 'name', 'type': 'string' }, { 'internalType': 'string', 'name': 'value', 'type': 'string' } ], 'name': 'createAttribute', 'outputs': [], 'stateMutability': 'nonpayable', 'type': 'function' }, { 'inputs': [ { 'internalType': 'string', 'name': '_id', 'type': 'string' }, { 'internalType': 'string', 'name': 'organization', 'type': 'string' }, { 'internalType': 'string', 'name': 'name', 'type': 'string' }, { 'internalType': 'string', 'name': 'value', 'type': 'string' }, { 'internalType': 'bool', 'name': 'isUpdate', 'type': 'bool' } ], 'name': 'updateCredential', 'outputs': [], 'stateMutability': 'nonpayable', 'type': 'function' }, { 'inputs': [ { 'internalType': 'string', 'name': '_id', 'type': 'string' } ], 'name': 'getUserData', 'outputs': [ { 'components': [ { 'internalType': 'string', 'name': 'id', 'type': 'string' }, { 'components': [ { 'internalType': 'string', 'name': 'name', 'type': 'string' }, { 'internalType': 'string', 'name': 'value', 'type': 'string' } ], 'internalType': 'struct UserDataContract.Attribute[]', 'name': 'attributes', 'type': 'tuple[]' }, { 'components': [ { 'internalType': 'string', 'name': 'organization', 'type': 'string' }, { 'components': [ { 'internalType': 'string', 'name': 'name', 'type': 'string' }, { 'internalType': 'string', 'name': 'value', 'type': 'string' } ], 'internalType': 'struct UserDataContract.Attribute[]', 'name': 'attributes', 'type': 'tuple[]' } ], 'internalType': 'struct UserDataContract.CredentialResponse[]', 'name': 'credentials', 'type': 'tuple[]' } ], 'internalType': 'struct UserDataContract.UserDataResponse', 'name': '', 'type': 'tuple' } ], 'stateMutability': 'view', 'type': 'function' } ]";

        private readonly Contract contract;


        public BlockchainService()
        {
            contract = Web3Instance.Eth.GetContract(abi, contractAddress);
        }

        public async Task<string> createUser(string id)
        {
            var createUserFunction = contract.GetFunction("createUser");
            await createUserFunction.SendTransactionAsync(senderAddress, new HexBigInteger(900000), null, id);
            return "success";
        }

        public async Task<string> getUserData(string id)
        {
            var getData = contract.GetFunction("getUserData");
            string transHash = await getData.SendTransactionAsync(senderAddress, new HexBigInteger(900000), null, id);

            return "success";

            //var receipt = await Web3Instance.TransactionManager.SendTransactionAndWaitForReceiptAsync MineAndGetReceiptAsync(Web3Instance, transHash);
        }

        public async Task<string> updateAttributes(string id, AttributeBC[] attributes)
        {

            var create = contract.GetFunction("createAttribute");
            var update = contract.GetFunction("updateAttribute");

            for (int i=0; i<attributes.Length; i++)
            {
                object[] par = { id, attributes[i].name, attributes[i].value };

                string name = attributes[i].name;
                string value = attributes[i].value;

                if (attributes[i].index == -1)
                {
                    await create.SendTransactionAsync(senderAddress, new HexBigInteger(900000), null, id, name, value);
                    continue;
                }

                await update.SendTransactionAsync(senderAddress, new HexBigInteger(900000), null, id, attributes[i].index, attributes[i].name, attributes[i].value);
            }

            //return await getUserData(id);
            return "success";
        }
    }
}
