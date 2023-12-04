using OneWare.AI.Settings;
using OneWare.Settings;
using OneWare.Settings.ViewModels.SettingTypes;

namespace OneWare.AI.ViewModels;

public class ListWithIconSettingViewModel : SettingViewModel
{
    public new ListWithIconSetting Setting { get; }
    
    public ListWithIconSettingViewModel(ListWithIconSetting setting) : base(setting)
    {
        Setting = setting;
    }
}