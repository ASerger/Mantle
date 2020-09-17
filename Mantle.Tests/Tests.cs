using Microsoft.Extensions.Logging;
using Mantle.DataModels.Models;
using Mantle.Loot;
using Mantle.Loot.Contracts.Mappers;
using Mantle.Repository.Contracts;
using Moq;
using NUnit.Framework;

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

        [Test]
        public void Test1()
        {
            var domain = _baseWeaponCategoryBusiness.GetByIdAsync(1);
            _mockBWCRepo.Verify(f => f.GetByIdAsync(1));
        }
    }
}