using Microsoft.EntityFrameworkCore;
using Retail.Purchases.Api.Application.Interfaces;
using Retail.Purchases.Api.Infrastructure;

namespace Retail.Purchases.Api.Application.Facades
{
    public class ListPurchasesQuery : IListPurchasesQuery
    {
        private readonly PurchasesDbContext _db;
        public ListPurchasesQuery(PurchasesDbContext db) => _db = db;

        public async Task<object> ListAsync(CancellationToken ct)
        {
            var compras = await _db.CompraCab
                .Include(c => c.Detalles)
                .OrderByDescending(c => c.Id_CompraCab)
                .ToListAsync(ct);

            return compras;
        }
    }
}
