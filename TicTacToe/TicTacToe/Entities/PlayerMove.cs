using System;

namespace TicTacToe.Entities
{
    public class PlayerMove
    {
        public Tuple<int, int> Position { get; set; }
        public GamePiece Piece { get; set; }
    }
}
