
using CardDetails.API.DTOs;

namespace CardDetails.API.Services
{
    public interface ICardSchemeService
    {
        VerifyEndpointResponse<VerifyResponseEndpointPayload> Verify(string cardNumber);
        StatsEndpointResponse Stats(Metadata metadata);
        VerifyEndpointResponse<VerifyEndPointOptimisedResponsePayload> VerifyOptimized(string cardNumber);
    }
}
