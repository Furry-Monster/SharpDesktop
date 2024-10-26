using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace SharpDesktop.Util;

public class ProcessShell
{
    [DllImport("User32.dll ", EntryPoint = "SetParent")]
    private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    [DllImport("user32.dll ", EntryPoint = "ShowWindow")]
    public static extern int ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

    public static void ShowWindow(string fileName)
    {
        var process = new Process();
        process.StartInfo.FileName = fileName;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
        process.Start();
        Thread.Sleep(200);
        SetWindowPos(process.MainWindowHandle, IntPtr.Zero, 0, 0, 0, 0, 0);
        SetParent(process.MainWindowHandle, -1);
        ShowWindow(process.MainWindowHandle, 3);

    }
}