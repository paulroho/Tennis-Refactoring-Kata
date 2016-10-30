namespace Tennis.Statemachine.States
{
    internal class Player2IsAhead : APlayerIsAhead
    {
        public Player2IsAhead(Score player1Score, Score player2Score)
            : base(player2Score, player1Score, "player2", "player1", player1IsAhead:false)
        { }
    }
}