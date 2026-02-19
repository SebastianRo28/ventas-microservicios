using Retail.Purchases.Api.Application.Interfaces;

namespace Retail.Purchases.Api.Application.Auth
{
    public class AuthHeaderAccessor : IAuthHeaderAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthHeaderAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetAuthorizationHeader()
            => _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
    }
}
