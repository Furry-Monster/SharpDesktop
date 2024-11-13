using System;
using System.Globalization;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace SharpDesktop.Util.Converter;

public class PathToIcon : ConverterBase<string, Bitmap>
{
    public override Bitmap Convert(string? value, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override string ConvertBack(Bitmap? value, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}