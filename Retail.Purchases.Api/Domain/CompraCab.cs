namespace Retail.Purchases.Api.Domain
{
    public class CompraCab
    {
        public int Id_CompraCab { get; set; }
        public DateTime FecRegistro { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }

        // Navegación EF
        public List<CompraDet> Detalles { get; set; } = new();
    }
}
