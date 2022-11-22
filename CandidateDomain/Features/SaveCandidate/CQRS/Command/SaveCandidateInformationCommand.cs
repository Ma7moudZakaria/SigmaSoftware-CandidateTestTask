using CandidateDomain.Features.SaveCandidate.DTO;
using MediatR;

namespace CandidateDomain.Features.SaveCandidate.CQRS.Command
{
    public record SaveCandidateInformationCommand(SaveCandidateInformationDTO SaveCandidateInformationRequest) : IRequest<GetExecutionResult>;
}
