using ChessApp.Logic;

namespace ChessApp.Models;
public class Queen : Piece
{
    public override PieceType Type => PieceType.Queen;
    public override Player Color {get;}
    private readonly Direction[] dirs= new Direction[]
    {
        Direction.NorthWest,
        Direction.NorthEast,
        Direction.SouthWest,
        Direction.SouthEast,
        Direction.North,
        Direction.South,
        Direction.East,
        Direction.West
    };

public Queen(Player color)
{
Color=color;
}

    public override Piece Copy()
    {
        Queen copy=new Queen(Color);
        copy.HasMoved =HasMoved;
         return copy;
    }
    
    public override IEnumerable<Move> GetMoves(Position from, Board board)
    {
        return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
    }
}