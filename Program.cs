// Program.cs
using ChessMazeApp.Interfaces;
using ChessMazeApp.Models;
using ChessMazeApp.Services;
using ChessMazeApp.Services.Validation;

var level = new Level(rows: 5, cols: 5)
{
    Start = new Position(0, 0),
    End   = new Position(4, 4)
};

level.PiecePlaced  += (s, p) => Console.WriteLine($"Placed: {p.Type} at {p.Position}");
level.PieceRemoved += (s, p) => Console.WriteLine($"Removed: {p.Type} at {p.Position}");

var knight = new Piece(PieceType.Knight, new Position(2, 3));
level.PlacePiece(knight);

level.Save(path: "level.txt", includePieces: true);
Console.WriteLine("Saved level.txt");

IValidator validator = new PiecePresenceValidator();
var (ok, msg) = ValidationRunner.Run(validator, level);
Console.WriteLine(ok ? "Level valid ✅" : $"Level invalid ❌: {msg}");

var (ok2, msg2) = ValidationRunner.Run(new PositionBoundsValidator(), level);
Console.WriteLine(ok2 ? "Bounds valid ✅" : $"Bounds invalid ❌: {msg2}");

var undo = new UndoService();
undo.addUndoToStack(() => level.RemovePiece(new Position(2, 3)));
var undone = undo.Undo();
Console.WriteLine(undone ? "Undo done." : "Nothing to undo.");

Console.WriteLine("Piece props: " + string.Join(", ", Introspection.GetPublicProperties<Piece>()));
Console.WriteLine("Box-unbox demo: " + Introspection.BoxUnboxDemo(42));
dynamic summary = Introspection.BuildDynamicLevelSummary(level);
Console.WriteLine($"Dynamic summary: size={summary.Size}, count={summary.PieceCount}, start={summary.Start}, end={summary.End}");

ref var cell = ref level.Board.CellRef(2, 3);
if (cell is null)
{
    cell = new Piece(PieceType.Bishop, new Position(2, 3));
    Console.WriteLine("Placed Bishop via ref cell.");
}

var log = new LogEntry(1, "Demo finished");
Console.WriteLine(log);

public class LogEntry(int id, string message)
{
    public int Id { get; } = id;
    public string Message { get; } = message;
    public override string ToString() => $"[{Id}] {Message}";
}