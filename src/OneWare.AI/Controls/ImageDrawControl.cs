using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using OneWare.AI.Models;
using OneWare.SDK.Enums;
using OneWare.SDK.Services;
using Prism.Ioc;

namespace OneWare.AI.Controls;

public class ImageDrawControl : Control
{
    private readonly Pen _transparentPen = new Pen();
    private readonly Pen _rectanglePen = new Pen(Brushes.Brown, 2);
    
    public static readonly StyledProperty<ImageModel> ImageModelProperty =
        AvaloniaProperty.Register<ImageDrawControl, ImageModel>(nameof(StyledElement));

    public ImageModel ImageModel
    {
        get => GetValue(ImageModelProperty);
        set => SetValue(ImageModelProperty, value);
    }

    private bool _isPressed;
    private Point? _startPoint;
    private Point? _currentPoint;

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);

        _currentPoint = e.GetPosition(this);

        if (_isPressed)
        {
            InvalidateVisual();
        }
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        _startPoint = e.GetPosition(this);
        _isPressed = true;
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);

        if (_isPressed)
        {
            if (_startPoint.HasValue)
            {
                var endPoint = e.GetPosition(this);
                var newRect = new Rect(_startPoint.Value, endPoint);
                _ = CreateLabelAsync(newRect);
            }

            _startPoint = null;
            _isPressed = false;
        }
    }

    private async Task CreateLabelAsync(Rect rect)
    {
        var name = await ContainerLocator.Container.Resolve<IWindowService>().ShowInputAsync("Enter name",
            "Enter a name for the label", MessageBoxIcon.Info, null, TopLevel.GetTopLevel(this) as Window);

        if (name == null) return;
        
        ImageModel.Labels.Add(new ImageLabelModel(name, rect));
        InvalidateVisual();
    }

    public override void Render(DrawingContext context)
    {
        context.DrawRectangle(Brushes.Transparent, _transparentPen, Bounds);

        foreach (var label in ImageModel.Labels)
        {
            context.DrawRectangle(Brushes.Transparent, _rectanglePen, label.Area);
        }

        if (_isPressed && _startPoint.HasValue && _currentPoint.HasValue)
        {
            context.DrawRectangle(Brushes.Transparent, _rectanglePen, new Rect(_startPoint.Value, _currentPoint.Value));
        }

        base.Render(context);
    }
}