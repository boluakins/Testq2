
using CardDetails.API.DTOs;

namespace CardDetails.API.Services
{
    public interface ICardSchemeService
    {
        VerifyEndpointResponse Verify(string cardNumber);
        StatsEndpointResponse Stats(Metadata metadata);
    }
}
