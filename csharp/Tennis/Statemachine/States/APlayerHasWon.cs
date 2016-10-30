namespace Tennis.Statemachine.States
{
    internal abstract class APlayerHasWon : IState
    {
        private readonly string _playerName;

        protected APlayerHasWon(string playerName)
        {
            _playerName = playerName;
        }

        public string ScoreText => "Win for " + _playerName;

        public IState GetNextIfPlayer1Scores()
        {
            throw new System.NotSupportedException($"There is no next score since {_playerName} has already won.");
        }

        public IState GetNextIfPlayer2Scores()
        {
            throw new System.NotSupportedException($"There is no next score since {_playerName} has already won.");
        }
    }
}