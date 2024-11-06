using ReactiveUI;
using System.Collections.Generic;
using System;

namespace SharpDesktop.ViewModels;

public class ViewModelLocator
{
    // 单例模式
    private static ViewModelLocator? _instance;

    public static ViewModelLocator Instance => _instance ??= new ViewModelLocator();

    public ViewModelLocator()
    {
        _instance = this;
        _dic = new Dictionary<Type, ViewModelBase?>();
    }

    #region 操作
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="hostScreen"> 宿主屏幕 </param>
    /// <returns> ViewModelLocator 实例 </returns>
    public ViewModelLocator Init(IScreen hostScreen)
    {
        _hostScreen = hostScreen;

        // 注册路由视图模型
        Instance.RegisterRoutable<DesktopViewModel>(hostScreen)
                .RegisterRoutable<ResourceViewModel>(hostScreen)
                .RegisterRoutable<WorkspaceViewModel>(hostScreen)
                .RegisterRoutable<ToolboxViewModel>(hostScreen)
                .RegisterRoutable<TerminalViewModel>(hostScreen)
                .RegisterRoutable<AiViewModel>(hostScreen);

        return Instance;
    }

    /// <summary>
    /// 注册视图模型
    /// </summary>
    /// <typeparam name="TViewModel"> 视图模型类型 </typeparam>
    /// <typeparam name="TConcrete"> 视图模型的实例 </typeparam>
    public ViewModelLocator Register<TViewModel, TConcrete>() where TViewModel : ViewModelBase where TConcrete : TViewModel
    {
        var viewModelInstance = Activator.CreateInstance<TConcrete>();
        _dic[typeof(TViewModel)] = viewModelInstance ?? throw new InvalidOperationException($"无法创建类型 {typeof(TViewModel).Name} 的实例");
        return Instance;
    }

    /// <summary>
    ///  注册可路由的视图模型
    /// </summary>
    /// <typeparam name="TViewModel"> 视图模型类型 </typeparam>
    /// <param name="hostScreen"> 宿主屏幕 </param>
    public ViewModelLocator RegisterRoutable<TViewModel>(IScreen hostScreen) where TViewModel : ViewModelBase
    {
        if (hostScreen is null) throw new ArgumentNullException(nameof(hostScreen));

        // 使用反射创建 TViewModel 的实例
        var viewModelInstance = Activator.CreateInstance(typeof(TViewModel), hostScreen) as TViewModel;
        _dic[typeof(TViewModel)] = viewModelInstance ?? throw new InvalidOperationException($"无法创建类型 {typeof(TViewModel).Name} 的实例");

        return Instance;
    }

    /// <summary>
    /// 获取视图模型实例
    /// </summary>
    /// <typeparam name="TViewModel"> 视图模型类型 </typeparam>
    /// <returns> 视图模型实例 </returns>
    /// <exception cref="ArgumentException"> 未注册视图模型 </exception>
    public TViewModel GetInstance<TViewModel>() where TViewModel : ViewModelBase
    {
        if (_dic.TryGetValue(typeof(TViewModel), out var vm))
        {
            return (TViewModel)vm!;
        }

        throw new ArgumentException($"未注册{typeof(TViewModel).Name}的视图模型");
    }

    /// <summary>
    /// 判断是否注册了视图模型
    /// </summary>
    /// <typeparam name="TViewModel"> 视图模型类型 </typeparam>
    /// <returns> 是否注册了视图模型 </returns>
    public bool IsRegistered<TViewModel>() where TViewModel : ViewModelBase
    {
        return _dic.ContainsKey(typeof(TViewModel));
    }

    /// <summary>
    /// 注销视图模型
    /// </summary>
    /// <typeparam name="TViewModel"> 视图模型类型 </typeparam>
    public ViewModelLocator Unregister<TViewModel>() where TViewModel : ViewModelBase
    {
        _dic.Remove(typeof(TViewModel));
        return Instance;
    }

    /// <summary>
    /// 清空所有视图模型
    /// </summary>
    public ViewModelLocator Clear()
    {
        _dic.Clear();
        return Instance;
    }

    /// <summary>
    /// 尝试获取视图模型
    /// </summary>
    /// <param name="type"> 视图模型类型 </param>
    /// <param name="vm"> 视图模型实例 </param>
    /// <returns> 是否获取成功 </returns>
    public bool TryGetViewModel(Type type, out ViewModelBase? vm)
    {
        return _dic.TryGetValue(type, out vm);
    }

    /// <summary>
    /// 尝试获取视图模型
    /// </summary>
    /// <typeparam name="TViewModel"> 视图模型类型 </typeparam>
    /// <param name="vm"> 视图模型实例 </param>
    /// <returns> 是否获取成功 </returns>
    public bool TryGetViewModel<TViewModel>(out TViewModel? vm) where TViewModel : ViewModelBase
    {
        if (_dic.TryGetValue(typeof(TViewModel), out var v))
        {
            vm = (TViewModel)v!;
            return true;
        }

        vm = default;
        return false;
    }

    /// <summary>
    /// 尝试获取视图模型
    /// </summary>
    /// <typeparam name="TViewModel"> 视图模型类型 </typeparam>
    /// <param name="vm"> 视图模型实例 </param>
    /// <returns> 是否获取成功 </returns>
    public bool TryGetViewModel<TViewModel>(out ViewModelBase? vm) where TViewModel : ViewModelBase
    {
        if (_dic.TryGetValue(typeof(TViewModel), out var v))
        {
            vm = v;
            return true;
        }

        vm = default;
        return false;
    }

    #endregion

    // 属性与字段

    // 从类型到视图实例的字典
    private readonly Dictionary<Type, ViewModelBase?> _dic;

    // 宿主屏幕
    private IScreen? _hostScreen;

    public IScreen HostScreen
    {
        get => _hostScreen ?? throw new InvalidOperationException("未设置HostScreen");
        set => _hostScreen = value;
    }

    // 内置注册的视图模型

    public DesktopViewModel DesktopViewModel => this.GetInstance<DesktopViewModel>();

    public ResourceViewModel ResourceViewModel => this.GetInstance<ResourceViewModel>();

    public WorkspaceViewModel WorkspaceViewModel => this.GetInstance<WorkspaceViewModel>();

    public ToolboxViewModel ToolboxViewModel => this.GetInstance<ToolboxViewModel>();

    public TerminalViewModel TerminalViewModel => this.GetInstance<TerminalViewModel>();

    public AiViewModel AiViewModel => this.GetInstance<AiViewModel>();

}