using ReactiveUI;
using System;

namespace SharpDesktop.ViewModels;

public class TerminalViewModel : ViewModelBase, IRoutableViewModel
{
    public TerminalViewModel(IScreen screen) => HostScreen = screen;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }
}