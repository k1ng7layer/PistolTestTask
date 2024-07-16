using System.Collections.Generic;
using Models.Entity;
using UnityEngine;

namespace Services.BulletPool
{
    public interface IBulletService
    {
        HashSet<Bullet> ActiveBullets { get; }
        Bullet SpawnBullet(Vector3 position, Vector3 direction);
        void CleanupBullets();
    }
}