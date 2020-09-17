using Microsoft.Extensions.Logging;
using Mantle.DataModels.Models;
using Mantle.Loot;
using Mantle.Loot.Contracts.Mappers;
using Mantle.Repository.Contracts;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Mantle.Tests
{
    [TestFixture]
    public class Tests
    {
        private BaseWeaponCategoryLoot _baseWeaponCategoryBusiness;
        private Mock<IBaseWeaponCategoryRepository<BaseWeaponCategory>> _mockBWCRepo;
        private Mock<IBaseMapper<BaseWeaponCategory, DomainModels.Models.BaseWeaponCategory>> _mockMapper;
        private Mock<ILogger<BaseWeaponCategoryLoot>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockBWCRepo = new Mock<IBaseWeaponCategoryRepository<BaseWeaponCategory>>();
            _mockMapper = new Mock<IBaseMapper<BaseWeaponCategory, DomainModels.Models.BaseWeaponCategory>>();
            _mockLogger = new Mock<ILogger<BaseWeaponCategoryLoot>>();
            _baseWeaponCategoryBusiness = new BaseWeaponCategoryLoot(_mockBWCRepo.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public async Task Test1(int testValue)
        {
            var domain = await _baseWeaponCategoryBusiness.GetByIdAsync(testValue);

            _mockBWCRepo.Verify(f => f.GetByIdAsync(testValue));
        }
    }
}