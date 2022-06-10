using ExploringSelfSovereignIdentityAPI.Commands.Transactions;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Repositories.Transactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attribute = ExploringSelfSovereignIdentityAPI.Models.Entity.Attribute;

namespace ExploringSelfSovereignIdentityAPI.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        
        public async Task<Transaction> AddPendingTransaction(AddTransactionCommand pendingTransaction)
        {
            Contract contract = new Contract();
            
            contract.Signature = pendingTransaction.contract.Signature;

            contract = await _transactionRepository.addContract(contract);

            foreach (AddAttributeRequest att in pendingTransaction.contract.Attributes)
            {
                await _transactionRepository.addContractAttribute(att, contract.Id);
            }
            
            Transaction transaction = new Transaction();
            transaction.ContractID = contract.Id;
            transaction.To = pendingTransaction.To;
            transaction.From = pendingTransaction.From;


            return await _transactionRepository.AddPendingTransaction(transaction);
        }

        public async Task<List<Transaction>> GetPastTransactions(Guid id)
        {
           return await  _transactionRepository.GetPastTransactions(id);
        }

        public async Task<List<GetTransactionResponse>> GetPendingTransactions(Guid id)
        {
            
            List<Transaction> transactions = await _transactionRepository.GetPendingTransactions(id);
            List<GetTransactionResponse> ret = new List<GetTransactionResponse>();
            transactions.ForEach(async t =>
            {
                GetTransactionResponse response = await CreateTransactionResponse(t);
                ret.Add(response);
                
            });

            return ret;
        
        }

        private async Task<GetTransactionResponse> CreateTransactionResponse(Transaction t)
        {
            GetTransactionResponse response = new GetTransactionResponse();
            response.From = t.From;
            response.To = t.To;
            Contract contract = await _transactionRepository.GetContract(t.ContractID);
            List<ContractAttribute> contractAttributes = await _transactionRepository.GetContractAttribute(contract.Id);

            GetContractResponse contractResponse = new GetContractResponse();
            contractResponse.Signature = contract.Signature;
            contractResponse.Id = contract.Id;


            foreach (ContractAttribute contractAttribute in contractAttributes)
            {
                Attribute attribute = await _transactionRepository.GetAttribute(contractAttribute.AttributeId);
                AddAttributeRequest attObject = new AddAttributeRequest();
                attObject.value = attribute.Value;
                attObject.name = attribute.Name;

                contractResponse.Attributes.AddLast(attObject);
            }

            response.contract = contractResponse;

            return response;
        }

        public Transaction SaveTransaction(SaveTransactionCommand saveTransaction)
        {
            throw new NotImplementedException();
        }
    }
}
