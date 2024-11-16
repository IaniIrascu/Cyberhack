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

    private void bindingSource1_CurrentChanged(object sender, EventArgs e)
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
        
        List<string> words = ["whatsapp", "instagram", "chrome", "settings", "background", "word", "excel", "powerpoint", "gallery", "brightness", "files", "pictures", "documents"];

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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String[] files = 
            keyword = finder.FindSubstring(input, words);
        }
        
        // we have the keyword that the user type.
        // and now we apply the handlefunction for that keyword, keyword.
    }
}