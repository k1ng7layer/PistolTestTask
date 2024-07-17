using System.Collections.Generic;
using Models.Entity;
using Services.Pool.Impl;
using UnityEngine;
using Views;

namespace Services.BulletPool.Impl
{
    public class BulletService : IBulletService
    {
        private readonly ObjectPool<IEntityView> _bulletViewPool;
        private readonly ObjectPool<Bullet> _bulletPool;
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _inactiveBullets = new();

        public BulletService(
            ObjectPool<IEntityView> bulletViewPool, 
            ObjectPool<Bullet> bulletPool
        )
        {
            _bulletViewPool = bulletViewPool;
            _bulletPool = bulletPool;
        }

        public HashSet<Bullet> ActiveBullets => _activeBullets;
        
        public Bullet SpawnBullet(Vector3 position, Vector3 direction)
        {
            var bulletView = _bulletViewPool.Spawn();
            var bullet = _bulletPool.Spawn();
            bulletView.Link(bullet);
            
            var rotation = Quaternion.LookRotation(direction, Vector3.forward);
            bullet.SetPosition(position);
            //bullet.SetRotation(rotation);
            bullet.SetActive(true);

            _activeBullets.Add(bullet);
            bullet.Deactivated += OnDeactivated;
            
            return bullet;
        }

        public void CleanupBullets()
        {
            foreach (var bullet in _inactiveBullets)
            {
                _activeBullets.Remove(bullet);
                _bulletPool.Despawn(bullet);
            }
        }

        private void OnDeactivated(Bullet bullet)
        {
            bullet.Deactivated -= OnDeactivated;
            _inactiveBullets.Add(bullet);
        }
    }
}