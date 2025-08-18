namespace ChessMazeApp.Services;

public class UndoService
{
    private readonly Stack<Action> _undoStack = new();

    public void addUndoToStack(Action action) => _undoStack.Push(action);

    public bool Undo()
    {
        if (_undoStack.Count == 0) return false;
        _undoStack.Pop().Invoke();
        return true;
    }

    public static Stack<T> ToStack<T>(IEnumerable<T> items) => new(items);
}