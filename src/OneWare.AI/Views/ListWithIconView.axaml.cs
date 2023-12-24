using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace OneWare.AI.Views;

public partial class ListWithIconView : UserControl
{
    public ListWithIconView()
    {
        InitializeComponent();
    }

    protected override void OnGotFocus(GotFocusEventArgs e)
    {
        base.OnGotFocus(e);
        Dispatcher.UIThread.Post(() => ListBox.Focus());
    }
}