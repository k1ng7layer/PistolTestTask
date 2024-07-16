using System.Collections.Generic;
using Models.Entity;
using Services.BulletPool;

namespace Systems.Impl
{
    public class BulletCleanupSystem : IUpdateSystem
    {
        private readonly IBulletService _bulletService;

        public BulletCleanupSystem(IBulletService bulletService)
        {
            _bulletService = bulletService;
        }
        
        public void Update()
        {
            _bulletService.CleanupBullets();
        }
    }
}