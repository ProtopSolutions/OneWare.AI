using Avalonia;
using Avalonia.Controls;
using DynamicData.Binding;
using OneWare.AI.Models;

namespace OneWare.AI.ViewModels.Pages;

public class PageOneViewModel : PageViewModelBase
{
    public string PageOneTitle => "Select AI Task";

    public string PageOneDescription => "What general task dependant on the input data do you want to create?";
    
    public ListWithIconViewModel Selection { get; } = new([
        new ListWithIconOptionModel("Sensor Evaluation", "Prediction with multiple sensor values")
        {
            ImageIconObservable = Application.Current!.GetResourceObservable("1D")
        },
        new ListWithIconOptionModel("Sensor Prediction", "Prediction with a sequence of sensor values")
        {
            ImageIconObservable = Application.Current!.GetResourceObservable("ID_T")
        },
        new ListWithIconOptionModel("Image Detection", "Classification or Object detection with images")
        {
            ImageIconObservable = Application.Current!.GetResourceObservable("2D")
        },
        new ListWithIconOptionModel("Image Fusion", "Classification or Object detection with multiple images")
        {
            ImageIconObservable = Application.Current!.GetResourceObservable("2D_T")
        }
    ]);

    public PageOneViewModel()
    {
        Selection.WhenValueChanged(x => x.SelectedOption).Subscribe(x =>
        {
            CanContinue = x != null;
        });
    }
}