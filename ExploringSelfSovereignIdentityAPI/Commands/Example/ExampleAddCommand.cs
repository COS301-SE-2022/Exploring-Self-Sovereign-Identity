using ExploringSelfSovereignIdentityAPI.Models.Example;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Commands.Example
{
    public class ExampleAddCommand: IRequest<ExampleModel>  //ExampleModel is the return type
    {
        public string FieldA { get;}
        public string FieldB { get;}
        public ExampleAddCommand(string FieldA, string FieldB)
        {
            this.FieldA = FieldA;
            this.FieldB = FieldB;
        }
    }
}
