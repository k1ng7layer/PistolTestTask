using Models;
using Models.Entity;
using UnityEngine;

namespace Settings.TargetSelection.Impl
{
    [CreateAssetMenu(menuName = "Settings/TargetSelectionSettings", fileName = "TargetSelectionSettings")]
    public class TargetSelectionSettings : ScriptableObject, 
        ITargetSelectionSettings
    {
        [SerializeField] private UnitGroup _allowedGroups;

        public UnitGroup AllowedGroups => _allowedGroups;
    }
}