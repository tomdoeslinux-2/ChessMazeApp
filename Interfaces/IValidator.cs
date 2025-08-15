public interface IValidator
{
    bool Validate(Level level, out string message);
}