using ExploringSelfSovereignIdentityAPI.Commands.Transactions;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.Transactions
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetPendingTransactions(Guid id);
        Transaction AddPendingTransaction(AddTransactionCommand pendingTransaction);

        Task<List<Transaction>> GetPastTransactions(Guid id);

        Transaction SaveTransaction(SaveTransactionCommand saveTransaction);
    }
}
