using System;
using Models.Entity;
using UnityEngine;

namespace Views.Units
{
    public class UnitView : MonoBehaviour, IEntityView
    {
        private GameUnit _entity;

        public event Action Despawned;

        public virtual void Link(GameEntity entity)
        {
            _entity = (GameUnit)entity;
            
            _entity.PositionChanged += SetPosition;
            _entity.RotationChanged += SetRotation;
            _entity.UnitDead += OnDead;
            _entity.Damaged += OnDamaged;
        }
        
        private void OnDead()
        {
            _entity.PositionChanged -= SetPosition;
            _entity.RotationChanged -= SetRotation;
            _entity.UnitDead -= OnDead;
            _entity.Damaged -= OnDamaged;
            
            Destroy(gameObject);
        }

        public void SetPosition(Vector3 value)
        {
            transform.position = value;
        }

        private void SetRotation(Quaternion value)
        {
            transform.rotation = value;
        }
        
        protected virtual void OnDamaged()
        { }
    }
}