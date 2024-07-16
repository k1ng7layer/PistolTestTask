using System;
using Models.Entity;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WeaponPanel
{
    public class WeaponPanelView : UiView
    {
        [SerializeField] private Button _weapon1;
        [SerializeField] private Button _weapon2;

        public event Action<int> WeaponSelected;

        public void Initialize(int weapon1Id, int weapon2Id)
        {
            
        }
    }
}