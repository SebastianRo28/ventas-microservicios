using Retail.Sales.Api.Application.Interfaces;
using Retail.Sales.Api.Domain;
using Retail.Sales.Api.Infrastructure;
using Retail.BuildingBlocks.Dtos;
using static Retail.BuildingBlocks.Dtos.SaleDtos;

namespace Retail.Sales.Api.Application.Facades
{
    public class RegisterSaleFacade : IRegisterSaleFacade
    {
        private readonly SalesDbContext _db;

        public RegisterSaleFacade(SalesDbContext db) => _db = db;

        public async Task<int> RegisterAsync(SaleCreateDto dto, CancellationToken ct)
        {
            if (dto.Items is null || !dto.Items.Any())
                throw new InvalidOperationException("La venta debe tener items.");

            const decimal igvRate = 0.18m;

            var cab = new VentaCab { FecRegistro = DateTime.UtcNow };

            foreach (var item in dto.Items)
            {
                if (item.Cantidad <= 0) throw new InvalidOperationException("Cantidad inválida.");
                if (item.Precio <= 0) throw new InvalidOperationException("Precio inválido.");

                var sub = item.Cantidad * item.Precio;
                var igv = Math.Round(sub * igvRate, 2);
                var total = sub + igv;

                cab.Detalles.Add(new VentaDet
                {
                    Id_producto = item.Id_producto,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio,
                    Sub_Total = sub,
                    Igv = igv,
                    Total = total
                });
            }

            cab.SubTotal = cab.Detalles.Sum(x => x.Sub_Total);
            cab.Igv = cab.Detalles.Sum(x => x.Igv);
            cab.Total = cab.Detalles.Sum(x => x.Total);

            await using var trx = await _db.Database.BeginTransactionAsync(ct);

            _db.VentaCab.Add(cab);
            await _db.SaveChangesAsync(ct);

            // Movimiento Salida (2)
            var mov = new MovimientoCab
            {
                Fec_registro = DateTime.UtcNow,
                Id_TipoMovimiento = 2,
                Id_DocumentoOrigen = cab.Id_VentaCab
            };

            foreach (var d in cab.Detalles)
            {
                mov.Detalles.Add(new MovimientoDet
                {
                    Id_Producto = d.Id_producto,
                    Cantidad = d.Cantidad
                });
            }

            _db.MovimientoCab.Add(mov);
            await _db.SaveChangesAsync(ct);

            await trx.CommitAsync(ct);

            return cab.Id_VentaCab;
        }
    }
}
