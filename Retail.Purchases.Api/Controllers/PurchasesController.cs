using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retail.Purchases.Api.Application.Interfaces;
using static Retail.BuildingBlocks.Dtos.PurchaseDtos;

namespace Retail.Purchases.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchasesController : ControllerBase
    {
        private readonly IRegisterPurchaseFacade _facade;
        private readonly IListPurchasesQuery _list;

        public PurchasesController(IRegisterPurchaseFacade facade, IListPurchasesQuery list)
        {
            _facade = facade;
            _list = list;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PurchaseCreateDto dto, CancellationToken ct)
        {
            var id = await _facade.RegisterAsync(dto, ct);
            return Ok(new { Id_CompraCab = id });
        }

        [HttpGet("list")]
        public async Task<IActionResult> List(CancellationToken ct)
        {
            var data = await _list.ListAsync(ct);
            return Ok(data);
        }
    }
}
