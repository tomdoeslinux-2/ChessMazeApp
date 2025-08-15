public record Move(Position From, Position To, Piece? PieceMoved, Piece? PieceCaptured = null)
{
    public override string ToString() =>
        $"{PieceMoved?.Type} from {From} to {To}" + (PieceCaptured is not null ? $" capturing {PieceCaptured.Type}" : "");
}