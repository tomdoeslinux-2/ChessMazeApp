public class LevelValidator
{
    public bool Validate(Level level, out string message)
    {
        if (level.Start is { } start && level.End is { } end && start.Equals(end))
        {
            message = "Start and End positions cannot be the same.";
            return false;
        }

        if (level.Pieces.Count == 0)
        {
            message = "No pieces placed.";
            return false;
        }

        message = string.Empty;
        return true;
    }
}