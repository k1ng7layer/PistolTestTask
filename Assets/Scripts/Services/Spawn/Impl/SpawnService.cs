using Settings.Prefab;
using Unity.Mathematics;
using UnityEngine;
using Views;

namespace Services.Spawn.Impl
{
    public class SpawnService : ISpawnService
    {
        private readonly IPrefabBase _prefabBase;

        public SpawnService(IPrefabBase prefabBase)
        {
            _prefabBase = prefabBase;
        }
        
        public IEntityView Spawn(string prefabName, Vector3 position)
        {
            var prefab = _prefabBase.Get(prefabName);
            var obj = Object.Instantiate(prefab, position, quaternion.identity);
            var view = obj.GetComponent<IEntityView>();

            return view;
        }
    }
}