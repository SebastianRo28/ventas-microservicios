using Retail.Sales.Api.Application.Interfaces;
using static Retail.BuildingBlocks.Dtos.SaleDtos;
using System.Diagnostics;

namespace Retail.Sales.Api.Application.Decorators
{
    public class RegisterSaleLoggingDecorator : IRegisterSaleFacade
    {
        private readonly IRegisterSaleFacade _inner;
        private readonly ILogger<RegisterSaleLoggingDecorator> _logger;

        public RegisterSaleLoggingDecorator(IRegisterSaleFacade inner, ILogger<RegisterSaleLoggingDecorator> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<int> RegisterAsync(SaleCreateDto dto, CancellationToken ct)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                _logger.LogInformation("Iniciando RegisterSale. Items={Count}", dto.Items?.Count ?? 0);
                var id = await _inner.RegisterAsync(dto, ct);
                _logger.LogInformation("Venta OK. Id={Id}. ElapsedMs={Ms}", id, sw.ElapsedMilliseconds);
                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error RegisterSale. ElapsedMs={Ms}", sw.ElapsedMilliseconds);
                throw;
            }
        }
    }
}
