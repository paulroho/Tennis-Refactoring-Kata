namespace Tennis.Statemachine.States
{
    internal class Tie : IState
    {
        private readonly Score _score;

        public Tie(Score score)
        {
            _score = score;
        }

        public string ScoreText
        {
            get
            {
                if (_score.Points < 3)
                {
                    return _score + "-All";
                }
                return "Deuce";
            }
        }

        public IState GetNextIfPlayer1Scores()
        {
            return new APlayerIsAhead(_score.GetNext(), _score, "player1", "player2", player1IsAhead: true);
        }

        public IState GetNextIfPlayer2Scores()
        {
            return new APlayerIsAhead(_score.GetNext(), _score, "player2", "player1", player1IsAhead: false);
        }
    }
}