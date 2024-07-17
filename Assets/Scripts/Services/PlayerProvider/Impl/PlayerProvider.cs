using Models.Entity;

namespace Services.PlayerProvider.Impl
{
    public class PlayerProvider : IPlayerProvider
    {
        public GameEntity Player { get; private set; }
        
        public void AssignPlayer(GameEntity player)
        {
            Player = player;
        }
    }
}