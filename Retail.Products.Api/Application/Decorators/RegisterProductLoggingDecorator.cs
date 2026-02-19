using Retail.Products.Api.Application.Interfaces;
using static Retail.BuildingBlocks.Dtos.SaleDtos;
using System.Diagnostics;
using static Retail.BuildingBlocks.Dtos.ProductDtos;

namespace Retail.Products.Api.Application.Decorators
{
    public class RegisterProductLoggingDecorator : IRegisterProductFacade
    {
        private readonly IRegisterProductFacade _inner;
        private readonly ILogger<RegisterProductLoggingDecorator> _logger;

        public RegisterProductLoggingDecorator(IRegisterProductFacade inner, ILogger<RegisterProductLoggingDecorator> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<int> RegisterAsync(ProductCreateDto dto, CancellationToken ct)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                _logger.LogInformation(
                    "Iniciando RegisterProduct. Nombre={Nombre}, Lote={Lote}",
                    dto.Nombre_producto,
                    dto.NroLote
                );

                var id = await _inner.RegisterAsync(dto, ct);

                _logger.LogInformation(
                    "Producto registrado correctamente. Id={Id}. ElapsedMs={Ms}",
                    id,
                    sw.ElapsedMilliseconds
                );

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al registrar producto. Nombre={Nombre}. ElapsedMs={Ms}",
                    dto.Nombre_producto,
                    sw.ElapsedMilliseconds
                );
                throw;
            }
        }
    }
}
