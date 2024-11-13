using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using DialogHostAvalonia;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using SharpDesktop.Models;
using SharpDesktop.Models.Entity;
using SharpDesktop.Util;
using SharpDesktop.Views.Dialog;

namespace SharpDesktop.ViewModels;

public class DesktopViewModel : ViewModelBase, IRoutableViewModel
{

    public DesktopViewModel(IScreen hostScreen) : base(hostScreen)
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

        EditDesktopCommand = ReactiveCommand.Create<Desktop>(async desktop =>
        {
            await using var db = DatabaseContextFactory.CreateContext();

            var dialog = new EditDesktopDialog()
            {
                DataContext = desktop
            };

            var result = await DialogHost.Show(dialog);

            if (Convert.ToBoolean(result))
            {
                // 数据验证
                //if (!File.Exists(dialog.IconName.Text) || PathHelper.GetSuffix(dialog.IconName.Text).ToLower() != "ico")
                //{
                //    var messageDialog = new MessageDialog("文件不存在或不支持");
                //    await DialogHost.Show(messageDialog);
                //    return;
                //}

                // 数据克隆
                desktop.Name = dialog.DesktopName.Text!;
                desktop.IconName = dialog.IconName.Text;

                // 数据保存
                db.Desktops.Update(desktop);
                db.SaveChanges();

                Refresh();
            }
        });

        DeleteDesktopCommand = ReactiveCommand.Create<Desktop>(async desktop =>
        {
            await using var db = DatabaseContextFactory.CreateContext();

            var dialog = new DeleteDialog();

            var result = await DialogHost.Show(dialog);

            if (Convert.ToBoolean(result))
            {
                db.Desktops.Remove(desktop);
                db.SaveChanges();
            }

            Refresh();
        });

        SelectDesktopCommand = ReactiveCommand.Create<Desktop>(desktop =>
        {
            CurrentDesktop = desktop;

            Refresh();
        });

        #endregion

        //---------------
        // 启动器命令
        //---------------
        #region 启动器命令

        OpenLauncherCommand = ReactiveCommand.Create<Launcher>(launcher =>
        {
            // 格式化路径
            var path = PathHelper.FormatPath(launcher.Path ?? string.Empty);

            // 初始化启动信息
            var info = new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true,
            };

            // 启动应用
            try
            {
                Process.Start(info);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"启动应用失败：{ex.Message}");
            }
        });

        EditLauncherCommand = ReactiveCommand.Create<Launcher>(async launcher =>
        {
            await using var db = DatabaseContextFactory.CreateContext();

            var dialog = new EditLauncherDialog()
            {
                DataContext = launcher
            };

            var result = await DialogHost.Show(dialog);

            if (Convert.ToBoolean(result))
            {
                // 数据验证

                // 数据克隆
                launcher.Name = dialog.LauncherName.Text!;
                launcher.Path = dialog.Path.Text;
                launcher.BackgroundPath = dialog.BackgroundPath.Text;

                // 数据保存
                db.Launchers.Update(launcher);
                db.SaveChanges();

                Refresh();
            }

        });

        AddLauncherCommand = ReactiveCommand.Create(() =>
        {
            if (CurrentDesktop == null) return;

            using var db = DatabaseContextFactory.CreateContext();
            CurrentDesktop.Launchers.Add(new Launcher("新建启动器"));
            db.Desktops.Update(CurrentDesktop);
            db.SaveChanges();

            Refresh();
        });

        DeleteLauncherCommand = ReactiveCommand.Create<Launcher>(launcher =>
        {
            if (CurrentDesktop == null) return;

            using var db = DatabaseContextFactory.CreateContext();
            CurrentDesktop.Launchers.Remove(launcher);
            db.Launchers.Remove(launcher);
            db.SaveChanges();

            Refresh();
        });

        #endregion

        //---------------
        // 编辑器命令
        //---------------
        #region 编辑器命令

        SelectFilePathCommand = ReactiveCommand.Create<object>(obj =>
        {
            //TODO 打开文件选择器
        });

        #endregion
    }

    // 路由接口实现
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }

    // 工具栏命令
    public ReactiveCommand<Unit, Unit> AddDesktopCommand { get; }
    public ReactiveCommand<Desktop, Unit> EditDesktopCommand { get; }
    public ReactiveCommand<Desktop, Unit> DeleteDesktopCommand { get; }
    public ReactiveCommand<Desktop, Unit> SelectDesktopCommand { get; }

    // 启动器命令
    public ReactiveCommand<Launcher, Unit> OpenLauncherCommand { get; }
    public ReactiveCommand<Launcher, Unit> EditLauncherCommand { get; }
    public ReactiveCommand<Unit, Unit> AddLauncherCommand { get; }
    public ReactiveCommand<Launcher, Unit> DeleteLauncherCommand { get; }

    // 编辑器命令
    public ReactiveCommand<object, Unit> SelectFilePathCommand { get; }


    // 字段
    private ObservableCollection<Desktop>? _desktops = [];

    public ObservableCollection<Desktop>? Desktops
    {
        get => _desktops;
        set => this.RaiseAndSetIfChanged(ref _desktops, value);
    }

    private Desktop? _currentDesktop;

    public Desktop? CurrentDesktop
    {
        get => _currentDesktop;
        set => this.RaiseAndSetIfChanged(ref _currentDesktop, value);
    }

    private ObservableCollection<Launcher>? _launchers = [];

    public ObservableCollection<Launcher>? Launchers
    {
        get => _launchers;
        set => this.RaiseAndSetIfChanged(ref _launchers, value);
    }

    // 方法
    public void Refresh()
    {
        using var db = DatabaseContextFactory.CreateContext();

        // 刷新桌面列表
        var desktops = db.Desktops.ToList();
        Desktops?.Clear();
        Desktops = new ObservableCollection<Desktop>(desktops);

        // 刷新启动器列表
        var launchers = db.Desktops
            .Include(e => e.Launchers)
            .Where(e => CurrentDesktop != null && e.Id == CurrentDesktop.Id)
            .SelectMany(e => e.Launchers)
            .ToList();
        Launchers?.Clear();
        Launchers = new ObservableCollection<Launcher>(launchers);
    }
}