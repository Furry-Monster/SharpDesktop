using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SharpDesktop.Util;
using SharpDesktop.ViewModels;
using SharpDesktop.Views;

namespace SharpDesktop
{
    public partial class App : Application
    {
        private static App? _instance;

        public static App Instance => _instance ??= new App();

        public override void Initialize()
        {
            _instance = this;
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // 创建AutoSuspendHelper对象，用于实现后台运行
            var suspension = new AutoSuspendHelper(ApplicationLifetime!);
            RxApp.SuspensionHost.CreateNewAppState = () => new MainWindowViewModel();
            RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver("appstate.json"));
            suspension.OnFrameworkInitializationCompleted();

            // 加载保存的视图模型状态。
            var state = RxApp.SuspensionHost.GetAppState<MainWindowViewModel>();
            new MainWindow { DataContext = state }.Show();

            // 加载主窗口(without rxui)
            // if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            // {
            //     desktop.MainWindow = new MainWindow
            //     {
            //         DataContext = new MainWindowViewModel(),
            //     };
            // }

            base.OnFrameworkInitializationCompleted();
        }
    }
}