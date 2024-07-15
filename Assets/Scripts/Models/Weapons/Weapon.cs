using UnityEngine;

namespace Models.Weapons
{
    public class Weapon : GameEntity
    {
        public Weapon(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public float ShootRadius { get; private set; }
        public float ShootDelay { get; private set; }
    }
}