using ChessMazeApp.Interfaces;
using ChessMazeApp.Models;

namespace ChessMazeApp.Services.Validation;

public static class ValidationRunner
{
    public static (bool Ok, string Message) Run(IValidator validator, Level level)
    {
        try
        {
            var ok = validator.Validate(level, out var msg);
            return (ok, msg);
        }
        catch (Exception ex) when (ex is OverlapException || ex is OutOfBoundsException)
        {
            return (false, ex.Message);
        }
    }
}