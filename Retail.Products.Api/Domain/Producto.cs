namespace Retail.Products.Api.Domain
{
    public class Producto
    {
        public int Id_producto { get; set; }
        public string Nombre_producto { get; set; } = default!;
        public string NroLote { get; set; } = default!;
        public DateTime Fec_registro { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
