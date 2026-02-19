using Retail.Products.Api.Application.Interfaces;
using static Retail.BuildingBlocks.Dtos.ProductDtos;
using System.Diagnostics;

namespace Retail.Products.Api.Application.Decorators
{
    public class UpdateProductLoggingDecorator : IUpdateProductFacade
    {
        private readonly IUpdateProductFacade _inner;
        private readonly ILogger<UpdateProductLoggingDecorator> _logger;

        public UpdateProductLoggingDecorator(
        IUpdateProductFacade inner,
        ILogger<UpdateProductLoggingDecorator> logger)
        {
            _inner = inner;
            _logger = logger;
        }

        public async Task<bool> UpdateAsync(ProductUpdateDto dto, CancellationToken ct)
        {
            var sw = Stopwatch.StartNew();

            try
            {
                _logger.LogInformation(
                    "Iniciando UpdateProduct. Id={Id}",
                    dto.Id_producto
                );

                var result = await _inner.UpdateAsync(dto, ct);

                if (result)
                {
                    _logger.LogInformation(
                        "Producto actualizado correctamente. Id={Id}. ElapsedMs={Ms}",
                        dto.Id_producto,
                        sw.ElapsedMilliseconds
                    );
                }
                else
                {
                    _logger.LogWarning(
                        "Producto no encontrado para actualizar. Id={Id}. ElapsedMs={Ms}",
                        dto.Id_producto,
                        sw.ElapsedMilliseconds
                    );
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error al actualizar producto. Id={Id}. ElapsedMs={Ms}",
                    dto.Id_producto,
                    sw.ElapsedMilliseconds
                );

                throw;
            }
        }
    }
}
