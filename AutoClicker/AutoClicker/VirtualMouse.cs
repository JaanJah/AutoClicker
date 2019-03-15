using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoClicker
{
    public static class VirtualMouse
    {
        [DllImport("user32.dll")]
        //static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        static extern void mouse_event(int dwFlags, Point coords);
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [DllImport("user32.dll")]
        private static extern long SetCursorPos(int x, int y);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public int X;
            public int Y;
        };

        public static void MoveTo(int X, int Y)
        {
            Win32Point point = new Win32Point();
            point.X = X;
            point.Y = Y;
            SetCursorPos(point.X, point.Y);
        }

        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        public static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, GetMousePosition());
            mouse_event(MOUSEEVENTF_LEFTUP, GetMousePosition());
        }

        public static void RightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, GetMousePosition());
            mouse_event(MOUSEEVENTF_RIGHTUP, GetMousePosition());
        }

        public static void MiddleClick()
        {
            mouse_event(MOUSEEVENTF_MIDDLEDOWN, GetMousePosition());
            mouse_event(MOUSEEVENTF_MIDDLEUP, GetMousePosition());
        }

    }
}
