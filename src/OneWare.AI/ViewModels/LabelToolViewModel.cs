using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using OneWare.AI.Models;
using OneWare.AI.ViewModels.Pages;
using OneWare.SDK.ViewModels;

namespace OneWare.AI.ViewModels;

public partial class LabelToolViewModel(ImageModel modelModel) : FlexibleWindowViewModelBase
{
    public string PageOneTitle => "Label Tool?";

    public string PageOneDescription => "Sorry Leon kann deine Schrift nicht lesen";

    public ImageModel Model { get; } = modelModel;
}