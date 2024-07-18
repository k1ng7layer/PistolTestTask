using System;
using Models.Entity;
using UnityEngine;

namespace Views.Units
{
    public class EntityView : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private int _hash;

        public event Action Despawned;
        public int TransformHash => _hash;

        private void Awake()
        {
            _hash = transform.GetHashCode();
        }

        public virtual void Link(GameEntity entity)
        {
            _entity = entity;
            
            _entity.PositionChanged += SetPosition;
            _entity.RotationChanged += SetRotation;
            _entity.Destroyed += OnEntityDestroy;
            _entity.Destroyed += OnEntityDestroy;
        }

        public virtual void Unlink()
        {
            _entity.PositionChanged -= SetPosition;
            _entity.RotationChanged -= SetRotation;
            _entity.Destroyed -= OnEntityDestroy;
            _entity.Destroyed -= OnEntityDestroy;
            _entity = null;
        }

        private void OnEntityDestroy(bool value)
        {
            _entity.PositionChanged -= SetPosition;
            _entity.RotationChanged -= SetRotation;
            _entity.Destroyed -= OnEntityDestroy;
            OnDestroyed();
            Destroy(gameObject);
        }

        protected virtual void OnDestroyed()
        { }

        public void SetPosition(Vector3 value)
        {
            transform.position = value;
        }

        private void SetRotation(Quaternion value)
        {
            transform.rotation = value;
        }
    }
}