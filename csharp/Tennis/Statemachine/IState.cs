namespace Tennis.Statemachine
{
    internal interface IState
    {
        string ScoreText { get; }
        IState GetNextIfPlayer1Scores();
        IState GetNextIfPlayer2Scores();
    }
}