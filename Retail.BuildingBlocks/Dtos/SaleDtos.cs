using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.BuildingBlocks.Dtos
{
    public class SaleDtos
    {
        public sealed record SaleItemDto(int Id_producto, int Cantidad, decimal Precio);

        public sealed record SaleCreateDto(List<SaleItemDto> Items);

        public sealed record SaleCabDto(int Id_VentaCab, DateTime FecRegistro, decimal SubTotal, decimal Igv, decimal Total);
    }
}
