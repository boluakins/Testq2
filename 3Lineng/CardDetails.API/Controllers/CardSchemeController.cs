using CardDetails.API.DTOs;
using CardDetails.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CardDetails.API.Controllers
{
    [ApiController]
    [Route("card-scheme")]
    [Authorize]
    public class CardSchemeController : ControllerBase
    {
        private readonly ICardSchemeService cardSchemeService;

        public CardSchemeController(IServiceProvider service)
        {
            cardSchemeService = service.GetRequiredService<ICardSchemeService>();
        }
        [HttpGet("verify/{cardNumber}")]
        public IActionResult Verify([FromRoute] string cardNumber)
        {
            var result = cardSchemeService.Verify(cardNumber);
            return Ok(result);
        }

        [HttpGet("stats")]
        public IActionResult Stats([FromQuery] Metadata metadata)
        {
            var result = cardSchemeService.Stats(metadata);
            return Ok(result);
        }
    }
}
