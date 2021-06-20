using System.Collections.Generic;
using TicTacToe.Entities;

namespace TicTacToe.GameLogic
{
    public class GameRound
    {
        public List<PlayerMove> MoveHistory { get; set; }
        public GameState GameEndState { get; set; }
    }
}