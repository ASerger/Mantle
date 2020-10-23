using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mantle.DomainModels.Models;
using Mantle.Loot.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Mantle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class GeneratedWeaponController : ControllerBase
    {
        private IGeneratedWeaponLoot _generatedWeaponLoot;
        private readonly ILogger<GeneratedWeaponController> _logger;

        public GeneratedWeaponController(IGeneratedWeaponLoot generatedWeaponLoot,
            ILogger<GeneratedWeaponController> logger)
        {
            _generatedWeaponLoot = generatedWeaponLoot;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GeneratedWeapon>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<IEnumerable<GeneratedWeapon>> GetAllAsync()
        {
            var domain = await _generatedWeaponLoot.GetAllReadOnlyAsync();
            return domain;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneratedWeapon))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [AllowAnonymous]
        public async Task<GeneratedWeapon> GetByIdAsync(int id)
        {
            var domain = await _generatedWeaponLoot.GetByIdAsync(id);
            return domain;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<GeneratedWeapon> GenerateWeaponAsync()
        {
            var domain = await _generatedWeaponLoot.RollNewRandomWeapon();
            return domain;
        }

        public async Task<IEnumerable<GeneratedWeapon>> GenerateWeaponsAsync(int?[] weaponCategoryIdsPreferred, int?[] effectIdsPreferred)
        {
            throw new NotImplementedException();
        }
    }
}
