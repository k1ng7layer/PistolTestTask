using System;
using Models.Entity;
using Services.BulletPool;
using Services.Coroutine;
using Settings.Weapon;
using UnityEngine;

namespace Models.Weapons
{
    public abstract class WeaponShot
    {
        public WeaponShot(
            IBulletService bulletService, 
            ICoroutineDispatcher coroutineDispatcher
        )
        {
            BulletService = bulletService;
            CoroutineDispatcher = coroutineDispatcher;
        }
        
        public Type CachedType { get; private set; }
        protected IBulletService BulletService { get; }
        protected ICoroutineDispatcher CoroutineDispatcher { get; }
        protected WeaponSettings WeaponSettings { get; private set; }

        public void Setup(WeaponSettings settings)
        {
            CachedType = settings.Handler.Type;
            WeaponSettings = settings;
        }
        
        public abstract void Shot(GameEntity shooter, Vector3 direction);
    }
}