using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OneWare.AI.ViewModels.Pages;
using OneWare.SDK.ViewModels;

namespace OneWare.AI.ViewModels;

public partial class AiGeneratorViewModel :  FlexibleWindowViewModelBase
{
    private readonly Stack<PageViewModelBase> _pageStack = new();
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(BackCommand))]
    private PageViewModelBase _selectedPage;

    public AiGeneratorViewModel()
    {
        _selectedPage = new PageOneViewModel();
        _pageStack.Push(_selectedPage);
    }
    
    [RelayCommand]
    private void Next()
    {
        PageViewModelBase nextScreen = SelectedPage switch
        {
            PageOneViewModel => new PageTwoViewModel(),
            PageTwoViewModel => new LabelToolPageViewModel(),
            LabelToolPageViewModel => new ModelComplexityPageViewModel(),
            _ => new PageOneViewModel()
        };
        
        _pageStack.Push(nextScreen);
        SelectedPage = _pageStack.Peek();
    }

    [RelayCommand(CanExecute = nameof(CanBack))]
    private void Back()
    {
        if(_pageStack.Count != 0) _pageStack.Pop();
        SelectedPage = _pageStack.Peek();
    }

    private bool CanBack()
    {
        return _pageStack.Count > 1;
    }

    [RelayCommand(CanExecute = nameof(CanCreate))]
    private void Create()
    {
        
    }
    
    private bool CanCreate()
    {
        return false;
    }
}