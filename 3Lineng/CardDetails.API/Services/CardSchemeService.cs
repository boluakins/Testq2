using CardDetails.API.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CardDetails.API.Services
{
    public class CardSchemeService : ICardSchemeService
    {

        /// <summary>
        ///   Verifies the details of a card
        /// </summary>
        /// <param name="cardNumber"></param>
        public VerifyEndpointResponse Verify(string cardNumber)
        {
            // retrieves details of the card from the database if card exists
            // data transfer to dto
            var data = new VerifyEndpointResponse
            {
                Success = true,
                Payload = new VerifyResponseEndpointPayload
                {
                    Scheme = "visa",
                    Type = " debit",
                    Bank = "UBS"
                }
            };
            return data;
        }

        /// <summary>
        ///  Gets the list of hit counts of cards
        /// </summary>
        /// <param name="metadata">metadata of the request </param>
        public StatsEndpointResponse Stats(Metadata metadata)
        {
            // retrieves data from the database
            // data transfer to dto

            var data = new StatsEndpointResponse
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
            return data;
        }
    }
}
