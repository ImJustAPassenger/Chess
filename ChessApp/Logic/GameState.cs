using ChessApp.Models;


namespace ChessApp.Logic;
public class GameState
{
    public Board Board {get;}
    public Player CurrentPlayer {get; private set;}
    public GameState(Player player, Board board)
    {
        CurrentPlayer = player;
        Board =board;
    }

    public IEnumerable<Move> LegalMovesForPiece(Position pos)
    {
        if(Board.IsEmpty(pos)||Board[pos].Color!=CurrentPlayer)
        {
            return Enumerable.Empty<Move>();
        }
        Piece piece= Board[pos];
        
        IEnumerable<Move> moveCandites= piece.GetMoves(pos,Board);
        return moveCandites.Where(move=>move.IsLegal(Board));
  
    }

    public void MakeMove(Move move)
    {
        move.Execute(Board);
        CurrentPlayer= CurrentPlayer.Opponent();
    }
}