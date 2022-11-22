using CandidateDomain.Features.CreateDatabase.CQRS.Command;
using CandidateDomain.Repositories;
using MediatR;

namespace CandidateInfrastructure.Features.CreateDatabase.CQRS.Command
{
    public class CreateDatabaseCommandHandler : IRequestHandler<CreateDatabaseCommand, bool>
    {
        private readonly ICandidateRepository _candidateRepository;

        public CreateDatabaseCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<bool> Handle(CreateDatabaseCommand request, CancellationToken cancellationToken)
        {
            return await _candidateRepository.EnsureCreatedAsync();
        }
    }
}
