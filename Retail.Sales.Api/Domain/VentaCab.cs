namespace Retail.Sales.Api.Domain
{
    public class VentaCab
    {
        public int Id_VentaCab { get; set; }
        public DateTime FecRegistro { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }

        public List<VentaDet> Detalles { get; set; } = new();
    }
}
