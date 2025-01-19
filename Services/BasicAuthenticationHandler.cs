//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Options;
//using System.Net.Sockets;
//using System.Runtime.CompilerServices;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Encodings.Web;

//namespace PelatihanKe2.Services
//{
//    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        public readonly IConfiguration _Configuration;

//        public BasicAuthenticationHandler(
//            IOptionsMonitor<AuthenticationSchemeOptions> options,
//            ILoggerFactory logger,
//            UrlEncoder encoder,
//            ISystemClock clock,
//            IConfiguration configuration) : base(options, logger, encoder, clock)
//        {
//            _Configuration = configuration;
//        }

//        protected override async Task<AuthenticateResult> HandlerAuthenticateAsync()
//        {
//            if (!Request.Headers.ContainsKey("Authorization"))
//            {
//                return AuthenticateResult.Fail("Missing Authorization Header");
//            }

//            try
//            {
//                var authHeader = Request.Headers["Authorization"].ToString();
//                if (!authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
//                {
//                    return AuthenticateResult.Fail("Invalid Authorization Header");
//                }

//                var encodedCredentials = authHeader["Basic ".Length..].Trim();
//                var dencodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
//                var parts = dencodedCredentials.Split(':', 2);

//                if (parts.Length != 2)
//                {
//                    return AuthenticateResult.Fail("Invalid Basic Authorization Format");
//                }

//                var username = parts[0];
//                var password = parts[1];

//                if(!IsAuthorized(username, password))
//                {
//                    return AuthenticateResult.Fail("Invalid username or password");
//                }

//                var claims = new[] { new Claim(ClaimTypes.Name, username) };
//                var identity = new ClaimsIdentity(claims, Scheme.Name);
//                var principal = new ClaimsPrincipal(identity);
//                var ticket = new AuthenticationTicket(principal, Scheme.Name);

//                return AuthenticateResult.Success(ticket);
//            }
//            catch (Exception)
//            {
//                return AuthenticateResult.Fail("Error");
//            }

//        }
//            private bool IsAuthorized(string username, string password)
//            {
//                var userAuth = _Configuration["UsernameAuth"];
//                var passAuth = _Configuration["PasswordAuth"];

//                return username == userAuth && password == passAuth;
//            }

//    }
//}
