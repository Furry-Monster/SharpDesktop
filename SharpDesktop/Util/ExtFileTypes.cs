using Avalonia.Platform.Storage;

namespace SharpDesktop.Util;

/// <summary>
/// 用于扩展FilePicker的FileTypes<br/>
/// 详细参考<a href="https://docs.avaloniaui.net/zh-Hans/docs/concepts/services/storage-provider/file-picker-options"/>
/// </summary>
public class ExtFileTypes
{
    public static FilePickerFileType Executable { get; } = new("Executable")
    {
        Patterns = new[] { "*.exe", "*.lnk" }
    };
}