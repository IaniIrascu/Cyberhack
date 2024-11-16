using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cyberhack
{
    static class NotifyIconApp
    {
        private const int HOTKEY_ID = 1;
        private const int MOD_NONE = 0x0000;
        private const int VK_F2 = 0x71;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.Visible = true;
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, (s, e) => Application.Exit());

            Form hotkeyForm = new Form();
            hotkeyForm.Load += (s, e) => RegisterHotKey(hotkeyForm.Handle, HOTKEY_ID, MOD_NONE, VK_F2);
            hotkeyForm.FormClosing += (s, e) => UnregisterHotKey(hotkeyForm.Handle, HOTKEY_ID);
            hotkeyForm.ShowInTaskbar = false;
            hotkeyForm.WindowState = FormWindowState.Minimized;
            hotkeyForm.Show();

            Application.AddMessageFilter(new HotkeyMessageFilter(() =>
            {
                // Action to perform when F2 is pressed
                Form1 form1 = new Form1();
                form1.Show();
                form1.WindowState = FormWindowState.Normal;
            }));

            Application.Run();
        }

        private class HotkeyMessageFilter : IMessageFilter
        {
            private readonly Action _action;

            public HotkeyMessageFilter(Action action)
            {
                _action = action;
            }

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x0312 && m.WParam.ToInt32() == HOTKEY_ID)
                {
                    _action();
                    return true;
                }
                return false;
            }
        }
    }
}
