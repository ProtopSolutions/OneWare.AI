using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OneWare.SDK.ViewModels;
using OneWare.Settings;
using OneWare.Settings.ViewModels;
using OneWare.Settings.ViewModels.SettingTypes;

namespace OneWare.AI.ViewModels;

public partial class AiGeneratorViewModel :  FlexibleWindowViewModelBase
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateCommand))]
    private bool _setupFinished;
    
    public SettingsCollectionViewModel SettingsCollection { get; } = new("Project Properties")
    {
        ShowTitle = false
    };

    public AiGeneratorViewModel()
    {
        var aiType = new ComboBoxSetting("AI Model Type", "", "2D", ["1D", "2D", "3D"]);
        SettingsCollection.SettingModels.Add(new ComboBoxSettingViewModel(aiType));
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