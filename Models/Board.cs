public class Board : IBoard
{
    private readonly Piece?[,] _grid;
    public int Rows { get; }
    public int Cols { get; }

    public Board(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0) throw new BoardSizeException(rows, cols);
        Rows = rows;
        Cols = cols;
        _grid = new Piece?[rows, cols];
    }

    public Piece? this[int row, int col]
    {
        get => _grid[row, col];
        set => _grid[row, col] = value;
    }

    public ref Piece? CellRef(int row, int col) => ref _grid[row, col];

    public bool IsValidPosition(in Position pos) =>
        pos.Row >= 0 && pos.Row < Rows && pos.Col >= 0 && pos.Col < Cols;

    public PieceType? GetPieceTypeOrNull(int row, int col) => this[row, col]?.Type;

    public void PlacePiece(Piece piece)
    {
        if (!IsValidPosition(piece.Position)) throw new OutOfBoundsException(piece.Position, Rows, Cols);
        ref var cell = ref CellRef(piece.Position.Row, piece.Position.Col);
        if (cell is not null) throw new OverlapException(piece.Position);
        cell = piece;
    }

    public Piece? RemovePiece(Position pos)
    {
        if (!IsValidPosition(pos)) throw new OutOfBoundsException(pos, Rows, Cols);
        ref var cell = ref CellRef(pos.Row, pos.Col);
        var removed = cell;
        cell = null;
        return removed;
    }
}

public class BoardSizeException : Exception
{
    public BoardSizeException(int rows, int cols) 
        : base($"Board size invalid: {rows}x{cols}.") { }
}
public class OutOfBoundsException : Exception
{
    public OutOfBoundsException(Position pos, int rows, int cols)
        : base($"Position {pos} is outside bounds [0..{rows-1}, 0..{cols-1}].") { }
}
public class OverlapException : Exception
{
    public OverlapException(Position pos) : base($"Cell {pos} already occupied.") { }
}