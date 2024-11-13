using System;
using System.Globalization;
using Avalonia.Media.Imaging;

namespace SharpDesktop.Util.Converter;

public class PathToBitmap : ConverterBase<string, Bitmap>
{
    public override Bitmap Convert(string? value, object? parameter, CultureInfo culture)
    {
        return value == null ?
            ImageLoader.LoadFromResource(new Uri("avares://SharpDesktop/Assets/icon.png"))
            : new Bitmap(value);
    }

    public override string ConvertBack(Bitmap? value, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}