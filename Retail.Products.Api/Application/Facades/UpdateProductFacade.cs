using Microsoft.EntityFrameworkCore;
using Retail.Products.Api.Application.Interfaces;
using Retail.Products.Api.Infrastructure;
using static Retail.BuildingBlocks.Dtos.ProductDtos;

namespace Retail.Products.Api.Application.Facades
{
    public class UpdateProductFacade : IUpdateProductFacade
    {
        private readonly ProductsDbContext _db;
        public UpdateProductFacade(ProductsDbContext db) => _db = db;

        public async Task<bool> UpdateAsync(ProductUpdateDto dto, CancellationToken ct)
        {
            var entity = await _db.Productos.FirstOrDefaultAsync(p => p.Id_producto == dto.Id_producto, ct);
            if (entity is null) return false;

            entity.Nombre_producto = dto.Nombre_producto;
            entity.NroLote = dto.NroLote;
            entity.Costo = dto.Costo;
            entity.PrecioVenta = dto.PrecioVenta;

            await _db.SaveChangesAsync(ct);
            return true;
        }
    }
}
