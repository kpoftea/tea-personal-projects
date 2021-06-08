using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Entities;

namespace TicTacToe.GameLogic
{
    public class TicTacToeGame : IGame
    {
        public GameBoard StartGame(Player player1, Player player2)
        {
            var board = new GameBoard();

            return board;
        }
    }
}
