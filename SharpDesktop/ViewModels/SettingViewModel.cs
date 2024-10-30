using System;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;
using SharpDesktop.Service;

namespace SharpDesktop.ViewModels;

public class SettingViewModel : ViewModelBase
{
    public SettingViewModel()
    {
        CloseCommand = ReactiveCommand.Create(() =>
        {
            // Async save the setting here
            SettingService.Instance?.Save();
            // Close the setting window
            MainWindowViewModel.Instance.IsSettingOpen = false;

        }, Observable.Return(true));
    }

    public ICommand CloseCommand { get; private set; }
}