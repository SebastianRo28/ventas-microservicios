namespace Retail.Purchases.Api.Application.Interfaces
{
    public interface IAuthHeaderAccessor
    {
        string? GetAuthorizationHeader();
    }
}
