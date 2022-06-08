using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Commands.Contract
{
    public class AddContractCommand: IRequest<GetContractResponse>
    {
        public string signature { get; set; }
        public LinkedList<int> attributes { get; set; }

        public AddContractCommand()
        {
            attributes = new LinkedList<int>();
        }

        public AddContractCommand(string signature, LinkedList<int> attributes)
        {
            this.signature = signature;
            this.attributes = attributes;
        }
    }
}
