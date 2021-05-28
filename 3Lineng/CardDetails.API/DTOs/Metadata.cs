using System;
using System.ComponentModel.DataAnnotations;

namespace CardDetails.API.DTOs
{
    public class Metadata
    {

        public int Start { get; set; } = 1;

        [Range(1, 10)]
        public int Limit { get; set; } = 3;
    }
}
