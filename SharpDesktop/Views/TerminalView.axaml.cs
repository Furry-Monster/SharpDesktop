using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SharpDesktop.Util;
using SharpDesktop.ViewModels;

namespace SharpDesktop.Views;

public partial class TerminalView : ReactiveUserControl<TerminalViewModel>
{
    public TerminalView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }

}