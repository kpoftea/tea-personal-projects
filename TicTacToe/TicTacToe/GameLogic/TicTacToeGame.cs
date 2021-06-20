using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Entities;

namespace TicTacToe.GameLogic
{
    public class TicTacToeGame : IGame
    {
        private GameBoard TicTacToeBoard { get; set; }

        private GameState GameState { get; set; }

        private int CurrentRound { get; set; }

        private List<GameRound> RoundHistory { get; set; }

        public TicTacToeGame(string player1Name, string player2Name)
        {
            this.TicTacToeBoard = new GameBoard()
            {
                Player1 = new Player()
                {
                    Name = player1Name,
                    GamePiece = GamePiece.X
                },
                Player2 = new Player()
                {
                    Name = player2Name,
                    GamePiece = GamePiece.O
                }
            };
            this.RoundHistory = new List<GameRound>();
            this.GameState = GameState.InProgress;
            this.CurrentRound = 0;
        }       

        public void StartGame()
        {
            this.CurrentRound++;
            this.RoundHistory.Add(new GameRound());
        }

        public GameBoard MakeMove(PlayerMove move)
        {
            throw new NotImplementedException();
        }
    }
}
