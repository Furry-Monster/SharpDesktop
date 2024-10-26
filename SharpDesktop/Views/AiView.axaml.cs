using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SharpDesktop.ViewModels;

namespace SharpDesktop.Views;

public partial class AiView : ReactiveUserControl<AiViewModel>
{
    public AiView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}