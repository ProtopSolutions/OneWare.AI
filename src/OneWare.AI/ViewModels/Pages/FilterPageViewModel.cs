using System.Collections.ObjectModel;
using OneWare.AI.Models;

namespace OneWare.AI.ViewModels.Pages;

public class FilterPageViewModel : PageViewModelBase
{
    public string Title => "Add Filter";
    public string Description => "Blyat";
    
    public ObservableCollection<FilterModel> Filter { get; } = new();
    
    public FilterPageViewModel()
    {
        CanContinue = true;
    }
}