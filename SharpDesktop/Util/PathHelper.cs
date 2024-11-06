namespace SharpDesktop.Util;

/// <summary>
/// 路径处理类
/// </summary>
public class PathHelper
{
    /// <summary>
    /// 更换分隔符为Windows风格
    /// </summary>
    /// <param name="path"> 文件地址</param>
    /// <returns> 解析地址</returns>
    public static string FormatPath(string path)
    {
        return path.Replace('/', '\\');
    }

    /// <summary>
    /// 获取文件名
    /// </summary>
    /// <param name="path"> 文件地址</param>
    /// <returns> 解析地址</returns>
    public static string GetFileName(string path)
    {
        return path[(path.LastIndexOf('\\') + 1)..];
    }

    /// <summary>
    /// 获取文件后缀
    /// </summary>
    /// <param name="path"> 文件地址</param>
    /// <returns> 解析地址</returns>
    public static string GetSuffix(string path)
    {
        if (path.LastIndexOf('.') <= path.LastIndexOf('\\'))
        {
            return string.Empty;
        }
        else
        {
            return path[(path.LastIndexOf('.') + 1)..];
        }
    }

    /// <summary>
    /// 获取文件名（不含后缀）
    /// </summary>
    /// <param name="path"> 文件地址</param>
    /// <returns> 解析地址</returns>
    public static string GetFileNameWithoutSuffix(string path)
    {
        return GetFileName(path)[0..^(GetSuffix(path).Length + 1)];
    }

    /// <summary>
    /// 获取文件所在文件夹路径
    /// </summary>
    /// <param name="path"> 文件地址</param>
    /// <returns> 解析地址</returns>
    public static string GetLocatedFolderPath(string path)
    {
        return path[0..^GetFileName(path).Length];
    }
}