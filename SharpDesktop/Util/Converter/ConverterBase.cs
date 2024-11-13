using System;
using System.Globalization;
using System.Security.AccessControl;
using Avalonia.Data.Converters;

namespace SharpDesktop.Util.Converter;

public abstract class ConverterBase<TSource, TTarget> : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Convert((TSource)value!, parameter, culture);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return ConvertBack((TTarget)value!, parameter, culture);
    }

    public abstract TTarget Convert(TSource? value, object? parameter, CultureInfo culture);

    public abstract TSource ConvertBack(TTarget? value, object? parameter, CultureInfo culture);
}