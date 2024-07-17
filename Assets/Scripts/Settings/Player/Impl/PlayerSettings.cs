using Settings.Weapon;
using UnityEngine;

namespace Settings.Player.Impl
{
    [CreateAssetMenu(menuName = "Settings/PlayerSettings", fileName = "PlayerSettings")]
    public class PlayerSettings : ScriptableObject, IPlayerSettings
    {
        [SerializeField] private float _speed;
        [Space]
        [Header("Weapons")]
        [SerializeField] private WeaponSettings[] _weapons;

        public float Speed => _speed;
        public WeaponSettings[] Weapons => _weapons;
    }
}