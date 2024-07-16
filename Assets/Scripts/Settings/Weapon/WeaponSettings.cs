using Helpers.SerializableType;
using Models.Weapons;
using UnityEngine;

namespace Settings.Weapon
{
    public class WeaponSettings : ScriptableObject
    {
        [TypeFilter(typeof(WeaponShot))]
        public SerializableType Handler;
        
        [Header("Shoot settings")]
        public int BulletsNumber;
        public float BulletsDelay;
        public int AttackRadius;
        public float ShootDelay;
        
        [Space]
        [Header("Prefab settings")]
        public string WeaponPrefab;
        public string BulletPrefab;
    }
}