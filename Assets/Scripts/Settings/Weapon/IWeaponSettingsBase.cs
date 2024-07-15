using System.Collections.Generic;

namespace Settings.Weapon
{
    public interface IWeaponSettingsBase
    {
        IReadOnlyList<WeaponSettings> WeaponSettings { get; }
        WeaponSettings GetWeaponById(int id);
    }
}