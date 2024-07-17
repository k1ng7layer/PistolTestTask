using Services.Weapon;
using UI.Core;

namespace UI.WeaponPanel
{
    public class WeaponPanelController : UiController<WeaponPanelView>
    {
        private readonly IWeaponService _weaponService;

        public WeaponPanelController(
            WeaponPanelView view, 
            IWeaponService weaponService
        ) : base(view)
        {
            _weaponService = weaponService;
        }

        protected override void OnInitialize()
        {
            View.WeaponSelected += SelectWeapon;
        }

        private void SelectWeapon(int id)
        {
            _weaponService.SelectWeapon(id);
        }
    }
}