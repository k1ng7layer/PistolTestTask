using Models.Entity;
using UnityEngine;

namespace Views.Units
{
    public class UnitView : EntityView
    {
        private GameUnit _entity;
        
        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            _entity = (GameUnit)entity;
            
            _entity.UnitDead += OnDead;
            _entity.Damaged += OnDamaged;
        }
        
        private void OnDead()
        {
          
        }
        
        protected virtual void OnDamaged()
        { }

        protected override void OnDestroyed()
        {
            _entity.UnitDead -= OnDead;
            _entity.Damaged -= OnDamaged;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (LayerMask.GetMask("Bullet") == (LayerMask.GetMask("Bullet") | (1 << other.gameObject.layer)))
            {
                _entity.OnBulletImpact(other.transform.GetHashCode());
            }
        }
    }
}