using Avalonia.Controls;

namespace SharpDesktop.Views.Dialog;

public partial class MessageDialog : UserControl
{
    public MessageDialog()
    {
        InitializeComponent();
    }

    public MessageDialog(string content)
    {
        InitializeComponent();
        TxtContent.Text = content;
    }

    public MessageDialog(string title, string content)
    {
        InitializeComponent();
        TxtTitle.Text = title;
        TxtContent.Text = content;
    }
}