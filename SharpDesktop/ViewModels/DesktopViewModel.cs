﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using ReactiveUI;
using SharpDesktop.Models;
using SharpDesktop.Models.Entity;

namespace SharpDesktop.ViewModels;

public class DesktopViewModel : ViewModelBase, IRoutableViewModel
{
    public DesktopViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;

        Refresh();// 刷新桌面列表

        //---------------
        // 工具栏命令
        //---------------
        #region 工具栏命令实现
        AddDesktopCommand = ReactiveCommand.Create(() =>
        {
            using var db = DatabaseContextFactory.CreateContext();
            db.Desktops.Add(new Desktop("新建桌面"));
            db.SaveChanges();

            Refresh();
        });

        OpenDesktopCommand = ReactiveCommand.Create(() =>
        {
            //TODO: 实现打开桌面功能
        });

        #endregion
    }

    // 路由接口实现
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }

    // 工具栏命令
    public ICommand AddDesktopCommand { get; }
    public ICommand OpenDesktopCommand { get; }


    // 字段
    private ObservableCollection<Desktop>? _desktops = [];

    public ObservableCollection<Desktop>? Desktops
    {
        get => _desktops;
        set => this.RaiseAndSetIfChanged(ref _desktops, value);
    }

    // 方法
    private void Refresh()
    {
        using var db = DatabaseContextFactory.CreateContext();
        var desktops = db.Desktops.ToList();
        Desktops?.Clear();
        Desktops = new ObservableCollection<Desktop>(desktops);
    }
}