using UnityEngine;

namespace Models
{
    public class GameEntity
    {
        public Vector3 Position { get; private set; }
        public UnitGroup UnitGroup { get; private set; }

        public void SetUnitGroup(UnitGroup group)
        {
            UnitGroup = group;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }
    }
}