using Microsoft.Win32;

namespace Cyberhack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AddApplicationToStartup();
        }

        private void AddApplicationToStartup()
        {
            string appName = "MyApp";
            string appPath = Application.ExecutablePath;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue(appName, appPath);
        }
    }
}