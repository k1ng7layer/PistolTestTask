using Models;
using Models.Entity;
using Services.PlayerProvider;
using Services.Spawn;
using Services.Target;
using Services.Weapon;
using Settings.Weapon;

namespace Services.Shoot.Impl
{
    public class ShootService : IShootService
    {
        private readonly IWeaponService _weaponService;
        private readonly ITargetSelectService _targetSelectService;
        private readonly IPlayerProvider _playerProvider;
        private readonly IWeaponSettingsBase _weaponSettingsBase;
        private readonly ISpawnService _spawnService;

        public ShootService(
            IWeaponService weaponService, 
            ITargetSelectService targetSelectService,
            IPlayerProvider playerProvider,
            IWeaponSettingsBase weaponSettingsBase,
            ISpawnService spawnService
        )
        {
            _weaponService = weaponService;
            _targetSelectService = targetSelectService;
            _playerProvider = playerProvider;
            _weaponSettingsBase = weaponSettingsBase;
            _spawnService = spawnService;
        }
        
        public void Shoot()
        {
            var target = _targetSelectService.SelectTarget();
            
            if (target == null)
                return;
            
            var playerPos = _playerProvider.Player.Position;
            var dir = target.Position - playerPos;
            var weaponId = _weaponService.CurrentWeaponEntity.Id;
            var weaponSettings = _weaponSettingsBase.GetWeaponById(weaponId);

            for (int i = 0; i < weaponSettings.BulletsNumber; i++)
            {
                var bullet = new Bullet();
                var bulletView = _spawnService.Spawn(weaponSettings.BulletPrefab, playerPos);
                bulletView.Link(bullet);
            }
            
        }
    }
}