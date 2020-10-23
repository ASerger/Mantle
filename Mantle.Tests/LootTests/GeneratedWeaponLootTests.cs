using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;
using Mantle.Loot.Contracts.Mappers;
using Mantle.Loot.Implementations;
using Mantle.Loot.Mappers;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using Mantle.Loot.Contracts;

namespace Mantle.Tests.LootTests
{
    [TestFixture]
    public class GeneratedWeaponLootTests
    {
        private IGeneratedWeaponLoot _generatedWeaponLoot;
        private Mock<IBaseMapper<Data.GeneratedWeapon, Domain.GeneratedWeapon>> _mockMapper;
        private Mock<IGeneratedWeaponRepository> _mockRepo;
        private Mock<ILogger<GeneratedWeaponLoot>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IGeneratedWeaponRepository>();
            _mockLogger = new Mock<ILogger<GeneratedWeaponLoot>>();
            _mockMapper = new Mock<IBaseMapper<Data.GeneratedWeapon, Domain.GeneratedWeapon>>();
            _generatedWeaponLoot = new GeneratedWeaponLoot(_mockRepo.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllGeneratedWeapons_VerifyRepo_GetAllReadOnlyAsync()
        {
            var domain = await _generatedWeaponLoot.GetAllReadOnlyAsync();

            _mockRepo.Verify(f => f.GetAllReadOnlyAsync());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public async Task GetByIdAsync_VerifyRepo_UtilizesInput(int inputValue)
        {
            var domain = await _generatedWeaponLoot.GetByIdAsync(inputValue);

            _mockRepo.Verify(f => f.GetByIdAsync(inputValue));
        }
    }
}
