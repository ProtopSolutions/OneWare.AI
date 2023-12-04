using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OneWare.AI.ViewModels.Pages;
using OneWare.SDK.ViewModels;
using OneWare.Settings.ViewModels;

namespace OneWare.AI.ViewModels;

public partial class AiGeneratorViewModel :  FlexibleWindowViewModelBase
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateCommand))]
    private bool _setupFinished;

    [ObservableProperty]
    private PageViewModelBase _pageViewModel;

    public AiGeneratorViewModel()
    {
        _pageViewModel = new PageOneViewModel();
    }

    [RelayCommand(CanExecute = nameof(CanContinue))]
    private void Continue()
    {
        PageViewModel = new PageTwoViewModel();
    }

    private bool CanContinue()
    {
        return true;
    }
    
    [RelayCommand(CanExecute = nameof(CanCreate))]
    private void Create()
    {
        
    }

    private bool CanCreate()
    {
        return _setupFinished;
    }
}