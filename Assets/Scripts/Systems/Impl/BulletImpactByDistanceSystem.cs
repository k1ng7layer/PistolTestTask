using Models.Entity;
using Services.BulletPool;
using Services.UnitRepository;

namespace Systems.Impl
{
    public class BulletImpactByDistanceSystem : IUpdateSystem
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IBulletService _bulletService;

        public BulletImpactByDistanceSystem(
            IUnitRepository unitRepository, 
            IBulletService bulletService
        )
        {
            _unitRepository = unitRepository;
            _bulletService = bulletService;
        }
        
        public void Update()
        {
            foreach (var bullet in _bulletService.ActiveBullets)
            {
                if (!bullet.Active)
                    continue;
                
                CheckDistanceToUnits(bullet);
            }
        }

        private void CheckDistanceToUnits(Bullet bullet)
        {
            foreach (var entity in _unitRepository.Entities)
            {
                if (!bullet.TargetGroup.HasFlag(entity.UnitGroup))
                    continue;
                
                var dist2 = (entity.Position - bullet.Position).sqrMagnitude;

                if (dist2 <= 0.001f)
                    Impact(entity, bullet);
            }
        }

        private void Impact(GameUnit entity, Bullet bullet)
        {
            bullet.SetActive(false);
            entity.TakeDamage();
        }
    }
}