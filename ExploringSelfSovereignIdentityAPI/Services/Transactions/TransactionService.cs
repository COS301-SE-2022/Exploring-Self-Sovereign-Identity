using ExploringSelfSovereignIdentityAPI.Commands.Transactions;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
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

        
        public Transaction AddPendingTransaction(AddTransactionCommand pendingTransaction)
        {
            /*var transaction = new Transaction();
            transaction.
            _transactionRepository.AddPendingTransaction(pendingTransaction);*/
            throw new NotImplementedException();
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
