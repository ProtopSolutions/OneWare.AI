using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using OneWare.AI.ViewModels;
using OneWare.AI.Views;
using OneWare.SDK.Services;
using Prism.Ioc;

namespace OneWare.AI.Models;

public class ImageModel(IImage image)
{
    public IImage Image { get; } = image;

    public ObservableCollection<ImageLabelModel> Labels { get; } = new();
    
    public async Task CreateLabelAsync(Control owner)
    {
        var window = TopLevel.GetTopLevel(owner) as Window;
        
        await ContainerLocator.Container.Resolve<IWindowService>().ShowDialogAsync(new LabelToolView()
        {
            DataContext = ContainerLocator.Container.Resolve<LabelToolViewModel>((typeof(ImageModel), this))
        }, window);
    }
}