using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
#pragma warning disable CA1416

namespace SharpDesktop.Util.Converter;

public class PathToIcon : ConverterBase<string, Bitmap>
{
    /// <summary>
    /// 采用stream方式读取图片，避免占用过多内存
    /// </summary>
    /// <param name="value"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public override Bitmap Convert(string? value, object? parameter, CultureInfo culture)
    {
        if (value == null)
            return ImageLoader.LoadFromResource(new Uri("avares://SharpDesktop/Assets/icon.png"));

        // 提取icon
        using var icon = Icon.ExtractAssociatedIcon(value)!.ToBitmap();

        // 保存icon到内存流
        using var stream = new MemoryStream();
        icon.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        stream.Position = 0; // 重置流的位置

        // 读取内存流
        return new Bitmap(stream);
    }

    public override string ConvertBack(Bitmap? value, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}