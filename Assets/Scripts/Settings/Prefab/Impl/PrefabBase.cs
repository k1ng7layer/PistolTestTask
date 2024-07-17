using System;
using UnityEngine;

namespace Settings.Prefab.Impl
{
    [CreateAssetMenu(menuName = "Settings/PrefabBase", fileName = "PrefabBase")]
    public class PrefabBase : ScriptableObject, IPrefabBase
    {
        [SerializeField] private PrefabSettings[] _settings;
        public GameObject Get(string prefabName)
        {
            foreach (var setting in _settings)
            {
                if (setting.Name == prefabName)
                    return setting.Prefab;
            }

            throw new Exception($"[{nameof(PrefabBase)}] can't find prefab with name {prefabName}");
        }
    }
}