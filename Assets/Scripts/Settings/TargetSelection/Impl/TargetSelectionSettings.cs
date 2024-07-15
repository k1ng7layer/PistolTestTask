using Models;
using UnityEngine;

namespace Settings.TargetSelection.Impl
{
    public class TargetSelectionSettings : ScriptableObject, 
        ITargetSelectionSettings
    {
        [SerializeField] private UnitGroup _allowedGroups;

        public UnitGroup AllowedGroups => _allowedGroups;
    }
}