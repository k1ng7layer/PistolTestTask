using UnityEngine;

namespace Settings.Prefab
{
    public interface IPrefabBase
    {
        GameObject Get(string name);
    }
}