using System;
using ReactiveUI;

namespace SharpDesktop.ViewModels;

public class DesktopViewModel : ViewModelBase,IRoutableViewModel
{
    public DesktopViewModel(IScreen hostScreen) => HostScreen = hostScreen;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    
    public IScreen HostScreen { get; }
}