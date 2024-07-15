using System;
using Models;
using Models.Entity;
using Services.PlayerProvider;
using Services.UnitRepository;
using Services.Weapon;
using Settings.TargetSelection;

namespace Services.Target.Impl
{
    public class SelectNearestTargetService : ITargetSelectService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly ITargetSelectionSettings _targetSelectionSettings;
        private readonly IWeaponService _weaponService;
        private readonly IPlayerProvider _playerProvider;

        public SelectNearestTargetService(
            IUnitRepository unitRepository, 
            ITargetSelectionSettings targetSelectionSettings,
            IWeaponService weaponService,
            IPlayerProvider playerProvider
        )
        {
            _unitRepository = unitRepository;
            _targetSelectionSettings = targetSelectionSettings;
            _weaponService = weaponService;
            _playerProvider = playerProvider;
        }
        
        public GameEntity SelectTarget()
        {
            var playerPosition = _playerProvider.Player.Position;
            GameEntity nearest = null;
            float nearestDist = float.MaxValue;
            
            foreach (var entity in _unitRepository.Entities)
            {
                var weaponRadius2 = _weaponService.CurrentWeaponEntity.ShootRadius * 
                                    _weaponService.CurrentWeaponEntity.ShootRadius;
                
                var dist2 = (entity.Position - playerPosition).sqrMagnitude;
                
                if (dist2 > weaponRadius2)
                    continue;
                
                if (!entity.UnitGroup.HasFlag(_targetSelectionSettings.AllowedGroups))
                    continue;
                
                if (dist2 <= nearestDist)
                {
                    nearestDist = dist2;
                    nearest = entity;
                }
            }

            return nearest;
        }
    }
}