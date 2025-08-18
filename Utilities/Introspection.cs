using System.Dynamic;
using System.Reflection;
using ChessMazeApp.Models;

public static class Introspection
{
    public static IEnumerable<string> GetPublicProperties<T>() =>
        typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name);

    public static int BoxUnboxDemo(int value)
    {
        object boxed = value;
        int unboxed = (int)boxed;
        return unboxed;
    }

    public static dynamic BuildDynamicLevelSummary(Level level)
    {
        dynamic bag = new ExpandoObject();
        bag.Size = $"{level.Board.Row_Num}x{level.Board.Col_num}";
        bag.PieceCount = level.Pieces.Count;
        bag.Start = level.Start?.ToString();
        bag.End = level.End?.ToString();
        return bag;
    }
}