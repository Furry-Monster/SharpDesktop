using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SharpDesktop.ViewModels;

namespace SharpDesktop.Views;

public partial class WorkspaceView : ReactiveUserControl<WorkspaceViewModel>
{
    public WorkspaceView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}