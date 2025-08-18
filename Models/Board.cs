using ChessMazeApp.Interfaces;

namespace ChessMazeApp.Models;

public class Board : IBoard
{
    private readonly Piece?[,] _grid;
    public int Row_Num { get; }
    public int Col_num { get; }

    public Board(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0) throw new BoardSizeException(rows, cols);
        Row_Num = rows;
        Col_num = cols;
        _grid = new Piece?[rows, cols];
    }

    public Piece? this[int row, int col]
    {
        get => _grid[row, col];
        set => _grid[row, col] = value;
    }

    public ref Piece? CellRef(int row, int col) => ref _grid[row, col];

    public bool PositionValid(in Position pos) =>
        pos.Row >= 0 && pos.Row < Row_Num && pos.Col >= 0 && pos.Col < Col_num;

    public PieceType? GetPieceTypeOrNull(int row, int col) => this[row, col]?.Type;

    public void PlacePiece(Piece piece)
    {
        if (!PositionValid(piece.Position)) throw new OutOfBoundsException(piece.Position, Row_Num, Col_num);
        ref var cell = ref CellRef(piece.Position.Row, piece.Position.Col);
        if (cell is not null) throw new OverlapException(piece.Position);
        cell = piece;
    }

    public Piece? RemovePiece(Position pos)
    {
        if (!PositionValid(pos)) throw new OutOfBoundsException(pos, Row_Num, Col_num);
        ref var cell = ref CellRef(pos.Row, pos.Col);
        var removed = cell;
        cell = null;
        return removed;
    }
}

public class BoardSizeException(int rows, int cols) : Exception($"Board size invalid: {rows}x{cols}.")
{
}
public class OutOfBoundsException(Position pos, int rows, int cols) : Exception($"Position {pos} is outside bounds [0..{rows-1}, 0..{cols-1}].")
{
}
public class OverlapException(Position pos) : Exception($"Cell {pos} already occupied.")
{
}