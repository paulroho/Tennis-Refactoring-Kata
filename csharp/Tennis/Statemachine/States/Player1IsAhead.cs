namespace Tennis.Statemachine.States
{
    internal class Player1IsAhead : APlayerIsAhead
    {
        public Player1IsAhead(Score player1Score, Score player2Score)
            : base(player1Score, player2Score, "player1", "player2", player1IsAhead:true)
        { }
    }
}