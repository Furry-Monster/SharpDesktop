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
            // ����AutoSuspendHelper��������ʵ�ֺ�̨����
            var suspension = new AutoSuspendHelper(ApplicationLifetime!);
            RxApp.SuspensionHost.CreateNewAppState = () => new MainWindowViewModel();
            RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver("appstate.json"));
            suspension.OnFrameworkInitializationCompleted();

            // ���ر������ͼģ��״̬��
            var state = RxApp.SuspensionHost.GetAppState<MainWindowViewModel>();
            new MainWindow { DataContext = state }.Show();

            // ����������(without rxui)
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