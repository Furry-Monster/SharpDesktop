using Avalonia.Controls;
using SharpDesktop.ViewModels;

namespace SharpDesktop.Views.Dialog;

public partial class SettingView : UserControl
{
    public SettingView()
    {
        InitializeComponent();

        DataContext = new SettingViewModel();
    }
}