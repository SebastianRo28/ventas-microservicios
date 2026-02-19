using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retail.Sales.Api.Application.Interfaces;
using static Retail.BuildingBlocks.Dtos.SaleDtos;

namespace Retail.Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly IRegisterSaleFacade _register;
        private readonly IListSalesQuery _list;

        public SalesController(IRegisterSaleFacade register, IListSalesQuery list)
        {
            _register = register;
            _list = list;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SaleCreateDto dto, CancellationToken ct)
        {
            var id = await _register.RegisterAsync(dto, ct);
            return Ok(new { Id_VentaCab = id });
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(CancellationToken ct)
        {
            var data = await _list.ListAsync(ct);
            return Ok(data);
        }
    }
}
