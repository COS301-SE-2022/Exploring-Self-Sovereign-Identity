using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.Transactions
{
    public interface ITransactionRepository
    {

        public  Task<int> AddPendingTransaction(Transaction transaction);

        public  Task<List<Transaction>> GetPastTransactions(Guid id);

        public  Task<List<Transaction>> GetPendingTransactions(Guid id);

        public  Task<int> SaveTransaction(Transaction saveTransaction);

        //public Task<Contract>

    }
}
