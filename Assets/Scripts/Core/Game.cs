using System.Collections.Generic;
using Services.EnemySpawn;
using Services.Level;
using Services.Spawn;
using Systems;
using Views.Level;

namespace Core
{
    public class Game
    {
        private readonly LevelView _levelViewProvider;
        private readonly ISpawnService _spawnService;
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly List<IUpdateSystem> _updateSystems;

        public Game(
            LevelView levelViewProvider, 
            ISpawnService spawnService, 
            IEnemySpawnService enemySpawnService,
            List<IUpdateSystem> updateSystems)
        {
            _levelViewProvider = levelViewProvider;
            _spawnService = spawnService;
            _enemySpawnService = enemySpawnService;
            _updateSystems = updateSystems;
        }
        
        public void Start()
        {
            var playerSpawnPos = _levelViewProvider.PlayerSpawnTransform.position;
            var player = _spawnService.Spawn("Player", playerSpawnPos);
            _enemySpawnService.SpawnEnemies();
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