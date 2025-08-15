using System.Collections.Generic;
using ChessMaze.Interfaces;
using ChessMaze.Models;

namespace ChessMaze.Services.Validation;

public class CompositeValidator : IValidator
{
    private readonly List<IValidator> _validators = new();

    public CompositeValidator Add(IValidator validator)
    {
        _validators.Add(validator);
        return this;
    }

    public bool Validate(Level level, out string message)
    {
        foreach (var v in _validators)
        {
            if (!v.Validate(level, out message))
                return false;
        }

        message = string.Empty;
        return true;
    }
}