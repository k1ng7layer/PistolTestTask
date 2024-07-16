using System;

namespace Services.Pool
{
    public interface IPool<T> : IDisposable
    {
        T Spawn();
        void Despawn(T instance);
    }
}