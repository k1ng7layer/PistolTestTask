using System.Collections.Generic;
using Models;
using Models.Entity;

namespace Services.UnitRepository.Impl
{
    public class UnitRepository : IUnitRepository
    {
        private readonly List<GameEntity> _entities = new();

        public IReadOnlyList<GameEntity> Entities => _entities;

        public void Add(GameEntity entity)
        {
            _entities.Add(entity);
        }

        public bool Remove(GameEntity entity)
        {
            return _entities.Remove(entity);
        }
    }
}