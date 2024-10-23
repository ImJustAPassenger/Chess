/* 
to fix in futur if i want to do it
namespace ChessApp.Models;


public class ChessCursor
{
     public static readonly Cursor WhiteCursor = LoadCursor("cursor_w.cur");
    public static readonly Cursor BlackCursor = LoadCursor("cursor_b.cur");
    private static Cursor LoadCursor(string filePath)
    {
        Stream stream = Application.GetResourceStream(new uri(filePath, UriKind.Relative)).Stream;
        return new Cursor(stream, true);
    } 
} */