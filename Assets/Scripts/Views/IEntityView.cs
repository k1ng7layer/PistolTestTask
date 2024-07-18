using Models.Entity;
using UnityEngine;

namespace Views
{
    public interface IEntityView
    {
        int TransformHash { get; }
        void Link(GameEntity entity);
        void SetPosition(Vector3 value);
    }
}