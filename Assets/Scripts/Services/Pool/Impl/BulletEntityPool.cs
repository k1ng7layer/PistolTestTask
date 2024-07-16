using Models.Entity;

namespace Services.Pool.Impl
{
    public class BulletEntityPool : ObjectPool<Bullet>
    {
        public BulletEntityPool(int size) : base(size)
        {
        }

        protected override Bullet Create()
        {
            return new Bullet();
        }
    }
}