using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;
using Mantle.Loot.Contracts.Mappers;
using Mantle.Loot.Implementations;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Mantle.Loot.Contracts;

namespace Mantle.Tests.LootTests
{
    [TestFixture]
    public class BaseWeaponCategoryBusinessTests
    {
        private IBaseWeaponCategoryLoot _baseWeaponCategoryBusiness;
        private Mock<IBaseWeaponCategoryRepository> _mockBWCRepo;
        private Mock<IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>> _mockMapper;
        private Mock<ILogger<BaseWeaponCategoryLoot>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockBWCRepo = new Mock<IBaseWeaponCategoryRepository>();
            _mockMapper = new Mock<IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>>();
            _mockLogger = new Mock<ILogger<BaseWeaponCategoryLoot>>();
            _baseWeaponCategoryBusiness = new BaseWeaponCategoryLoot(_mockBWCRepo.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public async Task GetByIdAsync_TestValue_MockUtilizesTestValue(int testValue)
        {
            var domain = await _baseWeaponCategoryBusiness.GetByIdAsync(testValue);

            _mockBWCRepo.Verify(f => f.GetByIdAsync(testValue));
        }
    }
}