namespace Models.Entity
{
    public class WeaponEntity : GameEntity
    {
        public WeaponEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public float ShootRadius { get; private set; }
        public float ShootDelay { get; private set; }
    }
}