namespace Retail.Movements.Api.Domain
{
    public class Producto
    {
        public int Id_producto { get; set; }
        public string Nombre_producto { get; set; } = default!;
        public string NroLote { get; set; } = default!;
        public decimal PrecioVenta { get; set; } = default!;
        public decimal Costo { get; set; } = default!;
    }
}
