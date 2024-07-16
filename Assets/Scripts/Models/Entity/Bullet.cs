using UnityEngine;

namespace Models.Entity
{
    public class Bullet : GameEntity
    {
        public Vector3 Direction { get; private set; }
        public float Speed { get; private set; }
        public bool Active { get; private set; }
        public UnitGroup TargetGroup { get; private set; }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
        }

        public void SetActive(bool value)
        {
            Active = value;
        }
    }
}