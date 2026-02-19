using Microsoft.EntityFrameworkCore;
using Retail.Products.Api.Application.Interfaces;
using Retail.Products.Api.Infrastructure;

namespace Retail.Products.Api.Application.Facades
{
    public class ListProductsQuery : IListProductsQuery
    {
        private readonly ProductsDbContext _db;
        public ListProductsQuery(ProductsDbContext db) => _db = db;

        public async Task<object> ListAsync(CancellationToken ct)
        {
            var productos = await _db.Productos
                .OrderByDescending(p => p.Id_producto)
                .ToListAsync(ct);

            return productos;
        }
    }
}
