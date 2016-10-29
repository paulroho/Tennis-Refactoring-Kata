namespace Tennis.Statemachine
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
            return new Player1IsAhead(_score.GetNext(), _score);
        }

        public IState GetNextIfPlayer2Scores()
        {
            return new Player2IsAhead(_score, _score.GetNext());
        }
    }
}