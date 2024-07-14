using System;
using UI.Core;
using UnityEngine;

namespace UI.MovementInput
{
    public class MovementInputView : UiView
    {
        [SerializeField] protected Joystick _joystick;
        
        public event Action<Vector3> Dragged;
        
        private void Update()
        {
            Dragged?.Invoke(new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical));
        }
    }
}