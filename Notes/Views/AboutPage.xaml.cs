namespace Notes.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// Notice that the async keyword was added to the method declaration, 
    /// which allows the use of the await keyword when opening the system browser.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void LearnMore_Clicked(object sender, EventArgs e)
	{
        if (BindingContext is Models.About about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }        
    }
}