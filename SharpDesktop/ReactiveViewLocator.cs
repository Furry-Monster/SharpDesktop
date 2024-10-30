using System;
using ReactiveUI;
using SharpDesktop.ViewModels;
using SharpDesktop.Views;

namespace SharpDesktop;

internal class ReactiveViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T? viewModel, string? contract = null) => viewModel switch
    {
        DesktopViewModel context => new DesktopView { DataContext = context },
        ResourceViewModel context => new ResourceView { DataContext = context },
        WorkspaceViewModel context => new WorkspaceView { DataContext = context },
        TerminalViewModel context => new TerminalView { DataContext = context },
        AiViewModel context => new AiView { DataContext = context },

        _ => throw new ArgumentOutOfRangeException(nameof(viewModel), viewModel, null)
    };
}