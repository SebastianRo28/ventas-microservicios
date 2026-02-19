namespace Retail.Movements.Api.Application.Interfaces
{
    public interface IListKardexQuery
    {
        Task<object> ListAsync(CancellationToken ct);
    }
}
