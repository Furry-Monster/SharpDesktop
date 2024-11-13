using System;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SharpDesktop.Util;
using SharpDesktop.ViewModels;

namespace SharpDesktop.Views;

public partial class DesktopView : ReactiveUserControl<DesktopViewModel>
{
    public DesktopView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}