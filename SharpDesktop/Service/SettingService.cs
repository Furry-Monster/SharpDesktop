using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SharpDesktop.Service;

/// <summary>
/// 系统配置信息
/// </summary>
public class SettingService
{
    private static SettingService? _instance;

    public static SettingService Instance
    {
        get { return _instance ??= new SettingService(); }
    }

    // 应用程序设置
    public string AppDataPath { get; set; } // 应用数据路径

    public double Width { get; set; } // 窗口宽度
    public double Height { get; set; } // 窗口高度
    public int X { get; set; } // 窗口位置X坐标
    public int Y { get; set; } // 窗口位置Y坐标

    public bool IsMaximized { get; set; } // 是否最大化

    public int SeparatorMode { get; set; } // 分隔符模式



    public async Task Save()
    {
        //TODO: 保存配置信息
    }

    public async Task Load()
    {
        //TODO: 加载配置信息
    }
}