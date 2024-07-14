using UnityEngine;
using Services.Input;
using UI.Core;

namespace UI.MovementInput
{
    public class MovementInputController : UiController<MovementInputView>
    {
        private readonly IInputService _inputService;

        public MovementInputController(
            MovementInputView view, 
            IInputService inputService
        ) : base(view)
        {
            _inputService = inputService;
        }
        
        public override void Dispose()
        {
            View.Dragged -= OnMovement;
        }

        protected override void OnInitialize()
        {
            View.Dragged += OnMovement;
        }

        private void OnMovement(Vector3 dir)
        {
            _inputService.SetInput(dir);
        }
    }
}