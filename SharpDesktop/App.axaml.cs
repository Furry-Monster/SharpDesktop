using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using SharpDesktop.Models;
using SharpDesktop.Util;
using SharpDesktop.ViewModels;
using SharpDesktop.Views;

namespace SharpDesktop
{
    public partial class App : Application
    {
        // 单例
        private static App? _instance;

        public static App Instance => _instance ??= new App();

        // 初始化
        public override void Initialize()
        {
            _instance = this;
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // 创建AutoSuspendHelper对象
            var suspension = new AutoSuspendHelper(ApplicationLifetime!);
            RxApp.SuspensionHost.CreateNewAppState = () => new MainWindowViewModel();
            RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver("appstate.json"));
            suspension.OnFrameworkInitializationCompleted();

            // 加载保存的视图模型状态
            var state = RxApp.SuspensionHost.GetAppState<MainWindowViewModel>();

            // 注册ViewModelLocator
            ViewModelLocator.Instance.Init(state);

            // 加载主窗口
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = state,
                };

                // 注册应用程序生命周期事件
                desktop.Startup += OnDesktopOnStartup;
            }

            base.OnFrameworkInitializationCompleted();
        }


        private void OnDesktopOnStartup(object? sender, ControlledApplicationLifetimeStartupEventArgs args)
        {
            // 创建数据库
            using var dbContext = DatabaseContextFactory.CreateContext();
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate(); //执行迁移
            }
        }
    }
}