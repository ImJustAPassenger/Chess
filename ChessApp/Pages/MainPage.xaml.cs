using ChessApp.Logic;
using ChessApp.Models;

namespace ChessApp.Pages;

public partial class MainPage : ContentPage
{

	private GameState gameState;
	private readonly Image[,] pieceImages = new Image[8, 8];
	public MainPage()
	{
		InitializeComponent();
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

}

