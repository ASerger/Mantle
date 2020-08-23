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
    /// <summary>
    /// Template controller round 1
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class EffectClassController : ControllerBase
    {
        private IEffectClassLoot _effectClassLoot;
        private readonly ILogger<EffectClassController> _logger;

        public EffectClassController(IEffectClassLoot effectClassLoot,
            ILogger<EffectClassController> logger)
        {
            _effectClassLoot = effectClassLoot;
            _logger = logger;
        }

        /// <summary>
        /// Retrieve all effects from DB
        /// </summary>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EffectClass>))]
        [AllowAnonymous]
        public async Task<IEnumerable<EffectClass>> Get()
        {
            return await _effectClassLoot.GetAllAsync();
        }

        /// <summary>
        /// Retrive a single record from the EffectClass table
        /// </summary>
        /// <param name="id">[required] Primary Key</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EffectClass))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id = 0)
        {
            if (id == 0) return BadRequest();
            var data = await _effectClassLoot.GetByIdAsync(id);

            // OK(null) produces a 204 no content result which is good
            return Ok(data);
        }
    }
}
