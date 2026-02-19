using static Retail.BuildingBlocks.Dtos.ProductDtos;

namespace Retail.Products.Api.Application.Interfaces
{
    public interface IUpdateProductFacade
    {
        Task<bool> UpdateAsync(ProductUpdateDto dto, CancellationToken ct);
    }
}
