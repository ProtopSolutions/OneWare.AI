using Avalonia;

namespace OneWare.AI.Models;

public class ImageLabelModel(string name, Rect area)
{
    public string Name { get; } = name;

    public Rect Area { get; } = area;
}