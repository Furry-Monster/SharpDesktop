using System;
using ReactiveUI;

namespace SharpDesktop.ViewModels;

public class AiViewModel : ViewModelBase, IRoutableViewModel
{
    public AiViewModel(IScreen hostScreen) : base(hostScreen) => HostScreen = hostScreen;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }
}