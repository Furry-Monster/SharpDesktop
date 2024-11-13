using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using SharpDesktop.Util;

namespace SharpDesktop.Views.Dialog;

public partial class EditLauncherDialog : UserControl
{
    public EditLauncherDialog()
    {
        InitializeComponent();
    }

    private async void OpenExecutableSelector(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var textBox = button!.Tag as TextBox;
        var storage = TopLevel.GetTopLevel(button)?.StorageProvider;

        if (storage == null) return;

        var files = await storage.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            AllowMultiple = false,
            FileTypeFilter = new[] { ExtFileTypes.Executable }
        });

        textBox!.Text = files.FirstOrDefault()?.TryGetLocalPath();
    }

    private async void OpenImageSelector(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var textBox = button!.Tag as TextBox;
        var storage = TopLevel.GetTopLevel(button)?.StorageProvider;

        if (storage == null) return;

        var files = await storage.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            AllowMultiple = false,
            FileTypeFilter = new[] { FilePickerFileTypes.ImageAll, }
        });

        textBox!.Text = files.FirstOrDefault()?.TryGetLocalPath();
    }
}