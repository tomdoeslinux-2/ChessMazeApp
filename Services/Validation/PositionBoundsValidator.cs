using ChessMazeApp.Interfaces;
using ChessMazeApp.Models;

namespace ChessMazeApp.Services.Validation;

public class PositionBoundsValidator : IValidator
{
    public bool Validate(Level level, out string message)
    {
        if (level.Start is Position s && !level.Board.IsValidPosition(in s))
        {
            message = $"Start {s} is outside the board.";
            return false;
        }

        if (level.End is Position e && !level.Board.IsValidPosition(in e))
        {
            message = $"End {e} is outside the board.";
            return false;
        }

        message = string.Empty;
        return true;
    }
}

