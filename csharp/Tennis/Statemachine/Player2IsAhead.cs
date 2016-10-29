namespace Tennis.Statemachine
{
    internal class Player2IsAhead : IState
    {
        private readonly Score _player1Score;
        private readonly Score _player2Score;

        public Player2IsAhead(Score player1Score, Score player2Score)
        {
            _player1Score = player1Score;
            _player2Score = player2Score;
        }

        public string ScoreText
        {
            get
            {
                if (_player2Score.Points < 4)
                {
                    return _player1Score + "-" + _player2Score;
                }
                return "Advantage player2";
            }
        }

        public IState GetNextIfPlayer1Scores()
        {
            return new Tie(_player1Score.GetNext());
        }

        public IState GetNextIfPlayer2Scores()
        {
            if (_player2Score.Points < 3)
                return new Player2IsAhead(_player1Score, _player2Score.GetNext());
            return new Player2HasWon();
        }
    }
}