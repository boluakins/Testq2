using System.Collections.Generic;

namespace CardDetails.API.DTOs
{
    public class StatsEndpointResponse
    {
        public bool Success { get; set; }
        public int Start { get; set; }
        public int Limit { get; set; }
        public int Size { get; set; }
        public Dictionary<string, int> Payload { get; set; }
    }
}
