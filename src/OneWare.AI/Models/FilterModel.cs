using CommunityToolkit.Mvvm.ComponentModel;

namespace OneWare.AI.Models;

public partial class FilterModel(string name) : ObservableObject
{
    public string Name { get; } = name;
    
    [ObservableProperty]
    private int _pictureCount;
}