using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

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
        bag.Size = $"{level.Board.Rows}x{level.Board.Cols}";
        bag.PieceCount = level.Pieces.Count;
        bag.Start = level.Start?.ToString();
        bag.End = level.End?.ToString();
        return bag;
    }
}