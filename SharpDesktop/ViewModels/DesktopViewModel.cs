using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Windows.Input;
using DialogHostAvalonia;
using ReactiveUI;
using SharpDesktop.Models;
using SharpDesktop.Models.Entity;
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
            //TODO: 实现编辑桌面功能
            using var db = DatabaseContextFactory.CreateContext();

            var dialog = new EditDesktopDialog()
            {
                DataContext = desktop
            };

            var result = await DialogHost.Show(dialog);

            if (Convert.ToBoolean(result))
            {
                // 数据验证
                //if (!File.Exists(dialog.IconPath.Text) || PathHelper.GetSuffix(dialog.IconPath.Text).ToLower() != "ico")
                //{
                //    var messageDialog = new MessageDialog("文件不存在或不支持");
                //    await DialogHost.Show(messageDialog);
                //    return;
                //}

                // 数据克隆
                desktop.Name = dialog.DesktopName.Text!;
                desktop.IconPath = dialog.IconPath.Text;

                // 数据保存
                db.Desktops.Update(desktop);
                db.SaveChanges();

                Refresh();
            }
        });

        DeleteDesktopCommand = ReactiveCommand.Create<Desktop>(async desktop =>
        {
            //TODO: 实现删除桌面功能
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

        OpenDesktopCommand = ReactiveCommand.Create<Desktop>(desktop =>
        {
            //TODO: 实现打开桌面功能
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
    public ReactiveCommand<Desktop, Unit> OpenDesktopCommand { get; }


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