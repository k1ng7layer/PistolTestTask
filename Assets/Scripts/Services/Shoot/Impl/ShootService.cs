using Services.Weapon;

namespace Services.Shoot.Impl
{
    public class ShootService : IShootService
    {
        private readonly IWeaponService _weaponService;

        public ShootService(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }
        
        public void Shoot()
        {
            _weaponService.CurrentWeapon.Shoot();
        }
    }
}