using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OneWare.AI.ViewModels.Pages;

public partial class ModelComplexityPageViewModel : PageViewModelBase
{
    public string PageOneTitle => "Tune Model Complexity";

    public string PageOneDescription => "Optimize your model for your needs";

    [ObservableProperty]
    private double _resourcePercentage;

    [ObservableProperty]
    private double _efficiencyValue = 0.5;

    [ObservableProperty]
    private double _accuracyValue = 0.5;

    public double[] Ticks => [0.2, 0.4, 0.6, 0.8];

    public ModelComplexityPageViewModel()
    {
       Calculate();
    }

    private void Calculate()
    {
        ResourcePercentage = AccuracyValue * (1-EfficiencyValue) * 100;
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.PropertyName is nameof(EfficiencyValue))
        {
            AccuracyValue = 1 - EfficiencyValue;
        }
        else if (e.PropertyName is nameof(AccuracyValue))
        {
            EfficiencyValue = 1 - AccuracyValue;
        }
        Calculate();
    }
}