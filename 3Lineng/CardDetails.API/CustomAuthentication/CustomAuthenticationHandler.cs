using CardDetails.API.Commons;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CardDetails.API.CustomAuthentication
{
    public class CustomAuthenticationSchemeOptions
        : AuthenticationSchemeOptions
    { }
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthenticationSchemeOptions>
    {
        private readonly IConfiguration configuration;
        private string failureReason = "Invalid Message Request";

        public CustomAuthenticationHandler(
        IOptionsMonitor<CustomAuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IConfiguration configuration)
        : base(options, logger, encoder, clock)
        {
            this.configuration = configuration;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // verify if request contains the required header keys
            if (!Request.Headers.ContainsKey("appKey") || !Request.Headers.ContainsKey("timeStamp") || !Request.Headers.ContainsKey("authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail(failureReason));
            }

            var authorization = Request.Headers["authorization"].ToString();

            // verify if token can be extracted from authorization string
            if (!authorization.StartsWith("3line ", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.Fail(failureReason));
            }
            var token = authorization.Substring("3line".Length).Trim();

            var appKeyRequest = Request.Headers["appkey"].ToString();
            var timeStamp = Request.Headers["timeStamp"].ToString();

            var appKey = configuration["HeaderValues:AppKey"];

            //verify if appKey is correct
            if (appKeyRequest == appKey)
            {
                var hash = Utilities.GetHash(appKeyRequest + timeStamp);

                //compare hash
                if (token == hash)
                {
                    // generate claimsIdentity on the name of the sheme
                    var claimsIdentity = new ClaimsIdentity(Scheme.Name);
                    var ticket = new AuthenticationTicket(
                            new ClaimsPrincipal(claimsIdentity), Scheme.Name);
                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
                failureReason = "Invalid authorization key";
                return Task.FromResult(AuthenticateResult.Fail(failureReason));
            }
            return Task.FromResult(AuthenticateResult.Fail(failureReason));
        }

        // override this method so as to display failure message
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 401;
            if (failureReason != null)
            {
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = failureReason;
            }
            return Task.CompletedTask;
        }
    }
}
