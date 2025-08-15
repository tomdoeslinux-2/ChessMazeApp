public interface IBoard
{
    int Rows { get; }
    int Cols { get; }

    Piece? this[int row, int col] { get; set; }

    bool IsValidPosition(in Position pos);
}
