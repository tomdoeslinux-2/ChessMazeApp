using ChessMazeApp.Interfaces;

namespace ChessMazeApp.Models;

public class Piece : IPiece
{
    public PieceType Type { get; init; }
    public Position Position { get; set; }

    public Piece(PieceType type, Position position)
    {
        Type = type;
        Position = position;
    }
}