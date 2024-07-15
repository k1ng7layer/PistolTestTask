using Models.Entity;
using Settings.Weapon;
using UnityEngine;

namespace Models.Weapons
{
    public abstract class WeaponShot
    {
        public WeaponShot(WeaponSettings weaponSettings)
        {
            WeaponSettings = weaponSettings;
        }
        
        protected WeaponSettings WeaponSettings { get; }
        
        public abstract void Shot(GameEntity shooter, Vector3 direction);
    }
}