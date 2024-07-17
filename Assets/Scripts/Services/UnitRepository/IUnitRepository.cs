using System.Collections.Generic;
using Models.Entity;

namespace Services.UnitRepository
{
    public interface IUnitRepository
    {
        IReadOnlyList<GameUnit> Entities { get; }
        void Add(GameUnit entity);
        bool Remove(GameUnit entity);
    }
}