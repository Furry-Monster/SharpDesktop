using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using System.Diagnostics;
using System.Reactive;
using System.Runtime.Serialization;
using System.Windows.Input;

namespace SharpDesktop.ViewModels
{
    [DataContract]
    public class MainWindowViewModel : ViewModelBase, IScreen
    {
        // 单例模式
        private static MainWindowViewModel? _instance;

        public static MainWindowViewModel Instance => _instance ??= new MainWindowViewModel();

        // 页面路由
        public RoutingState Router { get; } = new RoutingState();

        public MainWindowViewModel()
        {
            // 注册单例
            _instance = this;

            // --------------------
            // 窗口命令实现
            // --------------------
            #region 窗口命令实现
            ExitCommand = ReactiveCommand.Create(() =>
            {
                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApp)
                {
                    desktopApp.Shutdown(0);
                }
            });

            MaximizeCommand = ReactiveCommand.Create(() =>
            {
                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime
                    {
                        MainWindow: not null
                    } desktopApp)
                {
                    desktopApp.MainWindow.WindowState = desktopApp.MainWindow.WindowState == WindowState.Maximized
                        ? WindowState.Normal
                        : WindowState.Maximized;
                }
            });

            MinimizeCommand = ReactiveCommand.Create(() =>
            {
                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime
                    {
                        MainWindow: not null
                    } desktopApp)
                {
                    desktopApp.MainWindow.WindowState = WindowState.Minimized;
                }
            });
            #endregion

            // --------------------
            // 工具命令实现
            // --------------------
            #region 工具命令实现
            HelpCommand = ReactiveCommand.Create(() =>
            {
                const string url = "https://github.com/Furry-Monster/SharpDesktop/wiki";

                Process.Start(
                    new ProcessStartInfo("cmd", $"/c start {url}")
                    {
                        CreateNoWindow = true
                    });
            });

            AboutCommand = ReactiveCommand.Create(() =>
            {
                const string url = "https://github.com/Furry-Monster/SharpDesktop";

                Process.Start(
                    new ProcessStartInfo("cmd", $"/c start {url}")
                    {
                        CreateNoWindow = true
                    });
            });

            RefreshCommand = ReactiveCommand.Create(() =>
            {
                // TODO:刷新页面

            });

            ConfigCommand = ReactiveCommand.Create(() =>
            {
                // TODO:打开配置窗口
                IsSettingOpen = true;
            });
            #endregion

            // --------------------
            // 页面命令实现
            // --------------------
            #region 页面命令实现
            DesktopCommand = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new DesktopViewModel(this))
            );

            ResourceCommand = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new ResourceViewModel(this))
            );

            WorkspaceCommand = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new WorkspaceViewModel(this))
            );

            TerminalCommand = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new TerminalViewModel(this))
            );

            ToolboxCommand = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new ToolboxViewModel(this))
            );

            AiCommand = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new AiViewModel(this))
            );
            #endregion
        }

        // 窗口命令
        public ICommand ExitCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }

        // 工具命令
        public ICommand HelpCommand { get; private set; }
        public ICommand AboutCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand ConfigCommand { get; private set; }

        // 页面命令
        public ReactiveCommand<Unit, IRoutableViewModel> DesktopCommand { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> ResourceCommand { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> WorkspaceCommand { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> TerminalCommand { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> ToolboxCommand { get; private set; }
        public ReactiveCommand<Unit, IRoutableViewModel> AiCommand { get; private set; }


        private string _path = "None";

        public string Path
        {
            get => _path;
            set => this.RaiseAndSetIfChanged(ref _path, value);
        }

        private bool _isSettingOpen = false;

        [DataMember]
        public bool IsSettingOpen
        {
            get => _isSettingOpen;
            set => this.RaiseAndSetIfChanged(ref _isSettingOpen, value);
        }
    }
}
