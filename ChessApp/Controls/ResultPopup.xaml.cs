using ChessApp.Models;
using CommunityToolkit.Maui.Views;

namespace ChessApp.Controls;

public partial class ResultPopup : Popup
{

	public ResultPopup(Result result)
	{
		InitializeComponent();
		var reason="";
		switch (result.Reason)
		{
			case EndReason.Checkmate:
			{
				reason="CHECKMATE";
				break;
			}
			case EndReason.FiftyMoveRule:
			{
				reason="FIFTY-MOVE RULE";
				break;
			}
			case EndReason.InsufficientMaterial:
			{
				reason="INSUFFICIENT MATERIAL";
				break;
			}
			case EndReason.Stalemate:
			{
				reason="STALEMATE";
				break;
			}
			case EndReason.ThreefoldRepetition:
			{
				reason="THREEFOLD REPETITION";
				break;
			}
			default:
			{
				break;
			}
		}
		headerResult.Text = $"{result.Winner}";
		lblRightWrong.Text = $"{reason}";


	}

	private async void Continue_Clicked(object sender, EventArgs e)
	{
		await this.CloseAsync();
	}

	private async void CloseApp_Clicked(object sender, EventArgs e)
	{
		Application.Current?.CloseWindow(Application.Current.MainPage.Window);
	}

}