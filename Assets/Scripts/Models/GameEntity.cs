using UnityEngine;

namespace Models
{
    public class GameEntity
    {
        public Vector3 Position { get; private set; }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }
    }
}