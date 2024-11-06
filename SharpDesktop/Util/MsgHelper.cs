using DialogHostAvalonia;
using SharpDesktop.Views.Dialog;

namespace SharpDesktop.Util;

/// <summary>
/// 消息弹窗帮助类
/// </summary>
public class MsgHelper
{
    /// <summary>
    ///  弹出Error对话框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="caption"></param>
    public static void ShowError(string message, string caption)
    {
        DialogHost.Show(new MessageDialog("Error", "message" + "\n" + "caption"));
    }

    /// <summary>
    /// 弹出Info对话框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="caption"></param>
    public static void ShowInfo(string message, string caption)
    {
        DialogHost.Show(new MessageDialog("Info", "message" + "\n" + "caption"));
    }

    /// <summary>
    /// 弹出Warning对话框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="caption"></param>
    public static void ShowWarning(string message, string caption)
    {
        DialogHost.Show(new MessageDialog("Warning", "message" + "\n" + "caption"));
    }

    /// <summary>
    /// 弹出Success对话框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="caption"></param>
    public static void ShowSuccess(string message, string caption)
    {
        DialogHost.Show(new MessageDialog("Success", "message" + "\n" + "caption"));
    }

    /// <summary>
    /// 弹出Question对话框
    /// </summary>
    /// <param name="message"></param>
    /// <param name="caption"></param>
    public static void ShowQuestion(string message, string caption)
    {
        DialogHost.Show(new MessageDialog("Question", "message" + "\n" + "caption"));
    }
}