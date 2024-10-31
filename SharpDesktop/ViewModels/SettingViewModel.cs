using System;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace SharpDesktop.ViewModels;

public class SettingViewModel : ViewModelBase
{
    public SettingViewModel()
    {
        CloseCommand = ReactiveCommand.Create(() =>
        {
            // Close the setting window
            MainWindowViewModel.Instance.IsSettingOpen = false;

        });
    }

    // 命令
    public ICommand CloseCommand { get; private set; }

}