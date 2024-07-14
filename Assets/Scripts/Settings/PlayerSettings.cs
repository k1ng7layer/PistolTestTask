using UnityEngine;

namespace Settings
{
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}