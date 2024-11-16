using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cyberhack
{
    public partial class Form1 : Form
    {
        // Constants for hotkey ID
        private const int HOTKEY_ID = 1;
        private const int MOD_NONE = 0x0000;
        private const int VK_F2 = 0x71;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, VK_F2);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312) // WM_HOTKEY message
            {
                if (m.WParam.ToInt32() == HOTKEY_ID)
                {
                    // Action to perform when F2 is pressed
                    Form1 newForm = new Form1();
                    newForm.Show();
                    newForm.WindowState = FormWindowState.Normal;
                }
            }
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, HOTKEY_ID);
        }

        private void RegisterAppInStartup()
        {
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("MyApp", Application.ExecutablePath);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterAppInStartup();
        }
    }
}