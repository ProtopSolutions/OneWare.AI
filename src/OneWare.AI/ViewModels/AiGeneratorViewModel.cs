using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OneWare.AI.Settings;
using OneWare.SDK.Converters;
using OneWare.SDK.ViewModels;
using OneWare.Settings;
using OneWare.Settings.ViewModels;
using OneWare.Settings.ViewModels.SettingTypes;

namespace OneWare.AI.ViewModels;

public partial class AiGeneratorViewModel :  FlexibleWindowViewModelBase
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CreateCommand))]
    private bool _setupFinished;
    
    public SettingsCollectionViewModel SettingsCollection { get; } = new("Project Properties")
    {
        ShowTitle = false
    };

    public AiGeneratorViewModel()
    {
        var aiType = new ListWithIconSetting("AI Model Type", "What kind of AI Model do you want to create?", "Image Detection", 
            [
                new ListWithIconSettingOption("Image Detection", "Trains a model for image detection", new Bitmap(AssetLoader.Open(new Uri("avares://OneWare.AI/Assets/ImageDetection.jpeg")))),
                new ListWithIconSettingOption("Sensor Prediction", "Used for prediction of sensors", new Bitmap(AssetLoader.Open(new Uri("avares://OneWare.AI/Assets/SensorPrediction.jpeg")))),
                new ListWithIconSettingOption("Image Fusion", "How to create a nuclear fusion reactor (easy)",new Bitmap(AssetLoader.Open(new Uri("avares://OneWare.AI/Assets/ImageFusion.jpeg"))))
            ]);
        SettingsCollection.SettingModels.Add(new ListWithIconSettingViewModel(aiType));
    }

    [RelayCommand(CanExecute = nameof(CanContinue))]
    private void Continue()
    {
        
    }

    private bool CanContinue()
    {
        return true;
    }
    
    [RelayCommand(CanExecute = nameof(CanCreate))]
    private void Create()
    {
        
    }

    private bool CanCreate()
    {
        return _setupFinished;
    }
}