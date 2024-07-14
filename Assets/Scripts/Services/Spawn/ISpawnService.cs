using UnityEngine;
using Views;

namespace Services.Spawn
{
    public interface ISpawnService
    {
        IEntityView Spawn(string prefab, Vector3 position);
    }
}