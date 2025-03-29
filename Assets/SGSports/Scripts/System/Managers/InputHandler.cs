using UnityEngine;

namespace SGSports.System
{
    public static class InputHandler
    {
        private static MainInput _input;
        private static MainInput.PlayerActions _playerActions;
        private static MainInput.PlayerAltActions _playerAltActions;
        private static MainInput.UIActions _uiActions;
        private static MainInput.DeveloperActions _developerActions;

        public static MainInput.PlayerActions PlayerActions => _playerActions;
        public static MainInput.PlayerAltActions PlayerAltActions => _playerAltActions;
        public static MainInput.UIActions UIActions => _uiActions;
        public static MainInput.DeveloperActions DeveloperActions => _developerActions;

        public static void Initialize()
        {
            _input = new MainInput();
            _input.Enable();
            _playerActions = _input.Player;
            _playerAltActions = _input.PlayerAlt;
            _uiActions = _input.UI;
            _developerActions = _input.Developer;
        }
    }
}