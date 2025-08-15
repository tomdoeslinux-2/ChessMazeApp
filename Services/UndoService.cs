namespace ChessMazeApp.Services;

public class UndoService
{
    private readonly Stack<Action> _undo = new();

    public void AddUndo(Action action) => _undo.Push(action);

    public bool Undo()
    {
        if (_undo.Count == 0) return false;
        _undo.Pop().Invoke();
        return true;
    }

    public static Stack<T> ToStack<T>(IEnumerable<T> items) => new(items);
}