using TicTacToe.Entities;

namespace TicTacToe.GameLogic
{
    public interface IGame
    {
        void StartGame();
        GameBoard MakeMove(PlayerMove move);
    }
}