using Models.Entity;
using Services.BulletPool;
using Services.UnitRepository;

namespace Systems.Impl
{
    public class BulletImpactSystem : IInitializeSystem
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IBulletService _bulletService;

        public BulletImpactSystem(
            IUnitRepository unitRepository, 
            IBulletService bulletService
        )
        {
            _unitRepository = unitRepository;
            _bulletService = bulletService;
        }

        public void Initialize()
        {
            _unitRepository.Added += OnEntityAdded;
            _unitRepository.Removed += OnEntityRemoved;
        }

        private void OnEntityAdded(GameUnit entity)
        {
            entity.BulletImpact += OnBulletImpact;
        }
        
        private void OnEntityRemoved(GameUnit entity)
        {
            entity.BulletImpact -= OnBulletImpact;
        }

        private void OnBulletImpact(int bulletHash, GameUnit unit)
        {
            if (!_bulletService.TryGetBullet(bulletHash, out var bullet))
                return;
            
            if (!bullet.Active)
                return;
            
            if (!bullet.TargetGroup.HasFlag(unit.UnitGroup))
                return;
            
            unit.TakeDamage();
            
            //bullet.SetActive(false);
            _bulletService.DespawnBullet(bullet);
        }
    }
}