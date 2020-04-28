using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantle.API.Controllers
{
    /// <summary>
    /// Template controller round 1
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IEnumerable<EffectClass>> Get()
        {
            return await _effectClassLoot.GetAll();
        }

        /// <summary>
        /// Retrive a single record from the EffectClass table
        /// </summary>
        /// <param name="id">[required] Primary Key</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id = 0)
        {
            if (id == 0) return BadRequest();
            var data = await _effectClassLoot.GetById(id);

            // OK(null) produces a 204 no content result which is good
            return Ok(data);
        }
    }
}
