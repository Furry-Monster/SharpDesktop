using System.Runtime.InteropServices;
using System;

#pragma warning disable SYSLIB1054
#pragma warning disable CA1401

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace SharpDesktop.Util;

public static class Win32Api
{
    #region Consts

    public const int SWP_NOOWNERZORDER = 0x200;
    public const int SWP_NOREDRAW = 0x8;
    public const int SWP_NOZORDER = 0x4;
    public const int SWP_SHOWWINDOW = 0x0040;
    public const int WS_EX_MDICHILD = 0x40;
    public const int SWP_FRAMECHANGED = 0x20;
    public const int SWP_NOACTIVATE = 0x10;
    public const int SWP_ASYNCWINDOWPOS = 0x4000;
    public const int SWP_NOMOVE = 0x2;
    public const int SWP_NOSIZE = 0x1;
    public const int GWL_STYLE = (-16);
    public const int WS_VISIBLE = 0x10000000;
    public const int WM_CLOSE = 0x10;
    public const int WS_CHILD = 0x40000000;
    public const long WS_CATION = 0x00C00000L;
    public const long WS_CATION_2 = 0x00C0000L;

    public const int SW_HIDE = 0; //{隐藏, 并且任务栏也没有最小化图标}
    public const int SW_SHOWNORMAL = 1; //{用最近的大小和位置显示, 激活}
    public const int SW_NORMAL = 1; //{同 SW_SHOWNORMAL}
    public const int SW_SHOWMINIMIZED = 2; //{最小化, 激活}
    public const int SW_SHOWMAXIMIZED = 3; //{最大化, 激活}
    public const int SW_MAXIMIZE = 3; //{同 SW_SHOWMAXIMIZED}
    public const int SW_SHOWNOACTIVATE = 4; //{用最近的大小和位置显示, 不激活}
    public const int SW_SHOW = 5; //{同 SW_SHOWNORMAL}
    public const int SW_MINIMIZE = 6; //{最小化, 不激活}
    public const int SW_SHOWMINNOACTIVE = 7; //{同 SW_MINIMIZE}
    public const int SW_SHOWNA = 8; //{同 SW_SHOWNOACTIVATE}
    public const int SW_RESTORE = 9; //{同 SW_SHOWNORMAL}
    public const int SW_SHOWDEFAULT = 10; //{同 SW_SHOWNORMAL}
    public const int SW_MAX = 10; //{同 SW_SHOWNORMAL}    

    #endregion

    #region Win32 API

    [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
         CharSet = CharSet.Unicode, ExactSpelling = true,
         CallingConvention = CallingConvention.StdCall)]
    public static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
    public static extern long GetWindowLong(IntPtr hwnd, int nIndex);



    [DllImport("user32.dll")]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


    //public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong)
    //{
    //    if (IntPtr.Size == 4)
    //    {
    //        return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
    //    }
    //    return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
    //}

    [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
    public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
    public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

    [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
    public static extern bool PostMessage(IntPtr hwnd, uint Msg, uint wParam, uint lParam);

    [DllImport("Kernel32.dll")]
    private static extern int FormatMessage(int flag, ref IntPtr source, int msgid, int langid, ref string? buf, int size, ref IntPtr args);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetParent(IntPtr hwnd);

    [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    /// <summary>
    ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。
    ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。 
    /// </summary>
    /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>
    /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>
    [DllImport("User32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);


    // Addson
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SetWindowLongPtr(HandleRef hWnd, int nIndex, IntPtr dwNewLong);


    #endregion

    #region Public Methods

    /// <summary>
    /// 获取系统错误信息描述
    /// </summary>
    /// <returns></returns>
    public static string? GetLastError()
    {
        var errCode = Marshal.GetLastWin32Error();
        var tempptr = IntPtr.Zero;
        string? msg = null;
        FormatMessage(0x1300, ref tempptr, errCode, 0, ref msg, 255, ref tempptr);
        return msg;
    }

    /// <summary>
    /// 获取系统错误信息描述
    /// </summary>
    /// <param name="errCode">系统错误码</param>
    /// <returns></returns>
    public static string? GetLastErrorString(int errCode)
    {
        var tempptr = IntPtr.Zero;
        string? msg = null;
        FormatMessage(0x1300, ref tempptr, errCode, 0, ref msg, 255, ref tempptr);
        return msg;
    }

    #endregion
}