using Retail.Purchases.Api.Application.Interfaces;
using System.Net.Http.Headers;

namespace Retail.Purchases.Api.Application.Clients
{
    public class ProductsClient : IProductsClient
    {
        private readonly HttpClient _http;
        private readonly IAuthHeaderAccessor _authHeader;

        public ProductsClient(HttpClient http, IAuthHeaderAccessor authHeader)
        {
            _http = http;
            _authHeader = authHeader;
        }

        public async Task UpdateCostAsync(int idProducto, decimal costo, CancellationToken ct)
        {
            var auth = _authHeader.GetAuthorizationHeader();
            if (!string.IsNullOrWhiteSpace(auth))
            {
                _http.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(auth);
            }
            var payload = new { Id_producto = idProducto, Costo = costo };

            var resp = await _http.PutAsJsonAsync("/api/Products/update-cost", payload, ct);

            if (!resp.IsSuccessStatusCode)
            {
                var body = await resp.Content.ReadAsStringAsync(ct);
                throw new InvalidOperationException($"No se pudo actualizar costo en Products.Api. Status={resp.StatusCode}. Body={body}");
            }
        }
    }
}
