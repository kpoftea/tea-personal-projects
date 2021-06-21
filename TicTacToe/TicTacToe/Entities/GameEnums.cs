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
        X = 1,
        O = 2
    }

    public enum MoveResult
    {
        CannotMove = 0,
        ValidMove = 1, 
        ErrorOccupiedPosition = -1, 
    }
}
