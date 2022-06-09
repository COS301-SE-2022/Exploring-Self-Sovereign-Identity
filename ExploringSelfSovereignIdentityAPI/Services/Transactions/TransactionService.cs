using ExploringSelfSovereignIdentityAPI.Commands.Transactions;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Repositories.Transactions;
using System;
using System.Collections.Generic;

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
            //var transaction = new Transaction();
            //transaction.ContractID
            //_transactionRepository.AddPendingTransaction(pendingTransaction);
            throw new NotImplementedException();
        }

        public Transaction GetPastTransactions(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetPendingTransactions(Guid id)
        {
            throw new NotImplementedException();
        }

        public Transaction SaveTransaction(SaveTransactionCommand saveTransaction)
        {
            throw new NotImplementedException();
        }
    }
}
