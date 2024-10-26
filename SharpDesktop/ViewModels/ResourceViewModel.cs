using ReactiveUI;
using System;

namespace SharpDesktop.ViewModels;

public class ResourceViewModel : ViewModelBase, IRoutableViewModel
{
    public ResourceViewModel(IScreen hostScreen) => HostScreen = hostScreen;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }
}