using System.Collections.Generic;
using Models;
using Models.Entity;

namespace Services.UnitRepository
{
    public interface IUnitRepository
    {
        IReadOnlyList<GameEntity> Entities { get; }
    }
}