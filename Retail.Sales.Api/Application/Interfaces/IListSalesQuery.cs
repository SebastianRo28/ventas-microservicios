namespace Retail.Sales.Api.Application.Interfaces
{
    public interface IListSalesQuery
    {
        Task<object> ListAsync(CancellationToken ct);
    }
}
