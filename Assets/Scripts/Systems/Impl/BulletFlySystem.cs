using Services.BulletPool;
using Services.TimeProvider;
using UnityEngine;

namespace Systems.Impl
{
    public class BulletFlySystem : IUpdateSystem
    {
        private readonly IBulletService _bulletService;
        private readonly ITimeProvider _timeProvider;

        public BulletFlySystem(
            IBulletService bulletService, 
            ITimeProvider timeProvider)
        {
            _bulletService = bulletService;
            _timeProvider = timeProvider;
        }
        
        public void Update()
        {
            foreach (var bullet in _bulletService.ActiveBullets)
            {
                if (!bullet.Active)
                    continue;
                
                var direction = bullet.Rotation * Vector3.up;
                var position = bullet.Position + direction * bullet.Speed * _timeProvider.DeltaTime;
                bullet.SetPosition(position);
            }
        }
    }
}