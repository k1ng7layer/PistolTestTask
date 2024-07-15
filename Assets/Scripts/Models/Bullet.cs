using UnityEngine;

namespace Models
{
    public class Bullet : GameEntity
    {
        public Vector3 Direction { get; private set; }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
        }
    }
}