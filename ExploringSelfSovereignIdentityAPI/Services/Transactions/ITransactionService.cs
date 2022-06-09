using ExploringSelfSovereignIdentityAPI.Commands.Transactions;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Services.Transactions
{
    public interface ITransactionService
    {
        Task<List<GetTransactionResponse>> GetPendingTransactions(Guid id);
        Task<Transaction> AddPendingTransaction(AddTransactionCommand pendingTransaction);

        Task<List<Transaction>> GetPastTransactions(Guid id);

        Transaction SaveTransaction(SaveTransactionCommand saveTransaction);
    }
}
