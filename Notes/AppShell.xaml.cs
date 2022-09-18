namespace Notes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Every page that can be navigated to from another page, needs to be registered with the navigation system. 
		// The other two are registered in the tab bar
		// Register the NotesPage with the navigation system like this:
		Routing.RegisterRoute(nameof(Views.NotePage), typeof(Views.NotePage));
    }
}
