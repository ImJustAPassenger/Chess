
using ChessApp.Logic;
using ChessApp.Models;
using Microsoft.Maui.Controls.Shapes;

namespace ChessApp.Pages;

public partial class MainPage : ContentPage
{

	private GameState gameState;
	private Position selectedPos = null;
	private readonly Image[,] pieceImages = new Image[8, 8];
	private readonly Rectangle[,] highlights = new Rectangle[8, 8];
	private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();

	public MainPage()
	{
		InitializeComponent();
		BoardGrid.SizeChanged += OnBoardGridSizeChanged;
	}
	private double squareWidth;
	private double squareHeight;

	private void OnBoardGridSizeChanged(object sender, EventArgs e)
	{
		// Calcola la dimensione di ciascun quadrato
		squareWidth = BoardGrid.Width / 8;
		squareHeight = BoardGrid.Height / 8;
	}
	protected override void OnAppearing()
	{
		InitializeBoard();
		gameState = new GameState(Player.White, Board.Initial());
		DrawBoard(gameState.Board);

	}
	private void InitializeBoard()
	{
		for (int r = 0; r < 8; r++)
		{
			for (int c = 0; c < 8; c++)
			{
				Image image = new Image();
				pieceImages[r, c] = image;
				Grid.SetRow(image, r);
				Grid.SetColumn(image, c);
				PieceGrid.Children.Add(image);

				Rectangle highLight = new Rectangle();
				highlights[r, c] = highLight;

				Grid.SetRow(highLight, r);  // Imposta la riga
				Grid.SetColumn(highLight, c);  // Imposta la colonna
				HighLightGrid.Children.Add(highLight);
			}
		}
	}
	private void DrawBoard(Board board)
	{
		for (int r = 0; r < 8; r++)
		{
			for (int c = 0; c < 8; c++)
			{
				Piece piece = board[r, c];
				pieceImages[r, c].Source = Images.GetImage(piece);
			}
		}
	}
	private void CacheMoves(IEnumerable<Move> moves)
	{
		moveCache.Clear();
		foreach (Move move in moves)
		{
			moveCache[move.ToPos] = move;
		}
	}

	private void ShowHighLights()
	{
		Color color = Color.FromRgba(125, 125, 255, 150);
		foreach (Position to in moveCache.Keys)
		{
			Console.WriteLine($"Highlighting position: Row={to.Row}, Column={to.Column}");
			highlights[to.Row, to.Column].Fill = new SolidColorBrush(color);
		}
	}
	private void HideHighLights()
	{
		foreach (Position to in moveCache.Keys)
		{
			highlights[to.Row, to.Column].Fill = Brush.Transparent;
		}
	}

	private void BoardGrid_Tapped(object sender, TappedEventArgs e)
	{
		var touchPoint = e.GetPosition(BoardGrid);
		if (touchPoint.HasValue)
		{
			Console.WriteLine($"Touch Point: X={touchPoint.Value.X}, Y={touchPoint.Value.Y}");

			Position pos = ToSquarePosition(touchPoint.Value);
			if (selectedPos == null)
			{
				OnFromPositionSelected(pos);
			}
			else
			{
				OnToPositionSelected(pos);
			}
		}
	}

	private void OnToPositionSelected(Position pos)
	{
		selectedPos = null;
		HideHighLights();
		if (moveCache.TryGetValue(pos, out Move move))
		{
			HandleMove(move);
		}
	}

	private void HandleMove(Move move)
	{
		gameState.MakeMove(move);
		DrawBoard(gameState.Board);
	}

	private void OnFromPositionSelected(Position pos)
	{
		IEnumerable<Move> moves = gameState.LegalMovesForPiece(pos);
		if (moves.Any())
		{
			selectedPos = pos;
			CacheMoves(moves);
			ShowHighLights();
		}
	}

	private Position ToSquarePosition(Point point)
	{
		int row = (int)(point.Y / squareHeight);
		int col = (int)(point.X / squareWidth);

		// Assicurati che le coordinate siano valide
		row = Math.Clamp(row, 0, 7);
		col = Math.Clamp(col, 0, 7);
		return new Position(row, col);
	}
}

