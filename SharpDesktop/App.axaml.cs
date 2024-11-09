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
        // ����
        private static App? _instance;

        public static App Instance => _instance ??= new App();

        // ��ʼ��
        public override void Initialize()
        {
            _instance = this;
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // ����AutoSuspendHelper����
            var suspension = new AutoSuspendHelper(ApplicationLifetime!);
            RxApp.SuspensionHost.CreateNewAppState = () => new MainWindowViewModel();
            RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver("appstate.json"));
            suspension.OnFrameworkInitializationCompleted();

            // ���ر������ͼģ��״̬
            var state = RxApp.SuspensionHost.GetAppState<MainWindowViewModel>();

            // ע��ViewModelLocator
            ViewModelLocator.Instance.Init(state);

            // ����������
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = state,
                };

                // ע��Ӧ�ó������������¼�
                desktop.Startup += OnDesktopOnStartup;
            }

            base.OnFrameworkInitializationCompleted();
        }


        private void OnDesktopOnStartup(object? sender, ControlledApplicationLifetimeStartupEventArgs args)
        {
            // �������ݿ�
            using var dbContext = DatabaseContextFactory.CreateContext();
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate(); //ִ��Ǩ��
            }
        }
    }
}