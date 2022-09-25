using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.ContractHandlers;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Function;
using ExploringSelfSovereignIdentityAPI.Models.Response;

namespace ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain
{
    public class UserDataService : IUserDataService
    {
        static string url = "http://127.0.0.1:8545";

        static string privateKey = "57dac1c6a6f92872594081ba7a0f0aaec4ead5c492476e31f7f337c2e8589282";

        //private Web3 Web3Instance = new Web3("http://127.0.0.1:8545");

        private readonly string senderAddress = "0xeE07Cf444e5044295228083C652aA46F9fefA44A";
        private static string contractAddress = "0xDAd7a7BC751b61c8297715E37447EeC7c0F0fCB1";

        static Web3 web3 = new Web3(new Nethereum.Web3.Accounts.Account(privateKey), url);

        private ContractHandler contractHandler = web3.Eth.GetContractHandler(contractAddress);

        public UserDataService()
        {
            web3.TransactionManager.UseLegacyAsDefault = true;
        }

        

        public async Task<string> createUser(string id)
        {
            var createUserFunction = new CreateUserFunction();
            createUserFunction.Id = id;
            var createUserFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(createUserFunction);
            return "success";
        }

        public async Task<string> newTransactionRequest(TransactionRequest request)
        {
            TransactionRequest tr = new TransactionRequest();

            TransactionStamp stamp = new TransactionStamp();
            stamp.ToID = request.Stamp.ToID;
            stamp.FromID = request.Stamp.FromID;
            stamp.Message = request.Stamp.Message;
            stamp.Date = request.Stamp.Date;
            stamp.Status = request.Stamp.Status;

            List<string> attrs = new List<string>();

            for (int i=0; i<request.Attributes.Count; i++) 
            {
                attrs.Add(request.Attributes[i]);
            }

            tr.Attributes = attrs;
            tr.Stamp = stamp;

            NewTransactionRequestFunction newTransactionRequestFunction = new NewTransactionRequestFunction();
            newTransactionRequestFunction.Request = tr;
            TransactionReceipt newTransactionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(newTransactionRequestFunction);

            return "success";
        }

        public async Task<string> approveTransaction(string id, int index)
        {
            ApproveTransactionStageAFunction approveTransactionStageAFunction = new ApproveTransactionStageAFunction();
            approveTransactionStageAFunction.Id = id;
            approveTransactionStageAFunction.Index = index;
            TransactionReceipt approveAFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(approveTransactionStageAFunction);

            ApproveTransactionStageBFunction approveBFunction = new ApproveTransactionStageBFunction();
            approveBFunction.Id = id;
            approveBFunction.Index = index;
            ApproveTransactionStageBOutputDTO approveBFunctionTxnReceipDTO = await contractHandler.QueryDeserializingToObjectAsync<ApproveTransactionStageBFunction, ApproveTransactionStageBOutputDTO>(approveBFunction);



            return "success";
        }


        public async Task<string> approveTransactionStageC(string id, TransactionResponse transaction)
        {
            
            TransactionResponse tr = new TransactionResponse();

            tr.Attributes = transaction.Attributes;
            tr.Stamp = transaction.Stamp;

            var approveTransactionStageCFunction = new ApproveTransactionStageCFunction();
            approveTransactionStageCFunction.Id = id;
            approveTransactionStageCFunction.Transaction = tr;
            var approveTransactionStageCFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(approveTransactionStageCFunction);

            return "success";
        }




        public async Task<string> updateAttributes(string id, AttributeBC[] attributes)
        {
            return "success";
        }

        public async Task<GetAttributesTransactionOutputDTO> getAttributesForTransaction(string id, List<Attribute> attributes)
        {
            var getAttributesTransaction = new GetAttributesTransactionFunction();
            getAttributesTransaction.Id = id;
            getAttributesTransaction.Attributes = attributes;
            var getTransactionATtributesOutputDTO = await contractHandler.QueryDeserializingToObjectAsync<GetAttributesTransactionFunction, GetAttributesTransactionOutputDTO>(getAttributesTransaction);

            return getTransactionATtributesOutputDTO;
        }

        public async Task<GetUserDataOutputDTO> updateUserData(UpdateGen2 update)
        {
            Update u = new Update();
            u.Id = update.Id;

            List<AttributeUpdate> au = new List<AttributeUpdate>();

            for(int i=0;i < update.Attributes.Count;i++)
            {
                AttributeUpdate item = new AttributeUpdate();
                item.Attribute = new Attribute();
                item.Attribute.Name = update.Attributes[i].Attribute.Name;
                item.Attribute.Value = update.Attributes[i].Attribute.Value;

                item.Index = new BigInteger(update.Attributes[i].Index);

                au.Add(item);
                
            }


            List<CredentialUpdate> cu = new List<CredentialUpdate>();
            for (int i = 0; i < update.Credentials.Count; i++)
            {
                
                CredentialUpdate item2 = new CredentialUpdate();

                List<Attribute> ca = new List<Attribute>();
                for (int j = 0; j < update.Credentials[i].Attributes.Count; j++)
                {
                    Attribute item3 = new Attribute();
                    item3.Name = update.Credentials[i].Attributes[j].Name; 
                    item3.Value = update.Credentials[i].Attributes[j].Value;

                    ca.Add(item3);
                }
                item2.Attributes = ca;

                item2.Organization = update.Credentials[i].Organization;

                item2.Index = new BigInteger(update.Credentials[i].Index);

                cu.Add(item2);

            }

            u.Attributes = au;
            u.Credentials = cu;

            var updateUserFunction = new UpdateUserFunction();
            updateUserFunction.Update = u;
            var updateUserFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(updateUserFunction);
            return await getUserData(update.Id);
        }

        public async Task<GetUserDataOutputDTO> getUserData(string id)
        {
            var getUserDataFunction = new GetUserDataFunction(); 
            getUserDataFunction.Id = id;
            var getUserDataOutputDTO = await contractHandler.QueryDeserializingToObjectAsync<GetUserDataFunction, GetUserDataOutputDTO>(getUserDataFunction);

            return getUserDataOutputDTO;
        }
    }
}
