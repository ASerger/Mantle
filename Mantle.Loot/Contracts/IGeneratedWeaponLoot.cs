using Domain = Mantle.DomainModels.Models;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts
{
    public interface IGeneratedWeaponLoot
    {
        Task<Domain.GeneratedWeapon> GetByIdAsync(int id);
    }
}
