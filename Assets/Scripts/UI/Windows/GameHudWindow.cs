using UI.Core;
using UI.MovementInput;
using UI.Shoot;
using UI.WeaponPanel;

namespace UI.Windows
{
    public class GameHudWindow : UiWindow
    {
        public override void Setup()
        {
            AddController<MovementInputController>();
            AddController<ShootController>();
            AddController<WeaponPanelController>();
        }
    }
}