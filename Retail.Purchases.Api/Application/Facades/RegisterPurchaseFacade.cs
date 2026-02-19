using Retail.Purchases.Api.Application.Interfaces;
using Retail.Purchases.Api.Domain;
using Retail.Purchases.Api.Infrastructure;
using static Retail.BuildingBlocks.Dtos.PurchaseDtos;

namespace Retail.Purchases.Api.Application.Facades
{
    public class RegisterPurchaseFacade : IRegisterPurchaseFacade
    {
        private readonly PurchasesDbContext _db;
        private readonly IProductsClient _productsClient;

        public RegisterPurchaseFacade(PurchasesDbContext db, IProductsClient productsClient)
        {
            _db = db;
            _productsClient = productsClient;
        }

        public async Task<int> RegisterAsync(PurchaseCreateDto dto, CancellationToken ct)
        {
            if (dto.Items is null || !dto.Items.Any())
                throw new InvalidOperationException("La compra debe tener items.");

            const decimal igvRate = 0.18m;

            var cab = new CompraCab
            {
                FecRegistro = DateTime.UtcNow
            };

            foreach (var item in dto.Items)
            {
                if (item.Cantidad <= 0) throw new InvalidOperationException("Cantidad inválida.");
                if (item.Precio <= 0) throw new InvalidOperationException("Precio inválido.");

                var sub = item.Cantidad * item.Precio;
                var igv = Math.Round(sub * igvRate, 2);
                var total = sub + igv;

                cab.Detalles.Add(new CompraDet
                {
                    Id_producto = item.Id_producto,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio,
                    Sub_Total = sub,
                    Igv = igv,
                    Total = total
                });
            }

            cab.SubTotal = cab.Detalles.Sum(d => d.Sub_Total);
            cab.Igv = cab.Detalles.Sum(d => d.Igv);
            cab.Total = cab.Detalles.Sum(d => d.Total);

            await using var trx = await _db.Database.BeginTransactionAsync(ct);

            _db.CompraCab.Add(cab);
            await _db.SaveChangesAsync(ct);

            var updates = dto.Items
            .GroupBy(i => i.Id_producto)
            .Select(g => g.Last());

            foreach (var item in dto.Items)
            {
                await _productsClient.UpdateCostAsync(item.Id_producto, item.Precio, ct);
            }

            var movimiento = new MovimientoCab
            {
                Fec_registro = DateTime.UtcNow,
                Id_TipoMovimiento = 1,
                Id_DocumentoOrigen = cab.Id_CompraCab
            };

            foreach (var d in cab.Detalles)
            {
                movimiento.Detalles.Add(new MovimientoDet
                {
                    Id_Producto = d.Id_producto,
                    Cantidad = d.Cantidad
                });
            }

            _db.MovimientoCab.Add(movimiento);
            await _db.SaveChangesAsync(ct);

            await trx.CommitAsync(ct);

            return cab.Id_CompraCab;
        }
    }
}
