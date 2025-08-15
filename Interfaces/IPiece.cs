using ChessMazeApp.Models;

namespace ChessMazeApp.Interfaces;

public interface IPiece
{
    PieceType Type { get; }
    Position Position { get; set; }
}