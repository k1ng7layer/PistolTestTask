using System;
using Models.Entity;

namespace Services.Weapon
{
    public interface IWeaponService
    {
        WeaponEntity CurrentWeaponEntity { get; }
        WeaponEntity[] AvailableWeapons { get; }
        event Action WeaponChanged;
        void SetWeapon(WeaponEntity weaponEntity);
    }
}