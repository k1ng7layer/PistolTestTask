using System;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Shoot
{
    public class ShootButtonView : UiView
    {
        [SerializeField] private Button _shootButton;

        public event Action Shoot;

        private void Awake()
        {
            _shootButton.onClick.AddListener(OnShotPressed);
        }

        private void OnDestroy()
        {
            _shootButton.onClick.RemoveListener(OnShotPressed);
        }

        private void OnShotPressed()
        {
            Shoot?.Invoke();
        }
    }
}