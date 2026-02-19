using static Retail.BuildingBlocks.Dtos.ProductDtos;

namespace Retail.Products.Api.Application.Interfaces
{
    public interface IRegisterProductFacade
    {
        Task<int> RegisterAsync(ProductCreateDto dto, CancellationToken ct);
    }
}
