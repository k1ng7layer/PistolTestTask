using System;
using Models.Entity;
using UnityEngine;

namespace Views
{
    public interface IEntityView
    {
        event Action Despawned;
        void Link(GameEntity entity);
        void SetPosition(Vector3 value);
    }
}