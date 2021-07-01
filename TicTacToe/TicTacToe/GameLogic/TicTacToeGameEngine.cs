using System.Collections.Generic;
using TicTacToe.Entities;

namespace TicTacToe.GameLogic
{
    public class TicTacToeGameEngine : IGameEngine
    {
        private GameBoard TicTacToeBoard { get; set; }

        private GameState GameState { get; set; }

        private int CurrentRound { get; set; }

        private Player CurrentTurn { get; set; }

        private int TurnNumber { get; set; }

        public List<GameRound> RoundHistory { get; private set; }

        private int BoardSize => 3;

        private int MaxMoves => BoardSize * BoardSize;

        private int MinMovesToWin => BoardSize + BoardSize - 1;

        private int XWonValue => (int)GamePiece.X * BoardSize;

        private int OWonValue => (int)GamePiece.O * BoardSize;

        public TicTacToeGameEngine(string player1Name, string player2Name)
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
            TurnNumber = 1;
            if (CurrentRound % 2 == 0)
            {
                // Switch who goes first every other round
                CurrentTurn = TicTacToeBoard.Player2;
            }
            else
            {
                CurrentTurn = TicTacToeBoard.Player1;
            }
            RoundHistory.Add(new GameRound() { MoveHistory = new List<PlayerMove>() });
        }

        public GameBoard MakeMove(PlayerMove move)
        {
            if (ValidateMove(move) == MoveResult.ValidMove)
            {
                TicTacToeBoard.Positions[move.Position.Item1, move.Position.Item2] = CurrentTurn.GamePiece;
                RoundHistory[CurrentRound-1].MoveHistory.Add(move);
                UpdateTurnHistory(move);
                TurnNumber++;
            }
            if(TurnNumber >= MinMovesToWin)
            {
                GameState = CheckGameState();
            }

            return TicTacToeBoard;
        }

        private GameState CheckWinValue(int pieceScore)
        {
            // check values for a win
            if (pieceScore == XWonValue)
            {
                // set X won
                return GameState.Player1Win;
            }
            if (pieceScore == OWonValue)
            {
                // set O won
                return GameState.Player2Win;
            }
            return GameState.InProgress;
        }

        private GameState CheckGameState()
        {
            if(TurnNumber <= 9)
            {
                // check vertical
                int piecesValue;
                for(int x = 0; x < BoardSize; x++)
                {
                    piecesValue = 0;
                    for (int y = 0; y < BoardSize; y++)
                    {
                        var piece = TicTacToeBoard.Positions[x, y];
                        
                        if(piece == null) // streak stopped, move to next line
                        {
                            piecesValue = 0;
                            break;
                        }
                        piecesValue += (int)piece;
                    }
                    var verticalCheckResult = CheckWinValue(piecesValue);
                    if(verticalCheckResult != GameState.InProgress)
                    {
                        return verticalCheckResult;
                    }
                    //else check next line
                }
                // check horizontal
                for (int x = 0; x < BoardSize; x++)
                {
                    piecesValue = 0;
                    for (int y = 0; y < BoardSize; y++)
                    {
                        var piece = TicTacToeBoard.Positions[y, x];

                        if (piece == null) // streak stopped, move to next line
                        {
                            piecesValue = 0;
                            break;
                        }
                        piecesValue += (int)piece;
                    }
                    var horizontalCheckResult = CheckWinValue(piecesValue);
                    if (horizontalCheckResult != GameState.InProgress)
                    {
                        return horizontalCheckResult;
                    }
                    //else check next line
                }
                // check downwards diagonal
                piecesValue = 0;
                for (int x = 0; x < BoardSize; x++)
                {
                    var piece = TicTacToeBoard.Positions[x, x];

                    if (piece == null) // streak stopped, no win
                    {
                        break;
                    }
                    piecesValue += (int)piece;
                    var downwardsDiagonalCheckResult = CheckWinValue(piecesValue);
                    if (downwardsDiagonalCheckResult != GameState.InProgress)
                    {
                        return downwardsDiagonalCheckResult;
                    }
                    //else  check next row
                }
                // check upwards diagonal
                for (int x = 0; x < BoardSize; x++)
                {
                    piecesValue = 0;
                    for (int y = 2; y > 0; y--)
                    {
                        var piece = TicTacToeBoard.Positions[x, y];

                        if (piece == null) // streak stopped, no win
                        {
                            break;
                        }
                        piecesValue += (int)piece;
                    }
                    var upwardsDiagonalCheckResult = CheckWinValue(piecesValue);
                    if (upwardsDiagonalCheckResult != GameState.InProgress)
                    {
                        return upwardsDiagonalCheckResult;
                    }
                    //else  check next row
                }
                if (TurnNumber == 9)
                {
                    return GameState.Draw;
                }
                return GameState.InProgress;
            }
            return GameState.GameError; // max moves exceeded
        }

        private MoveResult ValidateMove(PlayerMove move)
        {
            var moveX = move.Position.Item1;
            var moveY = move.Position.Item2;

            // todo: logging or messaging

            if (GameState != GameState.InProgress || RoundHistory[CurrentRound-1].MoveHistory?.Count >= MaxMoves)
            {
                return MoveResult.CannotMove;
            }
            if (moveX < BoardSize && moveX >= 0 && moveY < BoardSize && moveY >= 0 && TicTacToeBoard.Positions[moveX, moveY] == null)
            {
                return MoveResult.ValidMove;
            }
            return MoveResult.ErrorOccupiedPosition;
        }

        private void UpdateTurnHistory(PlayerMove move)
        {
            RoundHistory[CurrentRound-1].MoveHistory.Add(move);
        }
    }
}
