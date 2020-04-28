using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<EffectClass> Get()
        {
            return _effectClassLoot.GetAll();
        }

        /// <summary>
        /// Retrive a single record from the EffectClass table
        /// </summary>
        /// <param name="id">[required] Primary Key</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id = 0)
        {
            if (id == 0) return BadRequest();
            var data = _effectClassLoot.GetById(id);
            return Ok(data);
        }
    }
}
