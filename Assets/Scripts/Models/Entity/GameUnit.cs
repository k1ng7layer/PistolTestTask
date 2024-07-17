using System;

namespace Models.Entity
{
    public class GameUnit : GameEntity
    {
        public bool Dead { get; private set; }
        public event Action UnitDead;
        public event Action Damaged;
        
        public void TakeDamage()
        {
            Damaged?.Invoke();
        }
        
        public void OnBulletImpact(Bullet bullet)
        {
            if (!bullet.TargetGroup.HasFlag(UnitGroup))
                return;
            
            Damaged?.Invoke();
        }
        
        public void SetDead(bool value)
        {
            Dead = value;
            UnitDead?.Invoke();
        }
    }
}