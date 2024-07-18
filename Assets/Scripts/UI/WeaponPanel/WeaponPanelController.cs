using Services.Weapon;
using Settings.Weapon;
using UI.Core;

namespace UI.WeaponPanel
{
    public class WeaponPanelController : UiController<WeaponPanelView>
    {
        private readonly IWeaponService _weaponService;
        private readonly IWeaponSettingsBase _weaponSettingsBase;

        public WeaponPanelController(
            WeaponPanelView view, 
            IWeaponService weaponService,
            IWeaponSettingsBase weaponSettingsBase
        ) : base(view)
        {
            _weaponService = weaponService;
            _weaponSettingsBase = weaponSettingsBase;
        }

        protected override void OnInitialize()
        {
            _weaponService.WeaponChanged += OnWeaponChanged;
            OnWeaponChanged();
            View.WeaponSelected += SelectWeapon;

            for (var i = 0; i < _weaponService.EquippedWeapons.Count; i++)
            {
                var weapon = _weaponService.EquippedWeapons[i];
                var settings = _weaponSettingsBase.GetWeaponById(weapon.Id);
                View.InitializeWeaponSlot(weapon.Id,settings.Name, i);
            }
        }

        public override void Dispose()
        {
            _weaponService.WeaponChanged -= OnWeaponChanged;
        }

        private void SelectWeapon(int id)
        {
            _weaponService.SelectWeapon(id);
        }

        private void OnWeaponChanged()
        {
            var activeWeapon = _weaponService.CurrentWeaponEntity.Id;
            View.SetWeaponSlotInteractable(activeWeapon);
        }
    }
}