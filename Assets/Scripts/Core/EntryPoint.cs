using System;
using System.Collections.Generic;
using Services.BulletPool;
using Services.BulletPool.Impl;
using Services.EnemySpawn.Impl;
using Services.Input;
using Services.Input.Impl;
using Services.PlayerProvider;
using Services.PlayerProvider.Impl;
using Services.Pool.Impl;
using Services.Spawn.Impl;
using Services.TimeProvider;
using Services.TimeProvider.Impl;
using Services.UnitRepository;
using Services.UnitRepository.Impl;
using Settings;
using Settings.Player;
using Systems;
using Systems.Impl;
using UnityEngine;
using Views.Level;

namespace Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameSettingsBase _gameSettingsBase;
        [SerializeField] private LevelView _levelView;

        private Game _game;

        private void Awake()
        {
            var spawnService = new SpawnService(_gameSettingsBase.PrefabBase);
            var unitRepository = new UnitRepository();
            var enemySpawnService = new EnemySpawnService(
                _levelView, 
                spawnService, 
                unitRepository);
            
            var timeProvider = new UnityTimeProvider();
            var playerProvider = new PlayerProvider();
            var input = new InputService();
            var bulletPool = new BulletEntityPool(10);
            var bulletViewPool = new BulletViewPool(10, spawnService);
            var bulletService = new BulletService(bulletViewPool, bulletPool);
            
            var systems = CreateSystems(
                _gameSettingsBase.PlayerSettings, 
                playerProvider, 
                input,
                timeProvider,
                bulletService,
                unitRepository);
            
            _game = new Game(_levelView, spawnService, enemySpawnService, systems);
            
            _game.Start();
        }

        private List<IUpdateSystem> CreateSystems(
            IPlayerSettings playerSettings, 
            IPlayerProvider playerProvider, 
            IInputService inputService,
            ITimeProvider timeProvider,
            IBulletService bulletService,
            IUnitRepository unitRepository)
        {
            var systems = new List<IUpdateSystem>();
            
            var playerMovementSystem = new PlayerMovementSystem(playerProvider, 
                inputService, 
                timeProvider, 
                playerSettings);

            var bulletFlySystem = new BulletFlySystem(bulletService, timeProvider);
            var bulletImpactSystem = new BulletImpactSystem(unitRepository, bulletService);
            var bulletCleanupSystem = new BulletCleanupSystem(bulletService);
            
            systems.Add(playerMovementSystem);
            systems.Add(bulletFlySystem);
            systems.Add(bulletImpactSystem);
            systems.Add(bulletCleanupSystem);

            return systems;
        }

        private void Update()
        {
            _game?.Update();
        }
    }
}