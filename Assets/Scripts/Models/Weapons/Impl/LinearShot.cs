using Models.Entity;
using Services.BulletPool;
using Services.Coroutine;
using Services.Spawn;
using UnityEngine;

namespace Models.Weapons.Impl
{
    public class LinearShot : WeaponShot
    {
        private readonly ICoroutineDispatcher _coroutineDispatcher;
        private readonly ISpawnService _spawnService;

        public LinearShot(
            IBulletService bulletService, 
            ICoroutineDispatcher coroutineDispatcher
        ) : base(bulletService, coroutineDispatcher)
        {
            _coroutineDispatcher = coroutineDispatcher;
        }

        public override void Shot(GameEntity shooter, Vector3 direction)
        {
            for (int i = 0; i < WeaponSettings.BulletsNumber; i++)
            {
                _coroutineDispatcher.Delay(WeaponSettings.BulletsDelay,
                    () =>
                    {
                        SpawnBullet(shooter.Position, direction, 4f);
                    });
            }
        }

        private void SpawnBullet(Vector3 position, Vector3 direction, float speed)
        {
            var bullet = BulletService.SpawnBullet(position, direction);
            bullet.SetSpeed(speed);
        }
    }
}