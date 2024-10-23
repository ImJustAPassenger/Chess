using ChessApp.Models;
using CommunityToolkit.Maui.Views;

namespace ChessApp.Controls;

public partial class ResultPopup : Popup
{

	public ResultPopup(Result result)
	{
		InitializeComponent();

		headerResult.Text = $"{result.Winner}";
		lblRightWrong.Text = $"{result.Reason}";


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