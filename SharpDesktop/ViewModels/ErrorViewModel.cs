using System;
using ReactiveUI;

namespace SharpDesktop.ViewModels;

public class ErrorViewModel : ViewModelBase, IRoutableViewModel
{
    public ErrorViewModel(IScreen screen) => HostScreen = screen;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];

    public IScreen HostScreen { get; }


}