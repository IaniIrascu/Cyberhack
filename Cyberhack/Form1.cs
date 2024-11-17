using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using static Cyberhack.KeyWordFinder;
using System.Speech.Synthesis;
using System.Threading;

namespace Cyberhack;

using static System.Windows.Forms.Timer;
using System.Runtime.InteropServices;

using static WindowsSettingsBrightnessController;

public partial class Form1 : Form
{

    private System.Windows.Forms.Timer batteryTimer;

    private void batteryTimer_Tick(object? sender, EventArgs e)
    {
        CheckBatteryStatus();
    }

    private void StartBatteryMonitor()
    {
        batteryTimer = new System.Windows.Forms.Timer();
        batteryTimer.Interval = 6000;
        // la interval de un minut imi verifica starea bateriei.
        batteryTimer.Tick += batteryTimer_Tick;
        batteryTimer.Start();
    }

    private void CheckBatteryStatus()
    {
        var powerStatus = SystemInformation.PowerStatus;
        float nivelBaterie = powerStatus.BatteryLifePercent * 100;
        int ok = 0;
        if (nivelBaterie <= 20 && ok == 0)
        {
            // daca bateria ar fi mai mica decat 20 la suta, atunci 
            // s-ar activa modul salveaza baterie.
            WindowsSettingsBrightnessController.Set(30);
            ActiveazaPowerSaverMode();
            ok = 1;
        }

        if (nivelBaterie >= 21 && ok == 1)
        {
            ok = 0;
        }
    }

    public void ActiveazaPowerSaverMode()
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        speechSynthesizer.Speak("Pay attention! The battery is below twenty percent!");
    }

    private String _keyword = null;
    private bool buttonClicked = false;
    private System.Windows.Forms.Timer waitTimer;
    private bool askedQuestion = false;
    SpeechSynthesizer synthesizer = new SpeechSynthesizer();

    private void CustomizeUI()
    {
        // Set modern font
        Font modernFont = new Font("Georgia", 12, FontStyle.Regular);

        // Style Button1 (Brighter)
        button1.Font = modernFont;
        button1.FlatStyle = FlatStyle.Flat;
        button1.BackColor = Color.FromArgb(238, 238, 238);
        button1.FlatAppearance.BorderSize = 0;
        button1.ForeColor = Color.White;
        button1.TextAlign = ContentAlignment.MiddleCenter;
        button1.Text = "Brighter ☀";

        // Style Button2 (Dimmer)
        button2.Font = modernFont;
        button2.FlatStyle = FlatStyle.Flat;
        button1.BackColor = Color.FromArgb(57, 62, 70);
        button2.FlatAppearance.BorderSize = 0;
        button2.ForeColor = Color.White;
        button2.TextAlign = ContentAlignment.MiddleCenter;
        button2.Text = "Dimmer 🌙";

        // Style Button3 (Search)
        button3.Font = modernFont;
        button3.BackColor = Color.FromArgb(0, 173, 181);
        button3.FlatStyle = FlatStyle.Flat;
        button3.FlatAppearance.BorderSize = 0;
        button3.ForeColor = Color.White;
        button3.TextAlign = ContentAlignment.MiddleCenter;
        button3.Text = "Search 🔍";

        button4.Font = modernFont;
        button4.BackColor = Color.FromArgb(117, 14, 33);
        button4.FlatStyle = FlatStyle.Flat;
        button4.FlatAppearance.BorderSize = 0;
        button4.ForeColor = Color.White;
        button4.TextAlign = ContentAlignment.MiddleCenter;
        button4.Text = "No ❌";

        button5.Font = modernFont;
        button5.BackColor = Color.FromArgb(0, 91, 65);
        button5.FlatStyle = FlatStyle.Flat;
        button5.FlatAppearance.BorderSize = 0;
        button5.ForeColor = Color.White;
        button5.TextAlign = ContentAlignment.MiddleCenter;
        button5.Text = "Yes ✅";


        // Style TextBox1 (Input)
        textBox1.Font = modernFont;
        textBox1.BackColor = Color.FromArgb(238, 238, 238);
        textBox1.ForeColor = Color.FromArgb(57, 62, 70);
        textBox1.Text = "Type your query here...";
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
        if (textBox1.Text == "Type your query here...")
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }
    }

    private void AddPlaceholderText(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text))
        {
            textBox1.Text = "Type your query here... ";
            textBox1.ForeColor = Color.Gray;
        }
    }



    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            textBox1.Focus();
            button3.Focus();
            button3_Click(sender, e);
        }
    }

    public Form1()
    {
        InitializeComponent();
        CustomizeUI();
        StartBatteryMonitor();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        WindowsSettingsBrightnessController.Set(WindowsSettingsBrightnessController.Get() + 10);
    }

    private void button2_Click(object sender, EventArgs e)
    {
        WindowsSettingsBrightnessController.Set(WindowsSettingsBrightnessController.Get() - 10);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        synthesizer.Volume = 100;
        string input = textBox1.Text.ToLower();

        // creez instanta si caut substringurile.
        KeyWordFinder finder = new KeyWordFinder();

        List<string> words =
        [
            "whatsapp", "facebook", "desktop", "instagram", "chrome", "settings",
            "setting", "set", "change", "background", "word", "excel", "powerpoint", "gallery",
            "brightness", "files", "pictures", "documents", "spotify", "music", "internet",
            "youtube", "zoom", "chatgpt", "bright", "search"
        ];
        

        // Cautare keyword principal
        List<string> brightnessKeywords = ["brightness", "brighter", "dimmer", "bright"];
        string keyword = finder.FindSubstring(input.ToLower(), brightnessKeywords);
        if (keyword == "brightness" || keyword == "brighter" || keyword == "dimmer" || keyword == "bright")
        {
            _keyword = keyword;
            askedQuestion = true;
            synthesizer.Speak("Would you like to change the brightness?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> soundKeywords = ["sound", "loud", "quiet", "volume"];
        keyword = finder.FindSubstring(input.ToLower(), soundKeywords);
        if (keyword == "sound" || keyword == "loud" || keyword == "quiet" || keyword == "volume")
        {
            _keyword = keyword;
            askedQuestion = true;
            synthesizer.Speak("Would you like to change the sound?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> languageKeywords = ["keyboard", "language"];
        keyword = finder.FindSubstring(input.ToLower(), languageKeywords);
        if (keyword == "keyboard" || keyword == "language")
        {
            _keyword = keyword;
            askedQuestion = true;
            synthesizer.Speak("Would you like to change the language?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> aboutKeywords = ["about", "details", "pc", "laptop", "windows"];
        keyword = finder.FindSubstring(input.ToLower(), aboutKeywords);
        if (keyword == "about" || keyword == "pc" || keyword == "laptop" || keyword == "windows")
        {
            _keyword = keyword;
            askedQuestion = true;
            synthesizer.Speak("Would you like to see details about this computer?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> settingsKeywords = ["settings", "setting", "set", "change", "desktop", "search"];
        keyword = finder.FindSubstring(input.ToLower(), settingsKeywords);
        if (keyword == "settings" || keyword == "setting" || keyword == "set" || keyword == "change")
        {
            synthesizer.Speak(
                "Try to be more specific about what you want to change. For ex: too bright to change the brightness");
            return;
        }
        
        keyword = finder.FindSubstring(input.ToLower(), words);
        if (keyword == "desktop" || keyword == "search")
        {
            IEnumerable<FileInfo> list =
                new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).GetFiles()
                    .Concat(new DirectoryInfo(
                        Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)).GetFiles())
                    .Distinct();
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

        if (keyword == "mail")
        {
            // Lansez aplicatia de mail.
            Process processMail = new Process();
            processMail.StartInfo.FileName = "mailto:";
            // Fara aceasta linie nu mi ar fi recunoscut pathul.
            processMail.StartInfo.UseShellExecute = true;
            processMail.Start();
            return;
        }

        if (keyword == "chrome" || keyword == "google" || keyword == "internet")
        {
            const string appPath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            try
            {
                Process processChrome = new Process();
                processChrome.StartInfo.FileName = appPath;
                processChrome.StartInfo.UseShellExecute = true;
                processChrome.Start();
            }
            catch
            {
                Console.WriteLine($"Error starting chrome process");
                Installer chrome = new Installer("chrome");
                chrome.Install();
                try
                {
                    Process processChrome = new Process();
                    processChrome.StartInfo.FileName = appPath;
                    processChrome.StartInfo.UseShellExecute = true;
                    processChrome.Start();
                }
                catch
                {
                    Console.WriteLine($"Error starting chrome process");
                }
            }
        }
        if (keyword == "facebook")
        {
            const string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            const string facebookUrl = "https://www.facebook.com";
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = chromePath;
                process.StartInfo.Arguments = facebookUrl;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch
            {
                Installer chrome = new Installer("chrome");
                chrome.Install();
                Process process = new Process();
                process.StartInfo.FileName = chromePath;
                process.StartInfo.Arguments = facebookUrl;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }

        if (keyword == "instagram" || keyword == "insta")
        {
            const string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            const string instaUrl = "https://www.instagram.com";
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = chromePath;
                process.StartInfo.Arguments = instaUrl;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch
            {
                Installer chrome = new Installer("chrome");
                chrome.Install();
                Process process = new Process();
                process.StartInfo.FileName = chromePath;
                process.StartInfo.Arguments = instaUrl;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }

            return;
        }

        if (keyword == "youtube")
        {
            const string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            const string ytUrl = "https://www.youtube.com";
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = chromePath;
                process.StartInfo.Arguments = ytUrl;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch
            {
                Installer chrome = new Installer("chrome");
                chrome.Install();
                Process process = new Process();
                process.StartInfo.FileName = chromePath;
                process.StartInfo.Arguments = ytUrl;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }

            return;
        }

        if (keyword == "spotify")
        {
            string spotifyPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"Spotify\spotify.exe");
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = spotifyPath;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch
            {
                Installer spotify = new Installer("spotify");
                spotify.Install();
                Process process = new Process();
                process.StartInfo.FileName = spotifyPath;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }

        if (keyword == "zoom")
        {
            string zoomPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"Zoom\bin\Zoom.exe");
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = zoomPath;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch
            {
                Installer spotify = new Installer("zoom");
                spotify.Install();
                Process process = new Process();
                process.StartInfo.FileName = zoomPath;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }

        if (keyword == "chatgpt")
        {
            const string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            const string chatUrl = "https://www.chatgpt.com";
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = chromePath;
                process.StartInfo.Arguments = chatUrl;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            catch
            {
                Installer chrome = new Installer("chrome");
                chrome.Install();
                Process process = new Process();
                process.StartInfo.FileName = chromePath;
                process.StartInfo.Arguments = chatUrl;
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
            return;
        }
    }
    
        
    void button4_Click(object sender, EventArgs e)
    {
        if (askedQuestion == true)
        {
            synthesizer.Speak("Delete the keyword and try again.");
            // Listam
            buttonClicked = true;
            waitTimer.Stop(); // Stop the timer once the button is clicked
            askedQuestion = false;
        }
    }
        
    void button5_Click(object sender, EventArgs e)
    {
        if (askedQuestion == true)
        {
            Console.WriteLine("intra");
            if (_keyword == "brightness" || _keyword == "brighter" || _keyword == "dimmer" || _keyword == "bright")
            {
                Console.WriteLine(_keyword);
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:display";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = 100;
                synthesizer.Speak("In order to change the brightness use the slider in the top of the window.");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
            }

            if (_keyword == "sound" || _keyword == "loud" || _keyword == "quiet" || _keyword == "volume")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:sound";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = 100;
                synthesizer.Speak("In order to change the sound use the slider called volume.");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
            }

            if (_keyword == "keyboard" || _keyword == "language")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:keyboard";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = 100;
                synthesizer.Speak(
                    "Choose the language you want from this menu. If you don't have it use the plus button to download the pack for it.");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
            }

            if (_keyword == "about" || _keyword == "pc" || _keyword == "laptop" || _keyword == "windows")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:about";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = 100;
                synthesizer.Speak("You can see the details about pc here");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
            }

            askedQuestion = false;
        }
    }

    void StartWaiting()
    {
        waitTimer.Start();
    }

    void WaitForButtonClick(object sender, EventArgs e)
    {
        if (buttonClicked)
        {
            waitTimer.Stop();
        }
    }

    void label1_Click(object sender, EventArgs e)
    {

    }
}
