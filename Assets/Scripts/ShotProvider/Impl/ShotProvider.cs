using System;
using System.Collections.Generic;
using Models.Weapons;
using Services.BulletPool;
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
        private readonly IBulletService _bulletService;
        private readonly Dictionary<Type, Queue<WeaponShot>> _pool = new();

        public ShotPool(
            GameWeaponShotInstaller shotInstaller, 
            ICoroutineDispatcher coroutineDispatcher,
            IWeaponSettingsBase weaponSettingsBase,
            IBulletService bulletService)
        {
            _shotInstaller = shotInstaller;
            _coroutineDispatcher = coroutineDispatcher;
            _weaponSettingsBase = weaponSettingsBase;
            _bulletService = bulletService;

            var shots = shotInstaller.GetShots();
            foreach (var type in shots)
            {
                if (!_pool.ContainsKey(type))
                    Fill(type);
            }
        }

        private void Fill(Type type)
        {
            if (!_pool.ContainsKey(type))
                _pool.Add(type, new Queue<WeaponShot>());

            var queue = _pool[type];

            for (int i = 0; i < 20; i++)
            {
                queue.Enqueue(CreateInstance(type));
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
                new object[]{_bulletService, _coroutineDispatcher});
            return instance;
        }
    }
}