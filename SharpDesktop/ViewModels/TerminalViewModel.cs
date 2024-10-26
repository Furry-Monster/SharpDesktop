using ReactiveUI;
using System;
using System.Windows.Input;
using SharpDesktop.Util;

namespace SharpDesktop.ViewModels;

public class TerminalViewModel : ViewModelBase, IRoutableViewModel
{
    public TerminalViewModel(IScreen screen)
    {
        HostScreen = screen;

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
}