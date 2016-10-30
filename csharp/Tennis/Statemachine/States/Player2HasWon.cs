namespace Tennis.Statemachine.States
{
    internal class Player2HasWon : IState
    {
        public string ScoreText { get { return "Win for player2"; } }

        public IState GetNextIfPlayer1Scores()
        {
            throw new System.NotSupportedException("There is no next score since player 2 has already won.");
        }

        public IState GetNextIfPlayer2Scores()
        {
            throw new System.NotSupportedException("There is no next score since player 2 has already won.");
        }
    }
}