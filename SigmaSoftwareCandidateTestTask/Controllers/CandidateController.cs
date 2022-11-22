using CandidateDomain.Features.CreateDatabase.CQRS.Command;
using CandidateDomain.Features.SaveCandidate.CQRS.Command;
using CandidateDomain.Features.SaveCandidate.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SigmaSoftwareCandidateTestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<bool> CreateDatabase()
        {
            var result = await _mediator.Send(new CreateDatabaseCommand());

            return result;
        }

        [HttpPost]
        public async  Task<GetExecutionResult> SaveCandidate([FromBody] SaveCandidateInformationDTO saveCandidateInformationRequest)
        {
            var result = await _mediator.Send(new SaveCandidateInformationCommand(saveCandidateInformationRequest));

            return result;
        }
    }
}