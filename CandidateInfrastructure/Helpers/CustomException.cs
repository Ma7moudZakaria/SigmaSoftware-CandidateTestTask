namespace CandidateInfrastructure.Helpers
{
    public class CustomException : Exception
    {
        public int Code;
        public object Errors;

        public CustomException(int code, string message, object Errors) : base(message)
        {
            this.Code = code;
            this.Errors = Errors;
        }
    }
}
