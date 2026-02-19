using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.BuildingBlocks.Dtos
{
    public class ProductDtos
    {
        public sealed record ProductCreateDto(string Nombre_producto, string NroLote, decimal Costo, decimal PrecioVenta);
        public sealed record ProductUpdateDto(int Id_producto, string Nombre_producto, string NroLote, decimal Costo, decimal PrecioVenta);

        public sealed record ProductDto(
            int Id_producto,
            string Nombre_producto,
            string NroLote,
            DateTime Fec_registro,
            decimal Costo,
            decimal PrecioVenta
        );
    }

    
}
