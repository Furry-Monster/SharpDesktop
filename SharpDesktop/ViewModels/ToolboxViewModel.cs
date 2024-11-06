using System;
using ReactiveUI;

namespace SharpDesktop.ViewModels;

public class ToolboxViewModel : ViewModelBase, IRoutableViewModel
{
    public ToolboxViewModel(IScreen hostScreen) : base(hostScreen) => HostScreen = hostScreen;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }
}