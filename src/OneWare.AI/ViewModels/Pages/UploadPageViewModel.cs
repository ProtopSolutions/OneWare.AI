using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using OneWare.SDK.Helpers;

namespace OneWare.AI.ViewModels.Pages;

public class UploadPageViewModel : PageViewModelBase
{
    public string PageTitle => "Add Training Data";

    public string PageDescription => "Select Images to train your model";

    private static readonly string[] Filters = { "*.jpg", ".jpeg", "*.png" };
    
    public ObservableCollection<Bitmap> Files { get; } = new();

    public async Task SelectFilesAsync(Control owner)
    {
        var topLevel = TopLevel.GetTopLevel(owner);
        if (topLevel == null) return;
        
        var files = await StorageProviderHelper.SelectFilesAsync(topLevel, "Select Files", null, new FilePickerFileType($"Image (*.jpg, *.jpeg, *.png)")
        {
            Patterns = Filters
        });

        Files.AddRange(files.Where(File.Exists).Select(x => new Bitmap(x)));

        if(Files.Count > 0)
            CanContinue = true;
    }
}