using System;
using Settings.Weapon;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WeaponPanel
{
    public class SelectWeaponButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _name;
        private int _weaponId;

        public event Action<int> WeaponSelected;

        private void Awake()
        {
            _button.onClick.AddListener(Select);
        }

        public void Init(int weaponId, string weaponName)
        {
            _weaponId = weaponId;
            _name.text = $"{weaponName}";
        }

        private void Select()
        {
            WeaponSelected?.Invoke(_weaponId);
        }
    }
}