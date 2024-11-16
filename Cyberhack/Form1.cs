using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using static Cyberhack.KeyWordFinder;

namespace Cyberhack;

public partial class Form1 : Form
{
        private void CustomizeUI()
        {
            // Set modern font
            Font modernFont = new Font("Segoe UI", 10, FontStyle.Regular);
            // Style Button1 (Brighter)
            
            
            
            button1.Font = modernFont;
            button1.BackColor = Color.LightBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.ForeColor = Color.White;
            button1.TextAlign = ContentAlignment.MiddleCenter;
            button1.Text = "Brighter ☀";

            // Style Button2 (Dimmer)
            button2.Font = modernFont;
            button2.BackColor = Color.CornflowerBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.ForeColor = Color.White;
            button2.TextAlign = ContentAlignment.MiddleCenter;
            button2.Text = "Dimmer 🌙";

            // Style Button3 (Search)
            button3.Font = modernFont;
            button3.BackColor = Color.MediumSlateBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.ForeColor = Color.White;
            button3.TextAlign = ContentAlignment.MiddleCenter;
            button3.Text = "Search 🔍";
            
            button4.Font = modernFont;
            button4.BackColor = Color.Red;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.ForeColor = Color.White;
            button4.TextAlign = ContentAlignment.MiddleCenter;
            button4.Text = "No ❌";
            
            button5.Font = modernFont;
            button5.BackColor = Color.YellowGreen;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.ForeColor = Color.White;
            button5.TextAlign = ContentAlignment.MiddleCenter;
            button5.Text = "Yes ✅";
            

            // Style TextBox1 (Input)
            textBox1.Font = modernFont;
            textBox1.BackColor = Color.WhiteSmoke;
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = "Welcome to myConfig...Type your query here...";
            textBox1.GotFocus += RemovePlaceholderText;
            textBox1.LostFocus += AddPlaceholderText;
            
            button1.Anchor = AnchorStyles.None;
            button2.Anchor = AnchorStyles.None;
            button3.Anchor = AnchorStyles.None;
            textBox1.Anchor = AnchorStyles.None;
            button4.Anchor = AnchorStyles.None;
            button5.Anchor = AnchorStyles.None;
            
        }
        
        // Placeholder handling for the text box
        private void RemovePlaceholderText(object sender, EventArgs e)
        {
            if (textBox1.Text == "Welcome to myConfig...Type your query here...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void AddPlaceholderText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Welcome to myConfig...Type your query here... ";
                textBox1.ForeColor = Color.Gray;
            }
        }
    
    private void Form1_KeyDown(object sender, KeyEventArgs e) 
    {
        if (e.KeyCode == Keys.Enter)
        {
            textBox1.Focus();
            button1.Focus();
            button1_Click(sender, e);
        }
    }
    
    public Form1()
    {
        InitializeComponent();
        CustomizeUI();
    }

    private void textBox2_TextChanged(object sender, KeyEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
    

    private void button3_Click(object sender, EventArgs e)
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Console.WriteLine(projectDirectory);
        WindowsSettingsBrightnessController.Set(100);
        
        string input = textBox1.Text.ToLower();
        // if(e.KeyCode==Keys.Enter)
        //     buttonSearch_Click(sender,e);
        // preiau textul din TextBox.

        // creez instanta si caut substringurile.
        KeyWordFinder finder = new KeyWordFinder();
        
        List<string> words = ["display", "camera", "keyboard", "language", "recovery",
            "taskbar", "nightlight", "about", "sound", "apps-volume",
            "printers"];

        String keyword = finder.FindSubstring(input.ToLower(), words);
        
        // Cautare keyword principal
        
        
        if (keyword == "settings" || keyword == "setting" || keyword == "set" || keyword == "change")
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
                
                // Creeaza un label
            }

            return;
        }
        if (keyword == "desktop")
        {
            IEnumerable<FileInfo> list = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).GetFiles()
                .Concat(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)).GetFiles()).Distinct();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            Console.WriteLine(input);
            foreach (var file in list)
            {
                String filename = file.Name.ToLower();
                String nameWithoutExt = Path.GetFileNameWithoutExtension(filename);
                try
                {
                    if (input.Contains("\"" + filename + "\""))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = desktopPath + "\\" + file.Name;
                        process.StartInfo.UseShellExecute = true;
                        process.Start();
                        break;
                    }
                    else if (input.Contains("\"" + nameWithoutExt + "\"") &&
                             nameWithoutExt == Path.GetFileNameWithoutExtension(file.Name).ToLower())
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "\"" + desktopPath + "\\" + file.Name + "\"";
                        Console.WriteLine(process.StartInfo.FileName);
                        process.StartInfo.UseShellExecute = true;
                        process.Start();
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the error if needed
                    Console.WriteLine($"Error starting process for file {file.Name}");
                }
            }

            return;
        }

        if (keyword == "brightness")
        {
            
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
    }

    private void button1_Click(object sender, EventArgs e)
    {  
        WindowsSettingsBrightnessController.Set(WindowsSettingsBrightnessController.Get() + 10);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        WindowsSettingsBrightnessController.Set(WindowsSettingsBrightnessController.Get() - 10);
    }

    private void label1_Click(object sender, EventArgs e)
    {
        
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
       
    }
}