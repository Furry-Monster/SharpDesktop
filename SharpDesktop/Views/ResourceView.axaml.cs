using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SharpDesktop.ViewModels;

namespace SharpDesktop.Views;

public partial class ResourceView : ReactiveUserControl<ResourceViewModel>
{
    public ResourceView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}