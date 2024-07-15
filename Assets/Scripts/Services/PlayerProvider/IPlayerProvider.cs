using Models;
using Models.Entity;

namespace Services.PlayerProvider
{
    public interface IPlayerProvider
    {
        GameEntity Player { get; }
        void AssignPlayer(GameEntity player);
    }
}