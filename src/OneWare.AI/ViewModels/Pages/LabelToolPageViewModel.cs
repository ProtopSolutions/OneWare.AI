using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OneWare.AI.ViewModels.Pages;

public partial class LabelToolPageViewModel : PageViewModelBase
{
    public string PageOneTitle => "Label Tool?";

    public string PageOneDescription => "Sorry Leon kann deine Schrift nicht lesen";

    [ObservableProperty]
    private IImage? _image;

    public LabelToolPageViewModel()
    {
        Image = new Bitmap(AssetLoader.Open(new Uri("avares://OneWare.AI/Assets/Poker.png")));
        CanContinue = true;
    }
}