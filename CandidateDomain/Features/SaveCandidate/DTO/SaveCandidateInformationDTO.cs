namespace CandidateDomain.Features.SaveCandidate.DTO
{
    public class SaveCandidateInformationDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? TimeInterval { get; set; }
        public string? LinkedInProfileURL { get; set; }
        public string? GitHubURL { get; set; }
        public string Comment { get; set; }
    }
}
