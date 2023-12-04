using CommunityToolkit.Mvvm.Input;
using OneWare.AI.ViewModels;
using OneWare.AI.Views;
using OneWare.SDK.Models;
using OneWare.SDK.Services;
using OneWare.SDK.ViewModels;
using Prism.Ioc;
using Prism.Modularity;

namespace OneWare.AI;

public class OneWareAiModule : IModule
{
    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        var windowService = containerProvider.Resolve<IWindowService>();
        
        //This example adds a context menu for .vhd files
        containerProvider.Resolve<IProjectExplorerService>().RegisterConstructContextMenu(x =>
        {
            if (x is [IProjectFile {Extension: ".vhd"} json])
            {
                return new[]
                {
                    new MenuItemViewModel("Hello World")
                    {
                        Header = "Hello World"
                    }
                };
            }
            return null;
        });
        
        windowService.RegisterMenuItem("MainWindow_MainMenu", new MenuItemViewModel("Ai")
        {
            Header = "AI",
            Priority = 120
        });
        
        windowService.RegisterMenuItem("MainWindow_MainMenu/Ai", new MenuItemViewModel("OpenAiCreator")
        {
            Header = "Open AI Generator",
            Command = new AsyncRelayCommand(() => windowService.ShowDialogAsync(new AiGeneratorView()
            {
                DataContext = new AiGeneratorViewModel()
            }))
        });
    }
}