using ExploringSelfSovereignIdentityAPI.Data;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Request;
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

        public async Task<Transaction> AddPendingTransaction(Transaction transaction)
        {
            transaction.Id = new Guid();
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return transaction;

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

        public async Task<Transaction> SaveTransaction(Transaction saveTransaction)
        {
            saveTransaction.Id = new Guid();
            await _context.Transactions.AddAsync(saveTransaction);
            await _context.SaveChangesAsync();

            return saveTransaction;

        }

        public async Task<Contract> addContract(Contract contract)
        {
            contract.Id = new Guid();
            await _context.Contracts.AddAsync(contract);
            await _context.SaveChangesAsync();
            return contract;
        }

        public async Task<ContractAttribute> addContractAttribute(AddAttributeRequest att, Guid contractId)
        {
            Models.Entity.Attribute a = new Models.Entity.Attribute(att.name, att.value);
            a.Id = new Guid();
            await _context.Attributes.AddAsync(a);
            await _context.SaveChangesAsync();

            ContractAttribute ca = new ContractAttribute();
            ca.Id = new Guid();
            ca.ContractId = contractId;
            ca.AttributeId = a.Id;

            await _context.ContractAttributes.AddAsync(ca);
            await _context.SaveChangesAsync();

            return ca;
        }
    }
}
