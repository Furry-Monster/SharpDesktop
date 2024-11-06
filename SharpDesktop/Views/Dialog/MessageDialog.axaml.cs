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
        txtContent.Text = content;
    }

    public MessageDialog(string title, string content)
    {
        InitializeComponent();
        txtTitel.Text = title;
        txtContent.Text = content;
    }
}