using UnityEngine;

namespace Settings.Weapon
{
    public class WeaponSettings : ScriptableObject
    {
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