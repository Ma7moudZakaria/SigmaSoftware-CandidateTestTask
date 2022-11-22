using AutoMapper;
using FluentValidation;
using MediatR.Pipeline;
using MediatR;
using Microsoft.Extensions.Logging;
using CandidateDomain.Features.SaveCandidate.CQRS.Command;
using CandidateDomain.Features.SaveCandidate.DTO;
using CandidateDomain.Repositories;
using CandidateInfrastructure.Helpers;
using static CandidateDomain.Constants;
using CandidateEntites.Entities;

namespace CandidateInfrastructure.Features.SaveCandidate.CQRS.Command
{
    public class SaveCandidateInformationCommandHandler : IRequestHandler<SaveCandidateInformationCommand, GetExecutionResult>, IRequestExceptionHandler<SaveCandidateInformationCommand, GetExecutionResult>
    {
        private readonly IValidator<SaveCandidateInformationCommand> _validator;
        private readonly ICandidateRepository _candidateRepository;
        protected readonly ILogger _logger;
        private readonly IMapper _mapper;


        public SaveCandidateInformationCommandHandler(IValidator<SaveCandidateInformationCommand> validator,
                                          ICandidateRepository candidateRepository,
                                          ILogger<SaveCandidateInformationCommandHandler> logger,
                                          IMapper mapper)
        {
            _validator = validator;
            _candidateRepository = candidateRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetExecutionResult> Handle(SaveCandidateInformationCommand request, CancellationToken cancellationToken)
        {
            GetExecutionResult result = new GetExecutionResult();

            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errorCodes = validationResult.Errors.Select(a => a.ErrorCode);

                string errorCode = string.Join(",", errorCodes);

                _logger.LogError("Invalid Request Operation", errorCode);

                throw new CustomException(HttpCustomErrorCode.CustomCandidateError, "Invalid Request Operation", errorCode);
            }

            _logger.LogInformation("Start to check if that email is exist or not");

            var candidateResult = await _candidateRepository.GetCandidateByEmailAsync(request.SaveCandidateInformationRequest.Email, cancellationToken);

            _logger.LogInformation("finsihed tocheck if that email is exist or not");

            _logger.LogInformation("Start to map classification certificate");

            var mappedData = _mapper.Map<Candidate>(request.SaveCandidateInformationRequest);

            _logger.LogInformation("finsihed to map classification certificate");

            if (candidateResult is not null)
            {
                candidateResult.Email = mappedData.Email; 
                candidateResult.FirstName = mappedData.FirstName; 
                candidateResult.LastName = mappedData.LastName; 
                candidateResult.PhoneNumber = mappedData.PhoneNumber;
                candidateResult.Comment = mappedData.Comment;
                candidateResult.TimeInterval = mappedData.TimeInterval;
                candidateResult.LinkedInProfileURL = mappedData.LinkedInProfileURL;
                candidateResult.GitHubURL = mappedData.GitHubURL;

                _logger.LogInformation("Start Updating candidate contact by email {Email}", mappedData.Email);

                await _candidateRepository.UpdateCandidateAsync(candidateResult, cancellationToken);

                _logger.LogInformation("finsihed Updating candidate contact by email {Email}", mappedData.Email);
            }
            else
            {
                _logger.LogInformation("Start Creating candidate contact by email {Email}", mappedData.Email);

                await _candidateRepository.CreateCandidateAsync(mappedData, cancellationToken);

                _logger.LogInformation("finsihed Creating candidate contact by email {Email}", mappedData.Email);
            }

            result.Id = mappedData.Id;

            return result;
        }

        public async Task Handle(SaveCandidateInformationCommand request, Exception exception, RequestExceptionHandlerState<GetExecutionResult> state, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Error in Saving candidate contact by email {Email}", request.SaveCandidateInformationRequest.Email);
        }
    }
}
