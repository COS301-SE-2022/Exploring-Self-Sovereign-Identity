using ExploringSelfSovereignIdentityAPI.Commands.Transactions;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Services.Transactions
{
    public interface ITransactionService
    {
        List<Transaction> GetPendingTransactions(Guid id);
        Transaction AddPendingTransaction(AddTransactionCommand pendingTransaction);

        Transaction GetPastTransactions(Guid id);

        Transaction SaveTransaction(SaveTransactionCommand saveTransaction);
    }
}
