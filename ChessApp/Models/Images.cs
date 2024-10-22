namespace ChessApp.Models;
public static class Images
{
    private static readonly Dictionary<PieceType,ImageSource> whiteSource = new()
    {   
        {PieceType.Knight,"knight_w.png"},
        {PieceType.Pawn,"pawn_w.png"},
        {PieceType.Bishop,"bishop_w.png"},
        {PieceType.Queen,"queen_w.png"},
        {PieceType.King,"king_w.png"},
        {PieceType.Rook,"rook_w.png"}
    };
    private static readonly Dictionary<PieceType,ImageSource> blackSource = new()
    {   
        {PieceType.Knight,"knight_b.png"},
        {PieceType.Pawn,"pawn_b.png"},
        {PieceType.Bishop,"bishop_b.png"},
        {PieceType.Queen,"queen_b.png"},
        {PieceType.King,"king_b.png"},
        {PieceType.Rook,"rook_b.png"}
    };


    public static ImageSource GetImage(Player color, PieceType type)
    {
        return color switch
        {
            Player.White=> whiteSource[type],
            Player.Black=>blackSource[type],
            _ => null
        };
    }
    public static ImageSource GetImage(Piece piece)
    {
        if(piece==null) return null;
        return GetImage(piece.Color,piece.Type);
    }

}