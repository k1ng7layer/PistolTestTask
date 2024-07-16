using UnityEngine;

namespace Views.Units
{
    public class ObstacleView : UnitView
    {
        [SerializeField] private ParticleSystem _particleSystem;
        
        protected override void OnDamaged()
        {
            _particleSystem.Play();
        }
    }
}