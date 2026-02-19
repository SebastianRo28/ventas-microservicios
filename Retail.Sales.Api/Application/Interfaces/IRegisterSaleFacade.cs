using static Retail.BuildingBlocks.Dtos.SaleDtos;

namespace Retail.Sales.Api.Application.Interfaces
{
    public interface IRegisterSaleFacade
    {
        Task<int> RegisterAsync(SaleCreateDto dto, CancellationToken ct);
    }
}
