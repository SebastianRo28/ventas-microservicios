using Retail.Sales.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Retail.Sales.Api.Infrastructure;

namespace Retail.Sales.Api.Application.Facades
{
    public class ListSalesQuery : IListSalesQuery
    {
        private readonly SalesDbContext _db;
        public ListSalesQuery(SalesDbContext db) => _db = db;

        public async Task<object> ListAsync(CancellationToken ct)
        {
            var ventas = await _db.VentaCab
                .Include(v => v.Detalles)
                .OrderByDescending(v => v.Id_VentaCab)
                .ToListAsync(ct);

            return ventas;
        }
    }
}
