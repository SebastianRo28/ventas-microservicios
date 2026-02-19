using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.BuildingBlocks.Dtos
{
    public class PurchaseDtos
    {
        public sealed record PurchaseItemDto(int Id_producto, int Cantidad, decimal Precio);

        public sealed record PurchaseCreateDto(List<PurchaseItemDto> Items);

        public sealed record PurchaseCabDto(int Id_CompraCab, DateTime FecRegistro, decimal SubTotal, decimal Igv, decimal Total);
    }
}
