using Avalonia;
using Avalonia.Controls;
using OneWare.AI.Models;

namespace OneWare.AI.ViewModels.Pages;

public class PageTwoViewModel : PageViewModelBase
{
    public string PageOneTitle => "Select Image Detection Task";

    public string PageOneDescription => "Choose the prediction task for your images";
    
    public ListWithIconViewModel Selection { get; }
    
    public PageTwoViewModel()
    {
        Selection = new ListWithIconViewModel([
            new ListWithIconOptionModel("Segment Image", "Detect pixels that belong to an object")
            {
                ImageIconObservable = Application.Current!.GetResourceObservable("2D_S")
            },
            new ListWithIconOptionModel("Detect Object", "Detect position and size that belong to an object")
            {
                ImageIconObservable = Application.Current!.GetResourceObservable("2D_D")
            },
            new ListWithIconOptionModel("Classify Image", "Classify Image with different categories")
            {
                ImageIconObservable = Application.Current!.GetResourceObservable("2D_C")
            },
        ]);
    }
}