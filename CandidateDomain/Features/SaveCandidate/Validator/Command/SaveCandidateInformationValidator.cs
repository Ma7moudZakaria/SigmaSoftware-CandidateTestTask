using CandidateDomain.Features.SaveCandidate.CQRS.Command;
using FluentValidation;

namespace CandidateDomain.Features.SaveCandidate.Validator.Command
{
    public class SaveCandidateInformationValidator : AbstractValidator<SaveCandidateInformationCommand>
    {
        public SaveCandidateInformationValidator()
        {
            RuleFor(x => x.SaveCandidateInformationRequest.FirstName)
               .NotNull()
               .NotEmpty().WithErrorCode(Constants.ErrorCode.InvalidFirstName)
               .WithErrorCode(Constants.ErrorCode.InvalidFirstName);

            RuleFor(x => x.SaveCandidateInformationRequest.LastName)
               .NotNull()
               .NotEmpty().WithErrorCode(Constants.ErrorCode.InvalidLastName)
               .WithErrorCode(Constants.ErrorCode.InvalidLastName);

            RuleFor(x => x.SaveCandidateInformationRequest.Email)
               .NotNull()
               .NotEmpty().WithErrorCode(Constants.ErrorCode.InvalidEmail)
               .WithErrorCode(Constants.ErrorCode.InvalidEmail);

            RuleFor(x => x.SaveCandidateInformationRequest.Comment)
               .NotNull()
               .NotEmpty().WithErrorCode(Constants.ErrorCode.InvalidComment)
               .WithErrorCode(Constants.ErrorCode.InvalidComment);
        }
    }
}
