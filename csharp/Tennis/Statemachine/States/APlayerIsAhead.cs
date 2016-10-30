namespace Tennis.Statemachine.States
{
    internal class APlayerIsAhead : IState
    {
        private readonly Score _playerAheadScore;
        private readonly Score _playerBehindScore;
        private readonly string _playerAheadName;
        private readonly string _playerBehindName;
        private readonly bool _player1IsAhead;

        protected APlayerIsAhead(Score playerAheadScore, Score playerBehindScore, string playerAheadName, string playerBehindName, bool player1IsAhead)
        {
            _playerAheadScore = playerAheadScore;
            _playerBehindScore = playerBehindScore;
            _playerAheadName = playerAheadName;
            _playerBehindName = playerBehindName;
            _player1IsAhead = player1IsAhead;
        }

        public string ScoreText
        {
            get
            {
                if (_playerAheadScore.Points < 4)
                {
                    return _player1IsAhead
                        ? _playerAheadScore + "-" + _playerBehindScore
                        : _playerBehindScore + "-" + _playerAheadScore;
                }
                return $"Advantage {_playerAheadName}";
            }
        }

        public IState GetNextIfPlayer1Scores()
        {
            return _player1IsAhead
                ? AdvanceEvenMore()
                : LetPlayerBehindCatchUp();
        }

        public IState GetNextIfPlayer2Scores()
        {
            return _player1IsAhead
                ? LetPlayerBehindCatchUp()
                : AdvanceEvenMore();
        }

        private IState AdvanceEvenMore()
        {
            if (_playerAheadScore.Points < 3)
                return new APlayerIsAhead(_playerAheadScore.GetNext(), _playerBehindScore, _playerAheadName, _playerBehindName, _player1IsAhead);
            return new APlayerHasWon(_playerAheadName);
        }

        private IState LetPlayerBehindCatchUp()
        {
            if (_playerBehindScore.Points == _playerAheadScore.Points - 1)
                return new Tie(_playerBehindScore.GetNext());
            return new APlayerIsAhead(_playerAheadScore, _playerBehindScore.GetNext(), _playerAheadName, _playerBehindName, _player1IsAhead);
        }
    }
}