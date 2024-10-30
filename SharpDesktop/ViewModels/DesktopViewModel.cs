using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using SharpDesktop.Models;

namespace SharpDesktop.ViewModels;

public class DesktopViewModel : ViewModelBase, IRoutableViewModel
{
    public DesktopViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;

        //---------------
        // 工具栏命令
        //---------------
        #region 工具栏命令实现
        AddDesktopCommand = ReactiveCommand.Create(() =>
        {
            // TODO: 实现添加桌面功能
            Desktops?.Add(new Desktop("新建桌面"));
        });

        #endregion
    }

    // 路由接口实现
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }

    // 工具栏命令
    public ICommand AddDesktopCommand { get; }



    private ObservableCollection<Desktop>? _desktops = [];

    public ObservableCollection<Desktop>? Desktops
    {
        get => _desktops;
        set => this.RaiseAndSetIfChanged(ref _desktops, value);
    }
}