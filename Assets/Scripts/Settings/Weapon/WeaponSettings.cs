using Helpers.SerializableType;
using Models.Weapons;
using UnityEngine;
using UnityEngine.Serialization;

namespace Settings.Weapon
{
    [CreateAssetMenu(menuName = "Settings/WeaponSettings", fileName = "WeaponSettings")]
    public class WeaponSettings : ScriptableObject
    {
        [Header("Info")] 
        public string Name;
        
        [Space]
        [Header("Shoot settings")]
        public int BulletsNumber;
        public float BulletsDelay;
        public int ShootRadius;
        public float ShootDelay;
        public float Damage;
        public float BulletSpeed;
        
        [Space]
        [TypeFilter(typeof(WeaponShot))]
        public SerializableType Handler;
        
        [Space]
        [Header("Prefab settings")]
        public string BulletPrefab;
    }
}