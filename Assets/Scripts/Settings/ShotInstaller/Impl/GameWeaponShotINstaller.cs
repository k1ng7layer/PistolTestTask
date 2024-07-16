using Models.Weapons.Impl;

namespace Settings.ShotInstaller.Impl
{
    public class GameWeaponShotInstaller : ShotInstaller
    {
        protected override void Configure()
        {
            RegisterShot<LinearShot>();
        }
    }
}