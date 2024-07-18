using System.Collections.Generic;

namespace Services.Pool.Impl
{
    public abstract class ObjectPool<T> : IPool<T>
    {
        private readonly int _size;
        private readonly Queue<T> _pool = new();

        public ObjectPool(int size)
        {
            _size = size;
        }

        public void Init()
        {
            for (int i = 0; i < _size; i++)
            {
                var item = Create();
                _pool.Enqueue(item);
            }
        }
        
        public virtual void Dispose()
        {
            _pool.Clear();
        }
        
        public T Spawn()
        {
            if (_pool.Count > 0)
                return _pool.Dequeue();

            Init();
            var instance = _pool.Dequeue();
            
            OnSpawn(instance);
            
            return instance;
        }

        public void Despawn(T instance)
        {
            OnDespawn(instance);
            _pool.Enqueue(instance);
        }

        protected abstract T Create();

        protected virtual void OnSpawn(T instance)
        {}

        protected virtual void OnDespawn(T instance)
        {}
    }
}