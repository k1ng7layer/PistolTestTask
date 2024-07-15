using System.Collections.Generic;
using Models;

namespace Services.UnitRepository
{
    public interface IUnitRepository
    {
        IReadOnlyList<GameEntity> Entities { get; }
    }
}