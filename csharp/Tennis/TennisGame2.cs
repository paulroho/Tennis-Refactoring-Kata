using Tennis.Statemachine;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private Statemachine.IState _currentState;

        public TennisGame2()
        {
            _currentState = new Tie(new Score(0));
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                _currentState = _currentState.GetNextIfPlayer1Scores();
            else
                _currentState = _currentState.GetNextIfPlayer2Scores();
        }

        public string GetScore()
        {
            return _currentState.ScoreText;
        }
    }
}

