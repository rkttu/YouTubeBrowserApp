using System;
using System.Runtime.InteropServices;

namespace YouTubeBrowserApp
{
    internal static class NativeMethods
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WS_SIZEBOX = 0x00040000;
        public const int WS_MINIMIZEBOX = 0x00020000;

        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, ExactSpelling = true, CharSet = CharSet.Unicode, EntryPoint = "SendMessageW")]
        public static extern int SendMessage(IntPtr handle, int message, int wordParameter, int longParameter);

        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, ExactSpelling = true, CharSet = CharSet.None, EntryPoint = "ReleaseCapture")]
        public static extern bool ReleaseCapture();

        public enum PROCESS_DPI_AWARENESS : int
        {
            PROCESS_DPI_UNAWARE,
            PROCESS_SYSTEM_DPI_AWARE,
            PROCESS_PER_MONITOR_DPI_AWARE
        }

        [DllImport("shcore.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, EntryPoint = "SetProcessDpiAwareness")]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern int SetProcessDpiAwareness(PROCESS_DPI_AWARENESS value);
    }
}
