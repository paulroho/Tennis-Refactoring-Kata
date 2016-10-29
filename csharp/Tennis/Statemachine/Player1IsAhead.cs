namespace Tennis.Statemachine
{
    internal class Player1IsAhead : IState
    {
        private readonly Score _player1Score;
        private readonly Score _player2Score;

        public Player1IsAhead(Score player1Score, Score player2Score)
        {
            _player1Score = player1Score;
            _player2Score = player2Score;
        }

        public string ScoreText
        {
            get
            {
                if (_player1Score.Points < 4)
                {
                    return _player1Score + "-" + _player2Score;
                }
                return "Advantage player1";
            }
        }

        public IState GetNextIfPlayer1Scores()
        {
            if (_player1Score.Points < 3)
                return new Player1IsAhead(_player1Score.GetNext(), _player2Score);
            return new Player1HasWon();
        }

        public IState GetNextIfPlayer2Scores()
        {
            if (_player2Score.Points == _player1Score.Points - 1)
                return new Tie(_player2Score.GetNext());
            return new Player1IsAhead(_player1Score, _player2Score.GetNext());
        }
    }
}