using ChessMazeApp.Models;

namespace ChessMazeApp.Interfaces;

public interface IValidator
{
    bool Validate(Level level, out string message);
}