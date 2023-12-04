using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OneWare.AI.Models;

public partial class ListWithIconOptionModel(string title, string description) : ObservableObject
{
    public string Title { get; } = title;
    public string Description { get; } = description;

    [ObservableProperty] 
    private IImage? _icon;

    public IObservable<object?>? ImageIconObservable
    {
        init
        {
            value?.Subscribe(x => Icon = x as IImage);
        }
    }
}