using Services.Spawn;
using UnityEngine;
using Views;

namespace Services.Pool.Impl
{
    public class BulletViewPool : ObjectPool<IEntityView>
    {
        private static readonly Vector3 PoolPosition = new(0f, -1000f, 0f);
        private readonly ISpawnService _spawnService;

        public BulletViewPool(int size, ISpawnService spawnService) : base(size)
        {
            _spawnService = spawnService;
        }

        protected override IEntityView Create()
        {
            var bulletView = _spawnService.Spawn("Bullet", PoolPosition);

            return bulletView;
        }

        protected override void OnDespawn(IEntityView instance)
        {
            instance.SetPosition(PoolPosition);
        }
    }
}