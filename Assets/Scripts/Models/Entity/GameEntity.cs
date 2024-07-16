using System;
using UnityEngine;

namespace Models.Entity
{
    public class GameEntity
    {
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }
        public UnitGroup UnitGroup { get; private set; }
        public bool Dead { get; private set; }
        public event Action UnitDead;
        public event Action<Vector3> PositionChanged;
        public event Action<Quaternion> RotationChanged;

        public void SetUnitGroup(UnitGroup group)
        {
            UnitGroup = group;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            Rotation = rotation;
        }

        public void SetDead(bool value)
        {
            Dead = value;
            UnitDead?.Invoke();
        }
    }
}