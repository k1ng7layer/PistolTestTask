using System.Collections.Generic;
using Models.Entity;
using UnityEngine;
using Views;

namespace Services.BulletPool
{
    public interface IBulletService
    {
        HashSet<Bullet> ActiveBullets { get; }
        Bullet SpawnBullet(Vector3 position, Vector3 direction);
        void CleanupBullets();
        IEntityView GetBulletView(int transformHash);
        bool TryGetBullet(int transformHash, out Bullet bullet);
        void DespawnBullet(Bullet bullet);
    }
}