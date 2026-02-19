namespace Retail.Purchases.Api.Application.Interfaces
{
    public interface IListPurchasesQuery
    {
        Task<object> ListAsync(CancellationToken ct);
    }
}
