namespace Retail.Products.Api.Application.Interfaces
{
    public interface IListProductsQuery
    {
        Task<object> ListAsync(CancellationToken ct);
    }
}
