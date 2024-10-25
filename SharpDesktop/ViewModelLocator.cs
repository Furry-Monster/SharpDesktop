using SharpDesktop.ViewModels;

namespace SharpDesktop;

internal class ViewModelLocator
{
    private MainWindowViewModel? _mainWindowViewModel;

    public MainWindowViewModel? MainWindowViewModel
    {
        get => _mainWindowViewModel ??= new MainWindowViewModel();
        set => _mainWindowViewModel = value;
    }

    
}