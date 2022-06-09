using ExploringSelfSovereignIdentityAPI.Data;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.Transactions
{
    
    
    public class TransactionRepository : ITransactionRepository
    {


        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddPendingTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetPastTransactions(Guid id)
        {
            return await _context.Transactions.Where(t => t.From == id || t.To == id).ToListAsync();
        }

        public async Task<List<Transaction>> GetPendingTransactions(Guid id)
        {
            return await _context.Transactions.Where( t => 
                t.To == id && 
                _context.Contracts.FindAsync(t.ContractID).Result.Signature.Equals("")
            ).ToListAsync();
        }

        public async Task<int> SaveTransaction(Transaction saveTransaction)
        {
            _context.Transactions.Add(saveTransaction);
            return await _context.SaveChangesAsync();

        }
    }
}
