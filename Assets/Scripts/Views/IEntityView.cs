using Models.Entity;
using UnityEngine;

namespace Views
{
    public interface IEntityView
    {
        int TransformHash { get; }
        void Link(GameEntity entity);
        void Unlink();
        void SetPosition(Vector3 value);
    }
}