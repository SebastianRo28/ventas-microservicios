using Retail.Movements.Api.Application.Interfaces;
using Retail.Movements.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Retail.Movements.Api.Application.Facades
{
    public class ListKardexQuery : IListKardexQuery
    {
        private readonly MovementsDbContext _db;
        public ListKardexQuery(MovementsDbContext db) => _db = db;

        public async Task<object> ListAsync(CancellationToken ct)
        {
            var kardex = await (
                from md in _db.MovimientoDet
                join mc in _db.MovimientoCab on md.Id_movimientocab equals mc.Id_MovimientoCab
                join p in _db.Productos on md.Id_Producto equals p.Id_producto
                orderby mc.Fec_registro descending
                select new
                {
                    mc.Id_MovimientoCab,
                    mc.Fec_registro,
                    mc.Id_TipoMovimiento,
                    mc.Id_DocumentoOrigen,
                    md.Id_MovimientoDet,
                    md.Id_Producto,
                    p.Nombre_producto,
                    p.NroLote,
                    p.PrecioVenta,
                    p.Costo,
                    md.Cantidad,
                    Entrada = mc.Id_TipoMovimiento == 1 ? md.Cantidad : 0,
                    Salida = mc.Id_TipoMovimiento == 2 ? md.Cantidad : 0
                }
            ).ToListAsync(ct);

            return kardex;
        }
    }
}
