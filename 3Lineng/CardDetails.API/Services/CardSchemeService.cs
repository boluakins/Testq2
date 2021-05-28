using CardDetails.API.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CardDetails.API.Services
{
    public class CardSchemeService : ICardSchemeService
    {
        public VerifyEndpointResponse Verify(string cardNumber)
        {
            var fetchedFromImaginaryRepo = new VerifyEndpointResponse
            {
                Success = true,
                Payload = new VerifyResponseEndpointPayload
                {
                    Scheme = "visa",
                    Type = " debit",
                    Bank = "UBS"
                }
            };
            return fetchedFromImaginaryRepo;
        }
        public StatsEndpointResponse Stats(Metadata metadata)
        {
            var fetchedFromImaginaryRepo = new StatsEndpointResponse
            {
                Success = true,
                Start = metadata.Start,
                Limit = metadata.Limit,
                Size = 133,
                Payload = new Dictionary<string, int>
                {
                    { "545423", 5},
                    { "679234", 4},
                    { "329802", 1}
                }
            };
            return fetchedFromImaginaryRepo;
        }
    }
}
