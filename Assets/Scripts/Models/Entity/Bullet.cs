using System;
using UnityEngine;

namespace Models.Entity
{
    public class Bullet : GameEntity
    {
        public Vector3 Direction { get; private set; }
        public float Speed { get; private set; }
        public UnitGroup TargetGroup { get; private set; }
        public bool Active { get; private set; }
        public event Action<Bullet, bool> ActiveChanged;
        public int TransformHash { get; private set; }
        
        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

        public void SetActive(bool value)
        {
            Active = value;
            ActiveChanged?.Invoke(this, value);
        }

        public void SetTransformHash(int value)
        {
            TransformHash = value;
        }
        
    }
}