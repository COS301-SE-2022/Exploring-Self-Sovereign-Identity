using ExploringSelfSovereignIdentityAPI.Commands;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using MediatR;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.Response
{
    public partial class UserDataResponse : UserDataResponseBase { }

    public class UserDataResponseBase: IRequest<UserDataResponse>
    {
        [Parameter("string", "id", 1)]
        public virtual string Id { get; set; }
        [Parameter("tuple[]", "attributes", 2)]
        public virtual List<Attribute> Attributes { get; set; }
        [Parameter("tuple[]", "credentials", 3)]
        public virtual List<CredentialResponse> Credentials { get; set; }
        [Parameter("tuple[]", "transactionRequests", 4)]
        public virtual List<TransactionRequest> TransactionRequests { get; set; }
        [Parameter("tuple[]", "approvedTransactions", 5)]
        public virtual List<TransactionResponse> ApprovedTransactions { get; set; }

        public UserDataResponseBase()
        {
            Attributes = new List<Attribute>();
            Credentials = new List<CredentialResponse>();
            TransactionRequests = new List<TransactionRequest>();
            ApprovedTransactions = new List<TransactionResponse>();
        }
    }
}
