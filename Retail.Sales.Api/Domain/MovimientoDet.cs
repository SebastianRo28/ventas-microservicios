namespace Retail.Sales.Api.Domain
{
    public class MovimientoDet
    {
        public int Id_MovimientoDet { get; set; }
        public int Id_movimientocab { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }

        public MovimientoCab MovimientoCab { get; set; } = default!;
    }
}
