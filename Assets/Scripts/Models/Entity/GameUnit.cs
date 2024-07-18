using System;

namespace Models.Entity
{
    public class GameUnit : GameEntity
    {
        public int Health { get; private set; }
        public bool Dead { get; private set; }
        public event Action UnitDead;
        public event Action Damaged;
        public event Action<int, GameUnit> BulletImpact;
        
        public void TakeDamage()
        {
            Damaged?.Invoke();
        }
        
        public void OnBulletImpact(int bulletHash)
        {
            BulletImpact?.Invoke(bulletHash, this);
        }
        
        public void SetDead(bool value)
        {
            Dead = value;
            UnitDead?.Invoke();
        }

        public void SetHealth(int value)
        {
            Health = value;
        }
    }
}