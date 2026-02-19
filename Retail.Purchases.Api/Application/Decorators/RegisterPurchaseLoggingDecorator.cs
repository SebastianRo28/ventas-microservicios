using Retail.Purchases.Api.Application.Interfaces;
using static Retail.BuildingBlocks.Dtos.PurchaseDtos;
using System.Diagnostics;

namespace Retail.Purchases.Api.Application.Decorators
{
    public class RegisterPurchaseLoggingDecorator : IRegisterPurchaseFacade
    {
        private readonly IRegisterPurchaseFacade _inner;
        private readonly ILogger<RegisterPurchaseLoggingDecorator> _logger;

        public RegisterPurchaseLoggingDecorator(IRegisterPurchaseFacade inner, ILogger<RegisterPurchaseLoggingDecorator> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<int> RegisterAsync(PurchaseCreateDto dto, CancellationToken ct)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                _logger.LogInformation("Iniciando RegisterPurchase. Items={Count}", dto.Items?.Count ?? 0);
                var id = await _inner.RegisterAsync(dto, ct);
                _logger.LogInformation("Compra registrada OK. Id={Id}. ElapsedMs={Ms}", id, sw.ElapsedMilliseconds);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en RegisterPurchase. ElapsedMs={Ms}", sw.ElapsedMilliseconds);
                throw;
            }
        }
    }
}
