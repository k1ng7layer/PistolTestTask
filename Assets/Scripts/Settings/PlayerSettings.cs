using Settings.Weapon;
using UnityEngine;

namespace Settings
{
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private WeaponSettings[] _weapons;

        public float Speed => _speed;
        public WeaponSettings[] Weapons => _weapons;
    }
}