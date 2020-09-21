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
    public class BaseWeaponCategoryBusinessTests
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
        public async Task GetByIdAsync_TestValue_MockUtilizesTestValue(int testValue)
        {
            var domain = await _baseWeaponCategoryBusiness.GetByIdAsync(testValue);

            _mockBWCRepo.Verify(f => f.GetByIdAsync(testValue));
        }

        [Test]
        public async Task PostNewBaseWeaponCategoryWithExistingBases_MockUtilizesTestModel()
        {
            var bwcDomainModel = CreateNewDomainObject();
            var addRecord = await _baseWeaponCategoryBusiness.AddRecordAsync(bwcDomainModel);
            var dataModel = await _mockMapper.Object.MapDomainToDataAsync(bwcDomainModel);

            _mockBWCRepo.Verify(f => f.InsertRecordAsync(dataModel));
        }

        private static DomainModels.Models.BaseWeaponCategory CreateNewDomainObject()
        {
            return new DomainModels.Models.BaseWeaponCategory
            {
                BaseDamageTypeId = 1,
                BaseDiceId = 12,
                Cost = 2.5,
                Weight = 5,
                IsMartial = true,
                IsRange = false,
                WeaponCategory = "",
            };
        }
    }
}