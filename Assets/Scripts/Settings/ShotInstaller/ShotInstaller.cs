using System;
using System.Collections.Generic;
using Models.Weapons;

namespace Settings.ShotInstaller
{
    public abstract class ShotInstaller : IShotInstaller
    {
        private readonly HashSet<Type> _shots = new();
        
        protected void RegisterShot<T>() where T : WeaponShot
        {
            _shots.Add(typeof(T));
        }

        public HashSet<Type> ShotTypes => _shots;
        
        public HashSet<Type> GetShots()
        {
            Configure();

            return _shots;
        }

        protected abstract void Configure();
    }
}