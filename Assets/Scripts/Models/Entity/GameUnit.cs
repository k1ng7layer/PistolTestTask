using System;

namespace Models.Entity
{
    public class GameUnit : GameEntity
    {
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
    }
}