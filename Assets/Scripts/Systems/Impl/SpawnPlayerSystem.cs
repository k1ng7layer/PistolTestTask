using Models.Entity;
using Services.PlayerProvider;
using Services.Spawn;
using Supyrb;
using UI.Core.Signals;
using UI.Windows;
using Views.Level;

namespace Systems.Impl
{
    public class SpawnPlayerSystem : IInitializeSystem
    {
        private readonly LevelView _levelView;
        private readonly ISpawnService _spawnService;
        private readonly IPlayerProvider _playerProvider;

        public SpawnPlayerSystem(
            LevelView levelView, 
            ISpawnService spawnService, 
            IPlayerProvider playerProvider
        )
        {
            _levelView = levelView;
            _spawnService = spawnService;
            _playerProvider = playerProvider;
        }
        
        public void Initialize()
        {
            var playerSpawnPos = _levelView.PlayerSpawnTransform.position;
            var player = _spawnService.Spawn("Player", playerSpawnPos);
            var playerEntity = new GameUnit();
            player.Link(playerEntity);
            playerEntity.SetPosition(playerSpawnPos);
            _playerProvider.AssignPlayer(playerEntity);
            
            Signals.Get<SignalOpenWindow>().Dispatch(typeof(GameHudWindow));
        }
    }
}