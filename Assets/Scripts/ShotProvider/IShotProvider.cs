using System;
using Models.Weapons;

namespace ShotProvider
{
    public interface IShotProvider
    {
        WeaponShot Get(Type shotType);
    }
}