using System;
using System.Collections.Generic;
using Models.Weapons;
using Services.Coroutine;
using Settings.ShotInstaller.Impl;
using Settings.Weapon;

namespace ShotProvider.Impl
{
    public class ShotPool : IShotPool
    {
        private readonly GameWeaponShotInstaller _shotInstaller;
        private readonly ICoroutineDispatcher _coroutineDispatcher;
        private readonly IWeaponSettingsBase _weaponSettingsBase;
        private readonly Dictionary<Type, Queue<WeaponShot>> _pool = new();

        public ShotPool(
            GameWeaponShotInstaller shotInstaller, 
            ICoroutineDispatcher coroutineDispatcher,
            IWeaponSettingsBase weaponSettingsBase)
        {
            _shotInstaller = shotInstaller;
            _coroutineDispatcher = coroutineDispatcher;
            _weaponSettingsBase = weaponSettingsBase;

            foreach (var type in shotInstaller.ShotTypes)
            {
                Fill(type);
            }
        }

        private void Fill(Type type)
        {
            if (!_pool.TryGetValue(type, out _))
            {
                var queue = new Queue<WeaponShot>();

                for (int i = 0; i < 20; i++)
                {
                    queue.Enqueue(CreateInstance(type));
                }
                    
                _pool.Add(type, queue);
            }
        }
        
        public WeaponShot Get(Type shotType)
        {
            if (_pool[shotType].Count > 0)
            {
                return _pool[shotType].Dequeue();
            }

            Fill(shotType);

            return _pool[shotType].Dequeue();
        }

        public void Return(WeaponShot weaponShot)
        {
            _pool[weaponShot.CachedType].Enqueue(weaponShot);
        }
        
        private WeaponShot CreateInstance(Type type)
        {
            var instance = (WeaponShot)Activator.CreateInstance(type, 
                new object[]{_coroutineDispatcher});
            return instance;
        }
    }
}