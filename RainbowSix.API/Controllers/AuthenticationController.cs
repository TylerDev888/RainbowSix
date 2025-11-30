using Microsoft.AspNetCore.Mvc;
using RainbowSix.Common;
using RainbowSix.Common.Interfaces;
using RainbowSix.WebClient.Interfaces;
using System.Threading.Tasks;

namespace RainbowSix.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUbisoftSessionStore _sessionStore;
        private readonly IHttpConnectionLogger _logger;

        public AuthenticationController(
            IUbisoftSessionStore sessionStore,
            IHttpConnectionLogger logger)
        {
            _sessionStore = sessionStore;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var session = _sessionStore.LoadSessionByUsername(request.Username);

            if (session is null || session.IsSessionExpired())
            {
                using (var connection = new UbisoftConnection(_logger, _sessionStore))
                    session = await connection.LoginAsync(request.Username, request.Password);

                if(session is null)
                    return BadRequest(new { message = "Login Failed", errorCode = "AUTH_FAILED_SESSION_NULL" });

                if(string.IsNullOrEmpty(request.Username))
                    return BadRequest(new { message = "Login Failed", errorCode = "AUTH_FAILED_USERNAME_NOT_FOUND" });

                if(string.IsNullOrEmpty(request.Password))
                    return BadRequest(new { message = "Login Failed", errorCode = "AUTH_FAILED_PASSWORD_NOT_FOUND" });

                _sessionStore.DeleteSession(request.Username);
                _sessionStore.SaveSession(request.Username, session);

                if (session.Is2faRequired())
                    return Ok(new { message = "2FA Required", session });
            }

            if (string.IsNullOrEmpty(session?.Ticket))
            {
                _sessionStore.DeleteSession(request.Username);
                return BadRequest(new { message = "Login Failed", errorCode = "AUTH_FAILED" });
            }

            return Ok(new { message = "Authenticated", session });
        }

        [HttpPost("2fa")]
        public async Task<IActionResult> TwoFactorAuthentication([FromBody] TwoFactorAuthRequest request)
        {
            IUbisoftSession? session = _sessionStore.LoadSessionByUsername(request.Username);

            try
            {
                using(var connection = new UbisoftConnection(_logger, _sessionStore))
                    session = await connection.CompleteTwoFactorAsync(session!.TwoFactorAuthenticationTicket!, request.Code!);
            }
            catch
            {
                _sessionStore.DeleteSession(request.Username);
                return Unauthorized("2fa failed.");
            }

            if (session is not null && session.SessionId is not null)
            {
                _sessionStore.SaveSession(request.Username, session);
            }
            else
            {
                _sessionStore.DeleteSession(request.Username);
                return BadRequest(new { message = "2FA Validation Failed", errorCode = "AUTH_2FA_FAILED" });
            }

            return Ok(new { message = "Authenticated", session });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
    public class  TwoFactorAuthRequest 
    {
        public string Username { get; set; } = default!;
        public string SessionId { get; set; } = default!;
        public string Code { get; set; } = default!;    
    }
}
