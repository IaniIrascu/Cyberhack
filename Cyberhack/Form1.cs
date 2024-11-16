namespace Cyberhack;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using static Cyberhack.KeyWordFinder;
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void textBox2_TextChanged(object sender, KeyEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        string input = textBox2.Text;
        // if(e.KeyCode==Keys.Enter)
        //     buttonSearch_Click(sender,e);
            // preiau textul din TextBox.

        // creez instanta si caut substringurile.
        KeyWordFinder finder = new KeyWordFinder();
        
        List<string> words = ["whatsapp", "desktop", "instagram", "chrome", "settings", "background", "word", "excel", "powerpoint", "gallery", "brightness", "files", "pictures", "documents", "mail"];

        String keyword = finder.FindSubstring(input, words);
        
        // Cautare keyword principal

        if (keyword == "settings")
        {
            List<String> listaSetari = ["display", "camera", "keyboard", "language", "recovery",
                "taskbar", "nightlight", "about", "sound", "apps-volume",
                "printers"];

            String keywordSettings = finder.FindSubstring(input, listaSetari);
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
            //keyword = finder.FindSubstring(input, words);
        }

        if (keyword == "mail")
        {
            // Lansez aplicatia de mail.
            Process processMail = new Process();
            processMail.StartInfo.FileName = "mailto:";
            // Fara aceasta linie nu mi ar fi recunoscut pathul.
            processMail.StartInfo.UseShellExecute = true;
            processMail.Start();
        }
        // we have the keyword that the user type.
        // and now we apply the handlefunction for that keyword, keyword.
    }
}