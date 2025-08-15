using ChessMazeApp.Models;
using ChessMazeApp.Services.Validation;

namespace ChessMazeApp.Services.Validation;

public class LoudValidator : PiecePresenceValidator
{
    public new bool Validate(Level level, out string message)
    {
        var ok = base.Validate(level, out message);
        message = ok ? "OK (loud)" : $"INVALID (loud): {message}";
        return ok;
    }
}