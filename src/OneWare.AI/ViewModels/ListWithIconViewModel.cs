using CommunityToolkit.Mvvm.ComponentModel;
using OneWare.AI.Models;

namespace OneWare.AI.ViewModels;

public partial class ListWithIconViewModel(IEnumerable<ListWithIconOptionModel> options) : ObservableObject
{
    [ObservableProperty]
    private ListWithIconOptionModel? _selectedOption;
    
    public IEnumerable<ListWithIconOptionModel> Options { get; } = options;
}