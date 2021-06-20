namespace TicTacToe.Entities
{
    public class Player
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public GamePiece GamePiece { get; set; } 
    }
}
