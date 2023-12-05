using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace OneWare.AI.Controls;

public class ImageDrawControl : Control
{
    private readonly Pen _transparentPen = new Pen();
    private readonly Pen _rectanglePen = new Pen(Brushes.Brown, 2);

    public List<Rect> Rects { get; } = new();

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
                Rects.Add(new Rect(_startPoint.Value, endPoint));
                InvalidateVisual();
            }

            _startPoint = null;
            _isPressed = false;
        }
    }

    public override void Render(DrawingContext context)
    {
        context.DrawRectangle(Brushes.Transparent, _transparentPen, Bounds);

        foreach (var rect in Rects)
        {
            context.DrawRectangle(Brushes.Transparent, _rectanglePen, rect);
        }

        if (_isPressed && _startPoint.HasValue && _currentPoint.HasValue)
        {
            context.DrawRectangle(Brushes.Transparent, _rectanglePen, new Rect(_startPoint.Value, _currentPoint.Value));
        }

        base.Render(context);
    }
}