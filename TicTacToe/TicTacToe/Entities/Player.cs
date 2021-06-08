namespace TicTacToe.Entities
{
    public class Player
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public GamePieceEnums GamePiece { get; set; } 
    }
}
