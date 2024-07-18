using Models.Entity;
using Services.Spawn;
using Services.UnitRepository;
using Views.Level;

namespace Systems.Impl
{
    public class SpawnEnemiesSystem : IInitializeSystem
    {
        private readonly LevelView _levelView;
        private readonly ISpawnService _spawnService;
        private readonly IUnitRepository _unitRepository;

        public SpawnEnemiesSystem(
            LevelView levelView, 
            ISpawnService spawnService, 
            IUnitRepository unitRepository
        )
        {
            _levelView = levelView;
            _spawnService = spawnService;
            _unitRepository = unitRepository;
        }
        
        public void Initialize()
        {
            foreach (var enemySpawnSetting in _levelView.EnemySpawnSettings)
            {
                var enemyView = _spawnService.Spawn(enemySpawnSetting.EnemyType.ToString(),
                    enemySpawnSetting.SpawnTransform.position);
                
                var enemy = new GameUnit();
                enemyView.Link(enemy);
                enemy.SetPosition(enemySpawnSetting.SpawnTransform.position);
                
                _unitRepository.Add(enemy);
            }
        }
    }
}