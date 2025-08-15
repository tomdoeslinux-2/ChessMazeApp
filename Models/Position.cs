namespace ChessMazeApp.Models;

public readonly struct Position
{
    public int Row { get; }
    public int Col { get; }

    public Position(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public override string ToString() => $"({Row},{Col})";
}
