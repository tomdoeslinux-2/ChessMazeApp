using ChessMazeApp.Models;

namespace ChessMazeApp.Interfaces;

public interface IValidator
{
    bool Validate(Level lvl, out string msg);
}