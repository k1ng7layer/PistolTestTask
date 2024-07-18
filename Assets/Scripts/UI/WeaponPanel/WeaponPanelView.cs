using System;
using Models.Entity;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WeaponPanel
{
    public class WeaponPanelView : UiView
    {
        [SerializeField] private SelectWeaponButtonView[] _weaponSlots;

        public SelectWeaponButtonView[] WeaponSlots => _weaponSlots;

        public event Action<int> WeaponSelected;

        public void InitializeWeaponSlot(
            int weapon1Id, 
            string weaponName, 
            int slotId)
        {
            _weaponSlots[slotId].Init(weapon1Id, weaponName);
            _weaponSlots[slotId].WeaponSelected += OnWeaponSelected;
        }
        
        public void SetWeaponSlotInteractable(int weaponId)
        {
            foreach (var slot in _weaponSlots)
            {
                slot.SetInteractable(slot.WeaponId != weaponId);
            }
        }

        private void OnWeaponSelected(int weaponId)
        {
            WeaponSelected?.Invoke(weaponId);
        }

        private void OnDestroy()
        {
            foreach (var slot in _weaponSlots)
            {
                slot.WeaponSelected -= OnWeaponSelected;
            }
        }
    }
}