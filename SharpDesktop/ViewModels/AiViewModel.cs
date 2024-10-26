using System;
using ReactiveUI;

namespace SharpDesktop.ViewModels;

public class AiViewModel : ViewModelBase, IRoutableViewModel
{
    public AiViewModel(IScreen screen) => HostScreen = screen;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }
}