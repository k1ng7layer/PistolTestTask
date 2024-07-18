using System.Collections.Generic;
using Services.BulletPool;
using Services.BulletPool.Impl;
using Services.Coroutine.Impl;
using Services.Input;
using Services.Input.Impl;
using Services.PlayerProvider;
using Services.PlayerProvider.Impl;
using Services.Pool.Impl;
using Services.Shoot;
using Services.Shoot.Impl;
using Services.Spawn;
using Services.Spawn.Impl;
using Services.Target.Impl;
using Services.TimeProvider;
using Services.TimeProvider.Impl;
using Services.UnitRepository;
using Services.UnitRepository.Impl;
using Services.Weapon;
using Services.Weapon.Impl;
using Settings;
using Settings.Player;
using Settings.ShotInstaller.Impl;
using Settings.Weapon;
using ShotProvider.Impl;
using Systems;
using Systems.Impl;
using UI.Core;
using UI.MovementInput;
using UI.Shoot;
using UI.WeaponPanel;
using UI.Windows;
using UnityEngine;
using Views.Level;

namespace Core
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private MovementInputView _movementInputView;
        [SerializeField] private ShootButtonView _shootButtonView;
        [SerializeField] private WeaponPanelView _weaponPanelView;
        
        [Space]
        [SerializeField] private GameSettingsBase _gameSettingsBase;
        [SerializeField] private LevelView _levelView;
        [SerializeField] private CoroutineDispatcher _coroutineDispatcher;

        private Game _game;
        private UiManager _uiManager;

        private void Awake()
        {
            var spawnService = new SpawnService(_gameSettingsBase.PrefabBase);
            var unitRepository = new UnitRepository();
            var timeProvider = new UnityTimeProvider();
            var playerProvider = new PlayerProvider();
            var input = new InputService();
            var bulletPool = new BulletEntityPool(10);
            var bulletViewPool = new BulletViewPool(1, spawnService);
            var bulletService = new BulletService(bulletViewPool, bulletPool);
            var weaponService = new WeaponService(_gameSettingsBase.WeaponSettingsBase);
            
            weaponService.Initialize();
            weaponService.SelectWeapon(0);
            
            var targetService = new SelectNearestTargetService(unitRepository,
                _gameSettingsBase.TargetSelectionSettings, weaponService, playerProvider);
            
            var shootPool = new ShotPool(
                new GameWeaponShotInstaller(), 
                _coroutineDispatcher,
                _gameSettingsBase.WeaponSettingsBase, 
                bulletService);
            
            var shootService = new ShootService(weaponService, targetService, playerProvider,_gameSettingsBase.WeaponSettingsBase, shootPool);
            
            var systems = CreateSystems(
                _gameSettingsBase.PlayerSettings, 
                playerProvider, 
                input,
                timeProvider,
                bulletService,
                unitRepository,
                spawnService);

            _uiManager = InitializeUI(input, 
                shootService, 
                weaponService, 
                _gameSettingsBase.WeaponSettingsBase);
            
            _uiManager.Initialize();
            
            _game = new Game(systems);
            _game.Start();
        }

        private List<ISystem> CreateSystems(
            IPlayerSettings playerSettings, 
            IPlayerProvider playerProvider, 
            IInputService inputService,
            ITimeProvider timeProvider,
            IBulletService bulletService,
            IUnitRepository unitRepository,
            ISpawnService spawnService)
        {
            var systems = new List<ISystem>();
            
            var playerMovementSystem = new PlayerMovementSystem(playerProvider, 
                inputService, 
                timeProvider, 
                playerSettings);

            var bulletFlySystem = new BulletFlySystem(bulletService, timeProvider);
            //var bulletImpactSystem = new BulletImpactByDistanceSystem(unitRepository, bulletService);
            var bulletImpactSystem = new BulletImpactSystem(unitRepository, bulletService);
            var bulletCleanupSystem = new BulletCleanupSystem(bulletService);
            var spawnPlayerSystem = new SpawnPlayerSystem(_levelView, spawnService, playerProvider);
            var spawnEnemiesSystem = new SpawnEnemiesSystem(_levelView, spawnService, unitRepository);
            
            systems.Add(bulletImpactSystem);
            systems.Add(spawnPlayerSystem);
            systems.Add(spawnEnemiesSystem);
            systems.Add(playerMovementSystem); 
            systems.Add(bulletFlySystem);
            systems.Add(bulletCleanupSystem);

            return systems;
        }

        private UiManager InitializeUI(
            IInputService inputService, 
            IShootService shootService, 
            IWeaponService weaponService,
            IWeaponSettingsBase weaponSettingsBase
        )
        {
            var gameHudWindow = new GameHudWindow();
            var windows = new List<IUiWindow>() { gameHudWindow };
            var movementInputController = new MovementInputController(_movementInputView, inputService);
            var shootController = new ShootController(_shootButtonView, shootService);
            var weaponPanelController = new WeaponPanelController(_weaponPanelView, weaponService, weaponSettingsBase);
            var controllers = new List<IUiController>()
                { movementInputController, shootController, weaponPanelController };
            
            var uiManager = new UiManager(windows, controllers);

            return uiManager;
        }

        private void Update()
        {
            _game?.Update();
        }
    }
}