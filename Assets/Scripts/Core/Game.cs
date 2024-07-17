using System.Collections.Generic;
using Models.Entity;
using Services.EnemySpawn;
using Services.Level;
using Services.PlayerProvider;
using Services.Spawn;
using Supyrb;
using Systems;
using UI.Core.Signals;
using UI.Windows;
using Views.Level;

namespace Core
{
    public class Game
    {
        private readonly LevelView _levelViewProvider;
        private readonly ISpawnService _spawnService;
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly List<IUpdateSystem> _updateSystems;
        private readonly IPlayerProvider _playerProvider;

        public Game(
            LevelView levelViewProvider, 
            ISpawnService spawnService, 
            IEnemySpawnService enemySpawnService,
            List<IUpdateSystem> updateSystems,
            IPlayerProvider playerProvider)
        {
            _levelViewProvider = levelViewProvider;
            _spawnService = spawnService;
            _enemySpawnService = enemySpawnService;
            _updateSystems = updateSystems;
            _playerProvider = playerProvider;
        }
        
        public void Start()
        {
            var playerSpawnPos = _levelViewProvider.PlayerSpawnTransform.position;
            var player = _spawnService.Spawn("Player", playerSpawnPos);
            var playerEntity = new GameUnit();
            player.Link(playerEntity);
            playerEntity.SetPosition(playerSpawnPos);
            _enemySpawnService.SpawnEnemies();
            _playerProvider.AssignPlayer(playerEntity);
            Signals.Get<SignalOpenWindow>().Dispatch(typeof(GameHudWindow));
        }

        public void Update()
        {
            foreach (var system in _updateSystems)
            {
                system.Update();
            }
        }
    }
}