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
        private readonly List<Bullet> _activeBullets = new();

        public BulletService(
            ObjectPool<IEntityView> bulletViewPool, 
            ObjectPool<Bullet> bulletPool
        )
        {
            _bulletViewPool = bulletViewPool;
            _bulletPool = bulletPool;
        }

        public IReadOnlyList<Bullet> ActiveBullets => _activeBullets;
        
        public Bullet SpawnBullet(Vector3 position, Vector3 direction)
        {
            var bulletView = _bulletViewPool.Spawn();
            var bullet = _bulletPool.Spawn();
            bulletView.Link(bullet);
            
            var rotation = Quaternion.LookRotation(direction);
            bullet.SetPosition(position);
            bullet.SetRotation(rotation);

            _activeBullets.Add(bullet);
            
            return bullet;
        }

        public void DespawnBullet(Bullet bullet)
        {
            _bulletPool.Despawn(bullet);
            
        }
    }
}