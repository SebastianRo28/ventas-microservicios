using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Retail.Products.Api.Application.Facades;
using Retail.Products.Api.Application.Interfaces;
using Retail.Products.Api.Infrastructure;
using static Retail.BuildingBlocks.Dtos.ProductDtos;

namespace Retail.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IRegisterProductFacade _register;
        private readonly IUpdateProductFacade _update;
        private readonly IListProductsQuery _list;
        private readonly ProductsDbContext _db;

        public ProductsController(IRegisterProductFacade register, IUpdateProductFacade update, IListProductsQuery list, ProductsDbContext db)
        {
            _register = register;
            _update = update;
            _db = db;
            _list = list;
        }

        public sealed class ProductCostUpdateDto
        {
            public int Id_producto { get; set; }
            public decimal Costo { get; set; }
        }

        [HttpPut("update-cost")]
        public async Task<IActionResult> UpdateCost([FromBody] ProductCostUpdateDto dto, CancellationToken ct)
        {
            var product = await _db.Productos
                .FirstOrDefaultAsync(p => p.Id_producto == dto.Id_producto, ct);

            if (product is null)
                return NotFound(new { message = "Producto no existe." });

            product.Costo = dto.Costo;
            product.PrecioVenta = Math.Round(dto.Costo * 1.35m, 2);

            await _db.SaveChangesAsync(ct);

            return Ok(new
            {
                product.Id_producto,
                product.Costo,
                product.PrecioVenta
            });
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(CancellationToken ct)
        {
            var data = await _list.ListAsync(ct);
            return Ok(data);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ProductCreateDto dto, CancellationToken ct)
        {
            var id = await _register.RegisterAsync(dto, ct);
            return Ok(new { Id_producto = id });
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProductUpdateDto dto, CancellationToken ct)
        {
            var ok = await _update.UpdateAsync(dto, ct);
            return ok ? Ok(new { Updated = true }) : NotFound(new { Updated = false });
        }
    }
}
