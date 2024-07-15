using Models.Entity;
using Services.Coroutine;
using Services.Spawn;
using Settings.Weapon;
using UnityEngine;

namespace Models.Weapons.Impl
{
    public class PistolShot : WeaponShot
    {
        private readonly ICoroutineDispatcher _coroutineDispatcher;
        private readonly ISpawnService _spawnService;

        public PistolShot(
            WeaponSettings weaponSettings, 
            ICoroutineDispatcher coroutineDispatcher, 
            ISpawnService spawnService
        ) : base(weaponSettings)
        {
            _coroutineDispatcher = coroutineDispatcher;
            _spawnService = spawnService;
        }

        public override void Shot(GameEntity shooter, Vector3 direction)
        {
            for (int i = 0; i < WeaponSettings.BulletsDelay; i++)
            {
                _coroutineDispatcher.Delay(WeaponSettings.BulletsDelay,
                    () =>
                    {
                        SpawnBullet(shooter.Position, direction);
                    });
            }
        }

        private void SpawnBullet(Vector3 position, Vector3 direction)
        {
            var bulletView = _spawnService.Spawn("Bullet", position);
            var bullet = new Bullet();
            var rotation = Quaternion.LookRotation(direction);
            bullet.SetRotation(rotation);
            
            bulletView.Link(bullet);
        }
    }
}