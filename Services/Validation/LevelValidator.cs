using ChessMaze.Interfaces;
using ChessMaze.Models;

namespace ChessMaze.Services.Validation;

public class LevelValidator : IValidator
{
    public virtual bool Validate(Level level, out string message)
    {
        if (level is null)
        {
            message = "Level is null.";
            return false;
        }

        if (level.Start is null || level.End is null)
        {
            message = "Start and End must be set.";
            return false;
        }

        if (level.Start is Position s && level.End is Position e && s.Equals(e))
        {
            message = "Start and End cannot be the same.";
            return false;
        }

        message = string.Empty;
        return true;
    }
}