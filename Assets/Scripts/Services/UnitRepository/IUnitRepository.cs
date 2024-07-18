using System;
using System.Collections.Generic;
using Models.Entity;

namespace Services.UnitRepository
{
    public interface IUnitRepository
    {
        IReadOnlyList<GameUnit> Entities { get; }
        event Action<GameUnit> Added;
        event Action<GameUnit> Removed;
        void Add(GameUnit entity);
        bool Remove(GameUnit entity);
    }
}