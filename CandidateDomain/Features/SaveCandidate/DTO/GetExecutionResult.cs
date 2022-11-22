namespace CandidateDomain.Features.SaveCandidate.DTO
{
    public class GetExecutionResult
    {
        public Guid Id { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess
        {
            get
            {
                return string.IsNullOrEmpty(this.ErrorCode);
            }
        }
    }
}
