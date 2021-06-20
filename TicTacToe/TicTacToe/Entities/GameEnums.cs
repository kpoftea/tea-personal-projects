namespace TicTacToe.Entities
{
    public enum GameState
    {
        InProgress = 0, 
        Player1Win = 1, 
        Player2Win = 2, 
        Draw = 3,
        GameError = -1
    }

    public enum GamePiece
    {
        O = 0,
        X = 1
    }

    public enum TileState
    {
        Blank = 0,
        XOccupied = 1,
        OOccupied = 2,
        Error = -1
    }
}
