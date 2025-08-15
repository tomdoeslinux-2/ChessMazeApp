using ChessMazeApp.Models;

namespace ChessMazeApp.Services.Validation;

public class PiecePresenceValidator : LevelValidator
{
    public sealed override bool Validate(Level level, out string message)
    {
        if (!base.Validate(level, out message))
            return false;

        if (level.Pieces.Count == 0)
        {
            message = "At least one piece must be placed.";
            return false;
        }

        message = string.Empty;
        return true;
    }
}