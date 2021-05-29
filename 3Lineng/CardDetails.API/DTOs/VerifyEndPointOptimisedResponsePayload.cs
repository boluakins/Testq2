namespace CardDetails.API.DTOs
{
    public class VerifyEndPointOptimisedResponsePayload
    {
        public string CardNumber { get; set; }
        public bool IsValid { get; set; }
        public string Scheme { get; set; }
        public string Type { get; set; }
        public string Bank { get; set; }
    }
}
