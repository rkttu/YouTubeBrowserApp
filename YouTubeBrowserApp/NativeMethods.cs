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
    }
}
