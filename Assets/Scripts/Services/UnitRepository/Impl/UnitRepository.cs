using System;
using System.Collections.Generic;
using Models.Entity;

namespace Services.UnitRepository.Impl
{
    public class UnitRepository : IUnitRepository
    {
        private readonly List<GameUnit> _entities = new();

        public IReadOnlyList<GameUnit> Entities => _entities;
        public event Action<GameUnit> Added;
        public event Action<GameUnit> Removed;

        public void Add(GameUnit entity)
        {
            _entities.Add(entity);
            Added?.Invoke(entity);
        }

        public bool Remove(GameUnit entity)
        {
            return _entities.Remove(entity);
        }
    }
}