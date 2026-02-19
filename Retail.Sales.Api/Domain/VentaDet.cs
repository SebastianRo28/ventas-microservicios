using System.Text.Json.Serialization;

namespace Retail.Sales.Api.Domain
{
    public class VentaDet
    {
        public int Id_VentaDet { get; set; }
        public int Id_VentaCab { get; set; }
        public int Id_producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Sub_Total { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        [JsonIgnore]
        public VentaCab VentaCab { get; set; } = default!;
    }
}
