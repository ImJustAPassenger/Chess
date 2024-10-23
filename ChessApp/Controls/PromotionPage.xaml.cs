using CommunityToolkit.Maui.Views;
using ChessApp.Models;
namespace ChessApp.Controls;

public partial class PromotionPage : Popup
{
	public PieceType piece;

	public PromotionPage(Player player)
	{
		InitializeComponent();
		QueenImg.Source = Images.GetImage(player, PieceType.Queen);
		RookImg.Source = Images.GetImage(player, PieceType.Rook);
		BishopImg.Source = Images.GetImage(player, PieceType.Bishop);
		KnightImg.Source = Images.GetImage(player, PieceType.Knight);
	}

	private async void Queen_Tapped(object sender, TappedEventArgs e)
	{

		piece= PieceType.Queen;
		await Close();
	}
	private async void Bishop_Tapped(object sender, TappedEventArgs e)
	{

		piece= PieceType.Bishop;
		await Close();
	}
	private async void Rook_Tapped(object sender, TappedEventArgs e)
	{
		piece= PieceType.Rook;
		await Close();
	}
	private async void Knight_Tapped(object sender, TappedEventArgs e)
	{
		piece= PieceType.Rook;
		await Close();
	}

	private async Task Close()
	{
		await this.CloseAsync();
	}
}