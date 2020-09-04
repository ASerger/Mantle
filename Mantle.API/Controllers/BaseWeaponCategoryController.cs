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
    public class BaseWeaponCategoryController : ControllerBase
    {
        private IBaseWeaponCategoryLoot _baseWeaponCategoryLoot;
        private readonly ILogger<BaseWeaponCategoryController> _logger;

        public BaseWeaponCategoryController(IBaseWeaponCategoryLoot baseWeaponCategoryLoot,
            ILogger<BaseWeaponCategoryController> logger)
        {
            _baseWeaponCategoryLoot = baseWeaponCategoryLoot;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(List<BaseWeaponCategory>))]
        [AllowAnonymous]
        public async Task<IEnumerable<BaseWeaponCategory>> Get()
        {
            var data = await _baseWeaponCategoryLoot.GetAllAsync();
            return data;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseWeaponCategory))]
        [AllowAnonymous]
        public async Task<BaseWeaponCategory> GetById(int id)
        {
            var data = await _baseWeaponCategoryLoot.GetByIdAsync(id);
            return data;
        }
    }
}