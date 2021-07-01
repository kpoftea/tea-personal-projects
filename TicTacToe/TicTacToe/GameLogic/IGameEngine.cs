using TicTacToe.Entities;

namespace TicTacToe.GameLogic
{
    public interface IGameEngine
    {
        void StartRound();
        GameBoard MakeMove(PlayerMove move);
    }
}