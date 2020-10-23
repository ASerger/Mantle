using Domain = Mantle.DomainModels.Models;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;

namespace Mantle.Loot.Contracts
{
    public interface IGeneratedWeaponLoot
    {
        Task<Domain.GeneratedWeapon> GetByIdAsync(int id);
        Task<IEnumerable<Domain.GeneratedWeapon>> GetAllReadOnlyAsync();
    }
}
