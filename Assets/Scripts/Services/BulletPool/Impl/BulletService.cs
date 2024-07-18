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
        private readonly Dictionary<int, IEntityView> _bulletViewsMap = new();
        private readonly Dictionary<int, Bullet> _bulletsMap = new();

        private int _step;

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
            _bulletViewsMap.Add(bulletView.TransformHash, bulletView);
            _bulletsMap.Add(bulletView.TransformHash, bullet);
            var rot= Quaternion.identity * Quaternion.FromToRotation(Vector3.up, direction);
            bullet.SetPosition(position);
            bullet.SetRotation(rot);
            bullet.SetActive(true);
            bullet.SetTransformHash(bulletView.TransformHash);

            _activeBullets.Add(bullet);
            bullet.ActiveChanged += OnDeactivated;
            
            return bullet;
        }

        public void CleanupBullets()
        {
            foreach (var bullet in _inactiveBullets)
            {
                var view = _bulletViewsMap[bullet.TransformHash];
                _activeBullets.Remove(bullet);
                _bulletPool.Despawn(bullet);
                _bulletViewsMap.Remove(bullet.TransformHash);
                _bulletsMap.Remove(bullet.TransformHash);
                _bulletViewPool.Despawn(view);
                view.Unlink();
            }
            
            _inactiveBullets.Clear();
        }

        public IEntityView GetBulletView(int transformHash)
        {
            return _bulletViewsMap[transformHash];
        }

        public bool TryGetBullet(int transformHash, out Bullet bullet)
        {
            return _bulletsMap.TryGetValue(transformHash, out bullet);
        }

        public void DespawnBullet(Bullet bullet)
        {
            var view = _bulletViewsMap[bullet.TransformHash];
            _activeBullets.Remove(bullet);
            _bulletPool.Despawn(bullet);
            _bulletViewsMap.Remove(bullet.TransformHash);
            _bulletsMap.Remove(bullet.TransformHash);
            _bulletViewPool.Despawn(view);
            view.Unlink();
        }

        private void OnDeactivated(Bullet entity, bool value)
        {
            if (value)
                return;

            if (!_activeBullets.Contains(entity))
                return;
            
            _activeBullets.Remove(entity);
            _inactiveBullets.Add(entity);
        }
    }
}