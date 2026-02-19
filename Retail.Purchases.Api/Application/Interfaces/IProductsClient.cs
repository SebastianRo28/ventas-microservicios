namespace Retail.Purchases.Api.Application.Interfaces
{
    public interface IProductsClient
    {
        Task UpdateCostAsync(int idProducto, decimal costo, CancellationToken ct);
    }
}
