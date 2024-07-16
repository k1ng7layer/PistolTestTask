using System;
using Models.Weapons;

namespace ShotProvider
{
    public interface IShotPool
    {
        WeaponShot Get(Type shotType);
        void Return(WeaponShot weaponShot);
    }
}