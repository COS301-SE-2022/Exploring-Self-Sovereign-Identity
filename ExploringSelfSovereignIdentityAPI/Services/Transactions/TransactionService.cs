using ExploringSelfSovereignIdentityAPI.Commands.Transactions;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Repositories.Transactions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        
        public async Task<Transaction> AddPendingTransaction(AddTransactionCommand pendingTransaction)
        {
            Contract contract = new Contract();
            contract.Signature = null;

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

        public async Task<List<Transaction>> GetPendingTransactions(Guid id)
        {
            var transaction = await _transactionRepository.GetPendingTransactions(id);
            List<Transaction> ret = new List<Transaction>();
            transaction.ForEach(t =>
            {
                //ret.Add(_transactionRepository.GetContract(id));
                
            });

            throw new NotImplementedException();
        
        }

        public Transaction SaveTransaction(SaveTransactionCommand saveTransaction)
        {
            throw new NotImplementedException();
        }
    }
}
