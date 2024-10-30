using ReactiveUI;
using SharpDesktop.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace SharpDesktop.ViewModels;

public class TerminalViewModel : ViewModelBase, IRoutableViewModel
{
    public TerminalViewModel(IScreen screen)
    {
        HostScreen = screen;

        QuickCommandList =
        [
            new CommandItem("ls", "ls -al", "显示当前目录下的文件列表"),
            new CommandItem("cd", @"cd /d D:\", "切换到 D 盘根目录")
        ];

        //---------------
        // 工具栏命令
        //---------------
        #region 工具栏命令实现
        NewConsoleCommand = ReactiveCommand.Create(() =>
        {
            //TODO: Open a new console window
        });

        NewPowerShellCommand = ReactiveCommand.Create(() =>
        {
            //TODO: Open a new PowerShell window
        });

        NewGitBashCommand = ReactiveCommand.Create(() =>
        {
            //TODO: Open a new git-bash window
        });

        ClearCommand = ReactiveCommand.Create(() =>
        {
            //TODO: Clear the terminal output
        });
        #endregion
    }

    // 路由接口实现
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }

    // 工具栏命令
    public ICommand NewConsoleCommand { get; private set; }
    public ICommand NewPowerShellCommand { get; private set; }
    public ICommand NewGitBashCommand { get; private set; }
    public ICommand ClearCommand { get; private set; }



    private ObservableCollection<CommandItem>? _quickCommandList;

    public ObservableCollection<CommandItem>? QuickCommandList
    {
        get => _quickCommandList;
        set => this.RaiseAndSetIfChanged(ref _quickCommandList, value);
    }
}
