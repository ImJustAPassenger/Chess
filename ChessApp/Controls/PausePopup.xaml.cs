using CommunityToolkit.Maui.Views;

namespace ChessApp.Controls;

public partial class PausePopup : Popup
{
	public PausePopup()
	{
		InitializeComponent();
		Restart = false;
	}
	public bool Restart = false;
	private async Task Close()
	{
		await this.CloseAsync();
	}

	private async void Continue_Clicked(object sender, EventArgs e)
	{
		await Close();
	}

	private async void Restart_Clicked(object sender, EventArgs e)
	{
		Restart = true;
		await Close();
	}
}