namespace ChessMazeApp.Models;

public delegate void PieceChangedHandler(object sender, Piece piece);

public class Level
{
    public Position? Start { get; set; }
    public Position? End { get; set; }

    public Board Board { get; }
    public List<Piece> Pieces { get; } = new();

    public event EventHandler<Piece>? PiecePlaced;
    public event PieceChangedHandler? PieceRemoved;

    public Level(int rows, int cols)
    {
        Board = new Board(rows, cols);
    }

    public void PlacePiece(Piece piece)
    {
        Board.PlacePiece(piece);
        Pieces.Add(piece);

        var concrete = piece as Piece;
        PiecePlaced?.Invoke(this, concrete ?? piece);
    }

    public void RemovePiece(Position pos)
    {
        var removed = Board.RemovePiece(pos);
        if (removed is not null)
        {
            Pieces.Remove(removed);
            PieceRemoved?.Invoke(this, removed);
        }
    }

    public void Save(string path, bool includePieces = true)
    {
        using var writer = new System.IO.StreamWriter(path);
        writer.WriteLine($"Board: {Board.Rows}x{Board.Cols}");
        writer.WriteLine($"Start: {Start?.ToString() ?? "(not set)"}");
        writer.WriteLine($"End:   {End?.ToString() ?? "(not set)"}");

        if (includePieces)
        {
            foreach (var p in Pieces)
            {
                writer.WriteLine($"Piece: {p.Type} at {p.Position}");
            }
        }
    }
}