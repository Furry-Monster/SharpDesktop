using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using Newtonsoft.Json;
using ReactiveUI;

namespace SharpDesktop.Util;

public class NewtonsoftJsonSuspensionDriver(string file) : ISuspensionDriver
{
    
    private readonly string _file = file;

    private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All
    };

    /// <summary>
    /// 从文件中加载状态
    /// </summary>
    /// <returns> 状态对象 </returns>
    public IObservable<object> LoadState()
    {
        var lines = File.ReadAllText(_file);
        var state = JsonConvert.DeserializeObject<object>(lines, _settings);
        return Observable.Return(state)!;

    }

    /// <summary>
    /// 将状态保存到文件中
    /// </summary>
    /// <param name="state"> 状态对象 </param>
    /// <returns> 保存结果 </returns>
    public IObservable<Unit> SaveState(object state)
    {
        var lines = JsonConvert.SerializeObject(state, _settings);
        File.WriteAllText(_file, lines);
        return Observable.Return(Unit.Default);
    }

    /// <summary>
    /// 删除状态文件
    /// </summary>
    /// <returns> 删除结果 </returns>
    public IObservable<Unit> InvalidateState()
    {
        if (File.Exists(_file)) File.Delete(_file);
        return Observable.Return(Unit.Default);
    }
}