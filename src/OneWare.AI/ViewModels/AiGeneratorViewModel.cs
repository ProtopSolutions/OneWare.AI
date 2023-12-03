using OneWare.SDK.ViewModels;
using OneWare.Settings;
using OneWare.Settings.ViewModels;
using OneWare.Settings.ViewModels.SettingTypes;

namespace OneWare.AI.ViewModels;

public class AiGeneratorViewModel :  FlexibleWindowViewModelBase
{
    public SettingsCollectionViewModel SettingsCollection { get; } = new("Project Properties")
    {
        ShowTitle = false
    };

    public AiGeneratorViewModel()
    {
        var aiType = new ComboBoxSetting("AI Model Type", "", "2D", ["1D", "2D", "3D"]);
        SettingsCollection.SettingModels.Add(new ComboBoxSettingViewModel(aiType));
    }

    public void Create()
    {
        
    }
}