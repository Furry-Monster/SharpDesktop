using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using SharpDesktop.Views;

namespace SharpDesktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ExitCommand = ReactiveCommand.Create(() =>
            {
                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApp)
                {
                    desktopApp.Shutdown(0);
                }
            });

            ConfigCommand = ReactiveCommand.Create(() =>
            {
                // TODO:打开配置窗口
            });

            MinimizeCommand = ReactiveCommand.Create(() =>
            {
                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime
                    {
                        MainWindow: not null
                    } desktopApp)
                {
                    desktopApp.MainWindow.WindowState = desktopApp.MainWindow.WindowState == WindowState.Maximized
                        ? WindowState.Minimized
                        : WindowState.Maximized;
                }
            });

            HelpCommand = ReactiveCommand.Create(() =>
            {
                // TODO:打开帮助文档
            });

            AboutCommand = ReactiveCommand.Create(() =>
            {
                // TODO:打开关于窗口
            });

            RefreshCommand = ReactiveCommand.Create(() =>
            {
                // TODO:刷新页面
            });
        }

        public ICommand ExitCommand { get; private set; }
        public ICommand ConfigCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }
        public ICommand HelpCommand { get; private set; }
        public ICommand AboutCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        private string _path = "None";

        public string Path
        {
            get => _path;
            set => this.RaiseAndSetIfChanged(ref _path, value);
        }
    }
}
