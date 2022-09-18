namespace Notes.Views;


/// <summary>
/// Built thanks to this tutorial:
/// https://learn.microsoft.com/en-us/dotnet/maui/tutorials/notes-app/?tutorial-step=3
/// </summary>
/// 
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    //This property calls the LoadNote method, passing the value of the property, which in turn, should be the file name of the note
    public string ItemId
    {
        set { LoadNote(value); }
    }

    public NotePage()
	{
        InitializeComponent();

        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        // The file name for the note should be a randomly generated name
        // to be created in the app's local data directory.
        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    /// <summary>
    /// Accepts a file name parameter. Either loads the existing file or creates a new one
    /// </summary>
    /// <param name="fileName"></param>
    private void LoadNote(string fileName)
    {
        // Create a new note model and set the file name.
        Models.Note noteModel = new();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            // If the file exists, load its content into the model.
            noteModel.Date = File.GetCreationTime(fileName);
            // If the file exists, update the model with the date the file was created.
            noteModel.Text = File.ReadAllText(fileName);
        }

        // Set the BindingContext of the page to the model.
        BindingContext = noteModel;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        // The buttons are now async. After they're pressed, the page navigates back to the previous page by using a URI of ..
        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        // The buttons are now async. After they're pressed, the page navigates back to the previous page by using a URI of ..
        await Shell.Current.GoToAsync("..");
    }
}