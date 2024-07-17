using Models.Entity;
using Services.Spawn;
using Services.UnitRepository;
using Views.Level;

namespace Services.EnemySpawn.Impl
{
    public class EnemySpawnService : IEnemySpawnService
    {
        private readonly LevelView _levelView;
        private readonly ISpawnService _spawnService;
        private readonly IUnitRepository _unitRepository;

        public EnemySpawnService(
            LevelView levelView, 
            ISpawnService spawnService,
            IUnitRepository unitRepository)
        {
            _levelView = levelView;
            _spawnService = spawnService;
            _unitRepository = unitRepository;
        }
        
        public void SpawnEnemies()
        {
            foreach (var enemySpawnSetting in _levelView.EnemySpawnSettings)
            {
                var enemyView = _spawnService.Spawn(enemySpawnSetting.EnemyType.ToString(),
                    enemySpawnSetting.SpawnTransform.position);
                
                var enemy = new GameUnit();
                enemyView.Link(enemy);
                
                _unitRepository.Add(enemy);
            }
        }
    }
}