using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class WeaponClassController : ControllerBase
    {
        private IWeaponClassLoot _weaponClassLoot;
        private readonly ILogger<WeaponClassController> _logger;

        public WeaponClassController(IWeaponClassLoot weaponClassLoot,
            ILogger<WeaponClassController> logger)
        {
            _weaponClassLoot = weaponClassLoot;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<WeaponClass>))]
        [AllowAnonymous]
        public async Task<IEnumerable<WeaponClass>> Get()
        {
            return await _weaponClassLoot.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WeaponClass))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id = 0)
        {
            if (id == 0) return BadRequest();
            var data = await _weaponClassLoot.GetByIdAsync(id);

            // OK(null) produces a 204 no content result which is good
            return Ok(data);
        }
    }
}
