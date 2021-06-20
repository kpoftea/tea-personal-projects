using System;

namespace TicTacToe.Entities
{
    public class PlayerMove
    {
        public Player Player { get; set; }
        public Tuple<int> Position { get; set; }
        public bool ValidMove { get; set; }
    }
}
