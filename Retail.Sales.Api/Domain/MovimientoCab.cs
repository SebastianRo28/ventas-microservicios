namespace Retail.Sales.Api.Domain
{
    public class MovimientoCab
    {
        public int Id_MovimientoCab { get; set; }
        public DateTime Fec_registro { get; set; }
        public int Id_TipoMovimiento { get; set; } // 2 = Salida
        public int Id_DocumentoOrigen { get; set; }

        public List<MovimientoDet> Detalles { get; set; } = new();
    }
}
