using ReactiveUI;
using SharpDesktop.Models.Entity;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Input;


namespace SharpDesktop.ViewModels;

public class TerminalViewModel : ViewModelBase, IRoutableViewModel
{


    public TerminalViewModel(IScreen hostScreen) : base(hostScreen)
    {
        HostScreen = hostScreen;

        //---------------
        // 选择器命令
        //---------------
        #region 选择器命令实现
        EditTerminalCommand = ReactiveCommand.Create<Terminal>(terminal =>
        {
            //TODO: Edit the selected terminal
        });

        DeleteTerminalCommand = ReactiveCommand.Create<Terminal>(terminal =>
        {
            //TODO: Delete the selected terminal
        });

        SelectTerminalCommand = ReactiveCommand.Create<Terminal>(terminal =>
        {
            // TODO: Select the selected terminal
        });

        AddTerminalCommand = ReactiveCommand.Create(() =>
        {
            //TODO: Add a new terminal
        });
        #endregion

        //---------------
        // cmd命令
        //---------------
        #region 选择器命令实现
        AddCmdCommand = ReactiveCommand.Create(() =>
        {
            //TODO: Add a new command
        });

        EditCmdCommand = ReactiveCommand.Create<Command>(command =>
        {
            //TODO: Edit the selected command
        });

        RunCmdCommand = ReactiveCommand.Create<Command>(command =>
        {
            //TODO: Run the selected command
        });

        DeleteCmdCommand = ReactiveCommand.Create<Command>(command =>
        {
            //TODO: Delete the selected command
        });
        #endregion
    }

    // 路由接口实现
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }

    // 选择器命令
    public ReactiveCommand<Terminal, Unit> EditTerminalCommand { get; private set; }
    public ReactiveCommand<Terminal, Unit> DeleteTerminalCommand { get; private set; }
    public ReactiveCommand<Terminal, Unit> SelectTerminalCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> AddTerminalCommand { get; private set; }

    // Command列表命令
    public ReactiveCommand<Unit, Unit> AddCmdCommand { get; private set; }
    public ReactiveCommand<Command, Unit> EditCmdCommand { get; private set; }
    public ReactiveCommand<Command, Unit> RunCmdCommand { get; private set; }
    public ReactiveCommand<Command, Unit> DeleteCmdCommand { get; private set; }

    // 字段
    private ObservableCollection<Terminal>? _terminalList;

    public ObservableCollection<Terminal>? TerminalList
    {
        get => _terminalList;
        set => this.RaiseAndSetIfChanged(ref _terminalList, value);
    }

    private Terminal? _selectedTerminal;

    public Terminal? SelectedTerminal
    {
        get => _selectedTerminal;
        set => this.RaiseAndSetIfChanged(ref _selectedTerminal, value);
    }

    private ObservableCollection<Command>? _commandList;

    public ObservableCollection<Command>? CommandList
    {
        get => _commandList;
        set => this.RaiseAndSetIfChanged(ref _commandList, value);
    }

    // 方法
    public void Refresh()
    {
        //TODO: Refresh the terminal list and command list
    }
}
