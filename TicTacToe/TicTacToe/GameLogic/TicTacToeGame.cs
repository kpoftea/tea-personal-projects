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

        private Player CurrentTurn { get; set; }

        private int TurnNumber { get; set; }

        private List<GameRound> RoundHistory { get; set; }

        private int BoardSize => 3;

        private int MaxMoves => BoardSize * BoardSize;

        private int MinMovesToWin => BoardSize + BoardSize - 1;

        public TicTacToeGame(string player1Name, string player2Name)
        {
            TicTacToeBoard = new GameBoard()
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
                },
                Positions = new GamePiece?[BoardSize, BoardSize]
            };
            RoundHistory = new List<GameRound>();
            CurrentRound = 0;
            TurnNumber = 0;
        }

        public void StartRound()
        {
            GameState = GameState.InProgress;
            CurrentRound++;
            TurnNumber++;
            if (CurrentRound % 2 == 0)
            {
                // Switch who goes first every other round
                CurrentTurn = TicTacToeBoard.Player2;
            }
            else
            {
                CurrentTurn = TicTacToeBoard.Player1;
            }
            RoundHistory.Add(new GameRound());
        }

        public GameBoard MakeMove(PlayerMove move)
        {
            if (ValidateMove(move) == MoveResult.ValidMove)
            {
                TicTacToeBoard.Positions[move.Position.Item1, move.Position.Item2] = CurrentTurn.GamePiece;
                RoundHistory[CurrentRound].MoveHistory.Add(move);
                TurnNumber++;
            }
            if(TurnNumber >= 5)
            {
                CheckWinState();
            }

            return TicTacToeBoard;
        }

        private void CheckWinState()
        {
            throw new NotImplementedException();
        }

        private MoveResult ValidateMove(PlayerMove move)
        {
            var moveX = move.Position.Item1;
            var moveY = move.Position.Item2;

            // todo: logging or messaging

            if (GameState != GameState.InProgress || RoundHistory[CurrentRound].MoveHistory.Count >= MaxMoves)
            {
                return MoveResult.CannotMove;
            }
            if (TicTacToeBoard.Positions[moveX, moveY] == null)
            {
                return MoveResult.ValidMove;
            }
            return MoveResult.ErrorOccupiedPosition;
        }

        private GameRound UpdateTurnHistory()
        {
            var turn = RoundHistory[CurrentRound].MoveHistory[TurnNumber];
            return RoundHistory[CurrentRound];
        }
    }
}
