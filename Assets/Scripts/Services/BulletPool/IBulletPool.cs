using System.Collections.Generic;
using Models.Entity;
using UnityEngine;

namespace Services.BulletPool
{
    public interface IBulletService
    {
        IReadOnlyList<Bullet> ActiveBullets { get; }
        Bullet SpawnBullet(Vector3 position, Vector3 direction);
        public void DespawnBullet(Bullet bullet);
    }
}