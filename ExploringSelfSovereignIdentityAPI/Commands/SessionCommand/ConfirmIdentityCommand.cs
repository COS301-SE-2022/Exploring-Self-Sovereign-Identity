using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Commands.SessionCommand
{
    public class ConfirmIdentityCommand: IRequest<DefaultIdentityResponse>
    {
        public LinkedList<string> requiredFields { get; set; }

        public ConfirmIdentityCommand()
        {
            requiredFields = new LinkedList<string>();
        }

        public ConfirmIdentityCommand(LinkedList<string> fields)
        {
            requiredFields = fields;
        }
    }
}
