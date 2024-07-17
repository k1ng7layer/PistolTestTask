using Services.Input;
using Services.PlayerProvider;
using Services.TimeProvider;
using Settings;
using Settings.Player;
using Settings.Player.Impl;
using UnityEngine;

namespace Systems.Impl
{
    public class PlayerMovementSystem : IUpdateSystem
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IInputService _inputService;
        private readonly ITimeProvider _timeProvider;
        private readonly IPlayerSettings _playerSettings;

        public PlayerMovementSystem(
            IPlayerProvider playerProvider, 
            IInputService inputService,
            ITimeProvider timeProvider,
            IPlayerSettings playerSettings
        )
        {
            _playerProvider = playerProvider;
            _inputService = inputService;
            _timeProvider = timeProvider;
            _playerSettings = playerSettings;
        }
        
        public void Update()
        {
            var input = _inputService.Input;
            var player = _playerProvider.Player;
            
            if (_inputService.Input.sqrMagnitude <= 0 || _playerProvider.Player == null)
                return;
            
            var dir = new Vector3(input.x, input.z, 0f).normalized;
            var position = player.Position + dir * _playerSettings.Speed * _timeProvider.DeltaTime;
            
            player.SetPosition(position);
        }
    }
}