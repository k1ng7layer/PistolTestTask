using System;
using System.Collections.Generic;
using Models.Entity;
using Settings.Weapon;

namespace Services.Weapon.Impl
{
    public class WeaponService : IWeaponService
    {
        private readonly IWeaponSettingsBase _weaponSettingsBase;
        private readonly List<WeaponEntity> _equippedWeapons = new();

        public WeaponService(IWeaponSettingsBase weaponSettingsBase)
        {
            _weaponSettingsBase = weaponSettingsBase;
        }
        
        public WeaponEntity CurrentWeaponEntity { get; private set; }
        public IReadOnlyList<WeaponEntity> EquippedWeapons => _equippedWeapons;
        public event Action WeaponChanged;

        public void Initialize()
        {
            for (var i = 0; i < _weaponSettingsBase.WeaponSettings.Count; i++)
            {
                var weaponSetting = _weaponSettingsBase.WeaponSettings[i];
                var weapon = new WeaponEntity(i);
                weapon.SetShootRadius(weaponSetting.ShootRadius);
                weapon.SetShootDelay(weaponSetting.ShootDelay);
                
                _equippedWeapons.Add(weapon);
            }
        }
        
        public void SelectWeapon(int id)
        {
            CurrentWeaponEntity = GetWeaponById(id);
            WeaponChanged?.Invoke();
        }

        private WeaponEntity GetWeaponById(int id)
        {
            foreach (var weaponEntity in EquippedWeapons)
            {
                if (weaponEntity.Id == id)
                    return weaponEntity;
            }

            return null;
        }
    }
}