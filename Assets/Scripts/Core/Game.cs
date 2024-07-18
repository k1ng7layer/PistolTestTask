using System.Collections.Generic;
using Systems;

namespace Core
{
    public class Game
    {
        private readonly List<IUpdateSystem> _updateSystems = new();
        private readonly List<IInitializeSystem> _initializeSystems = new();

        public Game(List<ISystem> systems)
        {
            foreach (var system in systems)
            {
                if (system is IInitializeSystem initializeSystem)
                    _initializeSystems.Add(initializeSystem);
                
                if (system is IUpdateSystem updateSystem)
                    _updateSystems.Add(updateSystem);
            }
        }
        
        public void Start()
        {
            foreach (var initializeSystem in _initializeSystems)
            {
                initializeSystem.Initialize();
            }
        }

        public void Update()
        {
            foreach (var system in _updateSystems)
            {
                system.Update();
            }
        }
    }
}