using System;
using System.Collections.Generic;
using Models.Entity;

namespace Services.Weapon
{
    public interface IWeaponService
    {
        WeaponEntity CurrentWeaponEntity { get; }
        IReadOnlyList<WeaponEntity> EquippedWeapons { get; }
        event Action WeaponChanged;
        void SelectWeapon(int id);
    }
}