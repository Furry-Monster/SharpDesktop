using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SharpDesktop.ViewModels;

public class ResourceViewModel : ViewModelBase, IRoutableViewModel
{
    public ResourceViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;

        //---------------
        // 工具栏命令
        //---------------
        #region 工具栏命令

        NavBackCommand = ReactiveCommand.Create(() =>
        {
            //TODO: 实现返回功能
        });

        NavForwardCommand = ReactiveCommand.Create(() =>
        {
            //TODO: 实现前进功能
        });

        SearchCommand = ReactiveCommand.CreateFromTask((string path) =>
        {
            //TODO: 实现搜索功能
            Console.WriteLine(path);
            return Task.FromResult(0);
        });

        #endregion
    }

    // 路由接口实现
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }

    // 工具栏命令
    public ICommand NavBackCommand { get; }
    public ICommand NavForwardCommand { get; }
    public ICommand SearchCommand { get; }

    private string _path;

    public string Path
    {
        get => _path;
        set => this.RaiseAndSetIfChanged(ref _path, value);
    }
}