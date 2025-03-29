namespace SGSports.System
{
    public static class InputHandler
    {
        private static MainInput _input;
        private static MainInput.FootballActions _footballActions;
        private static MainInput.FootballAltActions _footballAltActions;
        private static MainInput.TennisActions _tennisActions;
        private static MainInput.TennisAltActions _tennisAltActions;
        private static MainInput.UIActions _uiActions;
        private static MainInput.DeveloperActions _developerActions;

        public static MainInput.FootballActions FootballActions => _footballActions;
        public static MainInput.FootballAltActions FootballAltActions => _footballAltActions;
        public static MainInput.TennisActions TennisActions => _tennisActions;
        public static MainInput.TennisAltActions TennisAltActions => _tennisAltActions;
        public static MainInput.UIActions UIActions => _uiActions;
        public static MainInput.DeveloperActions DeveloperActions => _developerActions;

        public static void Initialize()
        {
            _input = new MainInput();
            _input.Enable();
            _footballActions = _input.Football;
            _footballAltActions = _input.FootballAlt;
            _tennisActions = _input.Tennis;
            _tennisAltActions = _input.TennisAlt;
            _uiActions = _input.UI;
            _developerActions = _input.Developer;
        }
    }
}