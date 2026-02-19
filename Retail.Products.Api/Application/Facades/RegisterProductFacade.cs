using Retail.Products.Api.Application.Interfaces;
using Retail.Products.Api.Domain;
using Retail.Products.Api.Infrastructure;
using static Retail.BuildingBlocks.Dtos.ProductDtos;

namespace Retail.Products.Api.Application.Facades
{
    public class RegisterProductFacade : IRegisterProductFacade
    {
        private readonly ProductsDbContext _db;
        public RegisterProductFacade(ProductsDbContext db) => _db = db;

        public async Task<int> RegisterAsync(ProductCreateDto dto, CancellationToken ct)
        {
            var entity = new Producto
            {
                Nombre_producto = dto.Nombre_producto,
                NroLote = dto.NroLote,
                Costo = dto.Costo,
                PrecioVenta = dto.PrecioVenta,
                Fec_registro = DateTime.UtcNow
            };

            _db.Productos.Add(entity);
            await _db.SaveChangesAsync(ct);

            return entity.Id_producto;
        }
    }
}
