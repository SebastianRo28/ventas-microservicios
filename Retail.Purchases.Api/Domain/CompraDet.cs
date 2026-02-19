using System.Text.Json.Serialization;

namespace Retail.Purchases.Api.Domain
{
    public class CompraDet
    {
        public int Id_CompraDet { get; set; }
        public int Id_CompraCab { get; set; }
        public int Id_producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Sub_Total { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }

        [JsonIgnore]
        public CompraCab CompraCab { get; set; } = default!;
    }
}
