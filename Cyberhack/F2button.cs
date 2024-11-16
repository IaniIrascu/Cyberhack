using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cyberhack
{
    public class F2button : IMessageFilter
    {
        // Constants for hotkey ID
        private const int HOTKEY_ID = 1;
        private const int MOD_NONE = 0x0000;
        private const int VK_F2 = 0x71;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private IntPtr hWnd;
        private Action onF2Pressed;

        public F2button(IntPtr handle, Action action)
        {
            hWnd = handle;
            onF2Pressed = action;
            RegisterHotKey(hWnd, HOTKEY_ID, MOD_NONE, VK_F2);
            Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == HOTKEY_ID)
            {
                onF2Pressed?.Invoke();
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            UnregisterHotKey(hWnd, HOTKEY_ID);
            Application.RemoveMessageFilter(this);
        }
    }
}