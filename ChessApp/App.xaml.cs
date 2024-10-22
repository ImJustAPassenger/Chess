namespace ChessApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
		  protected override Window CreateWindow(IActivationState? activationState)
    {
        var window= base.CreateWindow(activationState);
		window.MinimumWidth=window.MinimumHeight=800;
		//window.MaximumHeight=780;
		
		return window;
    }
}
