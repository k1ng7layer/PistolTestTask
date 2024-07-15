using Models;

namespace Settings.TargetSelection
{
    public interface ITargetSelectionSettings
    {
        UnitGroup AllowedGroups { get; }
    }
}