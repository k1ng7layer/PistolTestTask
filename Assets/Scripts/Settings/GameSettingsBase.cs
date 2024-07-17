using Settings.Player.Impl;
using Settings.Prefab.Impl;
using Settings.TargetSelection.Impl;
using Settings.Weapon.Impl;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Settings/GameSettingsBase", fileName = "GameSettingsBase")]
    public class GameSettingsBase : ScriptableObject
    {
        [SerializeField] private PlayerSettings _playerSettings;
        [SerializeField] private WeaponSettingsBase _weaponSettingsBase;
        [SerializeField] private TargetSelectionSettings _targetSelectionSettings;
        [SerializeField] private PrefabBase _prefabBase;

        public PlayerSettings PlayerSettings => _playerSettings;
        public WeaponSettingsBase WeaponSettingsBase => _weaponSettingsBase;
        public TargetSelectionSettings TargetSelectionSettings => _targetSelectionSettings;
        public PrefabBase PrefabBase => _prefabBase;
    }
}