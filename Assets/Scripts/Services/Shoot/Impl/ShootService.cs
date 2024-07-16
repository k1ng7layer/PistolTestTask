using Services.PlayerProvider;
using Services.Target;
using Services.Weapon;
using Settings.Weapon;
using ShotProvider;

namespace Services.Shoot.Impl
{
    public class ShootService : IShootService
    {
        private readonly IWeaponService _weaponService;
        private readonly ITargetSelectService _targetSelectService;
        private readonly IPlayerProvider _playerProvider;
        private readonly IWeaponSettingsBase _weaponSettingsBase;
        private readonly IShotPool _shotPool;

        public ShootService(
            IWeaponService weaponService, 
            ITargetSelectService targetSelectService,
            IPlayerProvider playerProvider,
            IWeaponSettingsBase weaponSettingsBase,
            IShotPool shotPool
        )
        {
            _weaponService = weaponService;
            _targetSelectService = targetSelectService;
            _playerProvider = playerProvider;
            _weaponSettingsBase = weaponSettingsBase;
            _shotPool = shotPool;
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
            
            var weaponShot = _shotPool.Get(weaponSettings.Handler.Type);
            weaponShot.Setup(weaponSettings);
            weaponShot.Shot(_playerProvider.Player, dir);
        }
    }
}