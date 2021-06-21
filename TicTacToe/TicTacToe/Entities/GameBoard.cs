namespace TicTacToe.Entities
{
    public class GameBoard
    {
        public GamePiece?[,] Positions { get; set; }

        public Player Player1 { get; set; } // goes first

        public Player Player2 { get; set; }       
    }
}
