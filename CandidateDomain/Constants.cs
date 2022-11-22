namespace CandidateDomain
{
    public static class Constants
    {
        public static class ErrorCode
        {
            public const string InvalidFirstName = "invalid_firstName";
            public const string InvalidLastName = "invalid_lastName";
            public const string InvalidEmail = "invalid_email";
            public const string InvalidComment = "invalid_comment";
        }

        public static class HttpCustomErrorCode
        {
            public const int ValidationError = 600;
            public const int CustomError = 601;
            public const int InvalidToken = 602;
            public const int CustomCandidateError = 400;
        }
    }
}
