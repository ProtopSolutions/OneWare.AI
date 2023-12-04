using Avalonia.Media;

namespace OneWare.AI.Settings;

public class ListWithIconSettingOption(string title, string description, IImage icon)
{
    public string Title { get; } = title;
    
    public string Description { get; } = description;
    public IImage Icon { get; } = icon;
}