using static Retail.BuildingBlocks.Dtos.PurchaseDtos;

namespace Retail.Purchases.Api.Application.Interfaces
{
    public interface IRegisterPurchaseFacade
    {
        Task<int> RegisterAsync(PurchaseCreateDto dto, CancellationToken ct);
    }
}
