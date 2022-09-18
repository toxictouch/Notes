namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
    /// <summary>
    /// Instrumental:
    /// https://learn.microsoft.com/en-us/dotnet/maui/tutorials/notes-app/?tutorial-step=4
    /// </summary>
    public AllNotesPage()
	{
		InitializeComponent();
		BindingContext = new Models.AllNotes();
	}

    /// <summary>
    /// The OnAppearing method is overridden from the base class.
    /// This method is automatically called whenever the page is shown, such as when the page is navigated to.
    /// The code here tells the model to load the notes.
    /// Because the CollectionView in the AllNotes view is bound to the AllNotes model's Notes property,
    /// which is an ObservableCollection, whenever the notes are loaded,
    /// the CollectionView is automatically updated.
    /// </summary>
    protected override void OnAppearing()
	{
		((Models.AllNotes)BindingContext).LoadNotes();
	}

    /// <summary>
    /// The Add_Clicked handler introduces another new concept, navigation.
    /// Because the app is using .NET MAUI Shell,
    /// you can navigate to pages by calling the Shell.Current.GoToAsync method.
    /// Notice that the handler is declared with the async keyword,
    /// which allows the use of the await keyword when navigating.
    /// This handler navigates to the NotePage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Add_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(NotePage));
	}

	private async void NotesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count != 0)
		{
			// Get the note model
			Models.Note note = (Models.Note)e.CurrentSelection[0];

			// Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
			await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.Filename}");

			// Unselect the UI
			notesCollection.SelectedItem = null;
		}
	}
}