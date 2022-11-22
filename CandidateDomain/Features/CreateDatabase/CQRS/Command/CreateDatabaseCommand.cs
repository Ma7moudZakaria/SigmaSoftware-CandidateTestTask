using MediatR;

namespace CandidateDomain.Features.CreateDatabase.CQRS.Command
{
    public record CreateDatabaseCommand() : IRequest<bool>;
}
