using TicTacToe.Entities;

namespace TicTacToe.GameLogic
{
    public interface IGame
    {
        GameBoard StartGame(Player player1, Player player2);
    }
}