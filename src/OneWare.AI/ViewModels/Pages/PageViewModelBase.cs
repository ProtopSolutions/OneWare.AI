using CommunityToolkit.Mvvm.ComponentModel;

namespace OneWare.AI.ViewModels.Pages;

public abstract partial class PageViewModelBase : ObservableObject
{
    [ObservableProperty]
    private bool _canContinue;
}