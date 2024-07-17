using Helpers.SerializableType;
using Models.Weapons;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings.Weapon
{
    [CreateAssetMenu(menuName = "Settings/WeaponSettings", fileName = "WeaponSettings")]
    public class WeaponSettings : ScriptableObject
    {
        [TypeFilter(typeof(WeaponShot))]
        public SerializableType Handler;
        
        [Header("Shoot settings")]
        public int BulletsNumber;
        public float BulletsDelay;
        public int ShootRadius;
        public float ShootDelay;
        
        [Space]
        [Header("Prefab settings")]
        public string WeaponPrefab;
        public string BulletPrefab;
    }
}