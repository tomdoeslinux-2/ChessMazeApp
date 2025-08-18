using ChessMazeApp.Models;

namespace ChessMazeApp.Interfaces;

public interface IBoard
{
    int Row_Num { get; }
    int Col_num { get; }

    Piece? this[int row, int col] { get; set; }

    bool PositionValid(in Position p);
}
