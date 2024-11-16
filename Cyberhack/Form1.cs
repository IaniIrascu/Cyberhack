namespace Cyberhack
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.IO;
    using static Cyberhack.KeyWordFinder;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox2.Text;
            KeyWordFinder finder = new KeyWordFinder();

            List<string> words = new List<string>
            {
                "whatsapp", "desktop", "instagram", "chrome", "settings", "background",
                "word", "excel", "powerpoint", "gallery", "brightness", "files",
                "pictures", "documents"
            };

            string keyword = finder.FindSubstring(input, words);

            if (keyword == "settings")
            {
                List<string> listaSetari = new List<string>
                {
                    "display", "camera", "keyboard", "language", "recovery",
                    "taskbar", "nightlight", "about", "sound", "apps-volume",
                    "printers"
                };

                string keywordSettings = finder.FindSubstring(input, listaSetari);
                if (keywordSettings != null)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "ms-settings:" + keywordSettings;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
                else
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "ms-settings:";
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
            }
            else if (keyword == "desktop")
            {
                IEnumerable<FileInfo> list = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).GetFiles()
                    .Concat(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)).GetFiles());

                foreach (var file in list)
                {
                    if (input.Contains(file.Name))
                    {
                        Console.WriteLine(file.Name);
                    }
                }
            }
        }
    }
}
