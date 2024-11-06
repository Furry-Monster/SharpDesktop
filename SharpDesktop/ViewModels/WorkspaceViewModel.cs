using ReactiveUI;
using System;

namespace SharpDesktop.ViewModels;

public class WorkspaceViewModel : ViewModelBase, IRoutableViewModel
{
    public WorkspaceViewModel(IScreen hostScreen) : base(hostScreen)
    {
        HostScreen = hostScreen;
    }

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }
}