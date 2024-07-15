using Models;
using Models.Entity;

namespace Settings.TargetSelection
{
    public interface ITargetSelectionSettings
    {
        UnitGroup AllowedGroups { get; }
    }
}