using System.Collections.Generic;
using UnityEngine;

namespace Settings.Weapon.Impl
{
    [CreateAssetMenu(menuName = "Settings/WeaponSettingsBase", fileName = "WeaponSettingsBase")]
    public class WeaponSettingsBase : ScriptableObject, 
        IWeaponSettingsBase
    {
        private List<WeaponSettings> _weaponSettings;

        public IReadOnlyList<WeaponSettings> WeaponSettings => _weaponSettings;
        
        public WeaponSettings GetWeaponById(int id)
        {
            return id < _weaponSettings.Count ? _weaponSettings[id] : null;
        }
    }
}