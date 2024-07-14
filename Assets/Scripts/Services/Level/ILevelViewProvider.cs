using Views.Level;

namespace Services.Level
{
    public interface ILevelViewProvider
    {
        LevelView LevelView { get; }
    }
}