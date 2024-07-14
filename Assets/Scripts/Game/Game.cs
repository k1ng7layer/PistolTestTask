using Services.EnemySpawn;
using Services.Level;
using Services.Spawn;

namespace Game
{
    public class Game
    {
        private readonly ILevelViewProvider _levelViewProvider;
        private readonly ISpawnService _spawnService;
        private readonly IEnemySpawnService _enemySpawnService;

        public Game(
            ILevelViewProvider levelViewProvider, 
            ISpawnService spawnService, 
            IEnemySpawnService enemySpawnService)
        {
            _levelViewProvider = levelViewProvider;
            _spawnService = spawnService;
            _enemySpawnService = enemySpawnService;
        }
        
        public void Start()
        {
            var playerSpawnPos = _levelViewProvider.LevelView.PlayerSpawnTransform.position;
            var player = _spawnService.Spawn("Player", playerSpawnPos);
            _enemySpawnService.SpawnEnemies();
            
        }
    }
}