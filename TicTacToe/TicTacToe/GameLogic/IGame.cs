using TicTacToe.Entities;

namespace TicTacToe.GameLogic
{
    public interface IGame
    {
        void StartRound();
        GameBoard MakeMove(PlayerMove move);
    }
}