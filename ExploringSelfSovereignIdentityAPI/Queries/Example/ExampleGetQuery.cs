using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Queries.Example
{
    public record ExampleGetQuery: IRequest<string> //string is the return type
    {
    }
}
