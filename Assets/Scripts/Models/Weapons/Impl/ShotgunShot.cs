using Models.Entity;
using Services.BulletPool;
using Services.Coroutine;
using UnityEngine;

namespace Models.Weapons.Impl
{
    public class ShotgunShot : WeaponShot
    {
        private readonly ICoroutineDispatcher _coroutineDispatcher;

        public ShotgunShot(IBulletService bulletService, ICoroutineDispatcher coroutineDispatcher) : base(bulletService, coroutineDispatcher)
        {
            _coroutineDispatcher = coroutineDispatcher;
        }

        public override void Shot(GameEntity shooter, Vector3 direction)
        {
            SpawnBullet(shooter.Position, direction, WeaponSettings.BulletSpeed);
            
            _coroutineDispatcher.InvokeRepeatedly((() =>
            {
                SpawnBullet(shooter.Position, direction, WeaponSettings.BulletSpeed);
                
            }), WeaponSettings.BulletsDelay, WeaponSettings.BulletsNumber - 1);
        }
        
        private void SpawnBullet(Vector3 position, Vector3 direction, float speed)
        {
            var bullet = BulletService.SpawnBullet(position, direction);
            bullet.SetSpeed(speed);
        }
    }
}