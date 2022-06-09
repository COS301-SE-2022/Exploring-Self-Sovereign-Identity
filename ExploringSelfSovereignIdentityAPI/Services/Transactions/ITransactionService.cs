using ExploringSelfSovereignIdentityAPI.Models.Entity;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Services.Transactions
{
    public interface ITransactionService
    {
        List<Transaction> GetPendingTransactions();
        //Transaction AddPendingTransaction()
    }
}
