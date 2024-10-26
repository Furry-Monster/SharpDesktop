using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SharpDesktop.ViewModels;

namespace SharpDesktop.Views;

public partial class ErrorView : ReactiveUserControl<ErrorViewModel>
{
    public ErrorView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}