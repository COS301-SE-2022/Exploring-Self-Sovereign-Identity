using ExploringSelfSovereignIdentityAPI.Models.Entity;
using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Repositories.Transactions
{
    public interface ITransactionRepository
    {

        public  Task<Transaction> AddPendingTransaction(Transaction transaction);

        public  Task<List<Transaction>> GetPastTransactions(Guid id);

        public  Task<List<Transaction>> GetPendingTransactions(Guid id);

        public  Task<Transaction> SaveTransaction(Transaction saveTransaction);
        public Task<Contract> addContract(Contract contract);
        Task<ContractAttribute> addContractAttribute(AddAttributeRequest att, Guid contractId);
        Task<Contract> GetContract(Guid contractID);
        Task<List<ContractAttribute>> GetContractAttribute(Guid id);
        Task<Models.Entity.Attribute> GetAttribute(Guid attributeId);

        //public Task<Contract>

    }
}
