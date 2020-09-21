using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mantle.DomainModels.Models;
using Mantle.Loot.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
        //TODO Note Logger in this app really only needs used for errors.
        //  Additionally I should have a middleware that manages the injection and I just access that anytime I need it to force certain parameters to be passed to errors (Exception details, user, request, etc)
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
            _logger.LogInformation($"User: {User.Claims.ElementAtOrDefault(4)} Request URL: {Request.GetDisplayUrl()}");
            var domain = await _baseWeaponCategoryLoot.GetAllAsync();
            return domain;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseWeaponCategory))]
        [AllowAnonymous]
        public async Task<BaseWeaponCategory> GetById(int id)
        {
            _logger.LogInformation($"User: {User.Claims.ElementAtOrDefault(4)} Request URL: {Request.GetDisplayUrl()}");
            var domain = await _baseWeaponCategoryLoot.GetByIdAsync(id);
            return domain;
        }
    }
}