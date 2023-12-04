using Avalonia.Media;
using OneWare.Settings;

namespace OneWare.AI.Settings;

public class ListWithIconSetting : TitledSetting
{
    public IEnumerable<ListWithIconSettingOption> Options { get; }
    
    public ListWithIconSetting(string title, string description, object defaultValue, IEnumerable<ListWithIconSettingOption> options) : base(title, description, defaultValue)
    {
        Options = options;
    }
}