using System;
using System.Runtime.InteropServices;

namespace YouTubeBrowserApp
{
    internal static class NativeMethods
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int CS_DROPSHADOW = 0x20000;

        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int SendMessageW(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern bool ReleaseCapture();
    }
}
