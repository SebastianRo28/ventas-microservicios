using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retail.Movements.Api.Application.Interfaces;

namespace Retail.Movements.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KardexController : ControllerBase
    {
        private readonly IListKardexQuery _list;

        public KardexController(IListKardexQuery list) => _list = list;

        [HttpGet("list")]
        public async Task<IActionResult> List(CancellationToken ct)
        {
            var data = await _list.ListAsync(ct);
            return Ok(data);
        }
    }
}
