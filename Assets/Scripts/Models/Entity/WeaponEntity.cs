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

        public void SetShootRadius(float value)
        {
            ShootRadius = value;
        }

        public void SetShootDelay(float value)
        {
            ShootDelay = value;
        }
    }
}