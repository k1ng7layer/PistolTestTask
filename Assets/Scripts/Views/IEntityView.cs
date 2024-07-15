using Models;
using Models.Entity;
using UnityEngine;

namespace Views
{
    public interface IEntityView
    {
        void Link(GameEntity entity);
        void SetPosition(Vector3 value);
    }
}