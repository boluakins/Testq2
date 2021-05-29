namespace CardDetails.API.DTOs
{
    public class VerifyEndpointResponse<T>
    {
        public bool Success { get; set; }
        public T Payload { get; set; }

    }
}
