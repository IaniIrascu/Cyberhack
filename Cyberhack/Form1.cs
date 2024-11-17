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
    private Boolean isSpeaking = false;
    // Partea de vorbire conform track-barului
    // Metoda pentru a vorbi cu ajustarea dinamică a volumului
    private void StartSpeakingWithVolumeChange(string text)
    {
        // impart textul in cuvinte.
        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> sentenceParts = new List<string>();

        // creez fragmente de text mai mici.
        foreach (var word in words)
        {
            string currentFragment = string.Join(" ", sentenceParts) + " " + word;
            sentenceParts.Add(currentFragment);

            // După fiecare cuvant, setez volumul si ii spun ,, robotului" as vorbeasca.
            synthesizer.Volume = trackBar1.Value;
            synthesizer.SpeakAsync(currentFragment);
        }
    }

    // Eveniment care semnalează finalizarea vorbirii
    private void Synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
    {
        isSpeaking = false; // Vorbirea s-a încheiat
    }
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
    private String _input = null;

    private bool buttonClicked = false;
    private System.Windows.Forms.Timer waitTimer;
    private bool askedQuestion = false;
    SpeechSynthesizer synthesizer = new SpeechSynthesizer();

    private void CustomizeUI()
    {
        // Set modern font
        Font modernFont = new Font("Georgia", 12, FontStyle.Regular);
        synthesizer.Speak(@"Hello" + Environment.UserName + ". Welcome to ConfigAssist!");

        // Style Button1 (Brighter)
        button1.Font = modernFont;
        button1.FlatStyle = FlatStyle.Flat;
        button1.FlatAppearance.BorderSize = 0;
        button1.TextAlign = ContentAlignment.MiddleCenter;
        button1.Text = "Brighter ☀";

        // Style Button2 (Dimmer)
        button2.Font = modernFont;
        button2.FlatStyle = FlatStyle.Flat;
        button2.FlatAppearance.BorderSize = 0;
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
        label1.Font = modernFont;
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
        trackBar1.Anchor = AnchorStyles.None;
        label1.Anchor = AnchorStyles.None;
        pictureBox1.Anchor = AnchorStyles.None;
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
    
    
    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true; // Prevent TextBox from handling Enter
            button3.PerformClick();   // Simulate Button3 click
        }
    }

    public Form1()
    {
        InitializeComponent();
        CustomizeUI();
        StartBatteryMonitor();
        this.KeyPreview = true; 
        textBox1.KeyDown += textBox1_KeyDown; // Attach KeyDown event to TextBo
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
        synthesizer.Volume = trackBar1.Value * 10;
        string input = textBox1.Text.ToLower();

        // creez instanta si caut substringurile.
        KeyWordFinder finder = new KeyWordFinder();

        // Cautare keyword principal
        List<string> brightnessKeywords = ["dim", "brigh"];
        string keyword = finder.FindSubstring(input.ToLower(), brightnessKeywords);
        if (keyword != null)
        {
            _keyword = "brightness";
            askedQuestion = true;
            synthesizer.Speak("Would you like to change the brightness?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> soundKeywords = ["soun", "loud", "quie", "volu"];
        keyword = finder.FindSubstring(input.ToLower(), soundKeywords);
        if (keyword != null)
        {
            _keyword = "volume";
            askedQuestion = true;
            synthesizer.Speak("Would you like to change the volume?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> languageKeywords = ["keyb", "lang"];
        keyword = finder.FindSubstring(input.ToLower(), languageKeywords);
        if (keyword != null)
        {
            _keyword = "keyboard";
            askedQuestion = true;
            synthesizer.Speak("Would you like to change the language?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> aboutKeywords = ["abou", "detai", "pc", "lapto", "windo"];
        keyword = finder.FindSubstring(input.ToLower(), aboutKeywords);
        if (keyword != null)
        {
            _keyword = "about";
            askedQuestion = true;
            synthesizer.Speak("Would you like to see details about this computer?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }
        
        //personalization
        List <string> aboutPersonalizationKeywords = ["them", "personal"];
        keyword = finder.FindSubstring(input.ToLower(), aboutPersonalizationKeywords);
        if (keyword != null)
        {
            _keyword = keyword;
            askedQuestion = true;
            synthesizer.Speak("Would you like to see ways to personalize this computer?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List <string> aboutApps = ["apps", "appl"];
        keyword = finder.FindSubstring(input.ToLower(), aboutApps);
        if (keyword != null)
        {
            _keyword = "apps";
            askedQuestion = true;
            synthesizer.Speak("Would you like to see the apps from this computer?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }
        List <string> aboutinternet = ["internet", "net", "wifi"];
        keyword = finder.FindSubstring(input.ToLower(), aboutinternet);
        if (keyword != null)  
        {
            _keyword = "internet";
            askedQuestion = true;
            synthesizer.Speak("Would you like to see the network and Wi-Fi settings?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }
        //bluetooth
        List <string> aboutbluetooth = ["blueto"];
        keyword = finder.FindSubstring(input.ToLower(), aboutbluetooth);
        if (keyword != null)  
        {
            _keyword = "bluetooth";
            askedQuestion = true;
            synthesizer.Speak("Would you like to see the bluetooth settings?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }
        //print
        List <string> aboutprint = ["print"];
        keyword = finder.FindSubstring(input.ToLower(), aboutprint);
        if (keyword == "print")  
        {
            _keyword = keyword;
            _input = input;
            askedQuestion = true;
            synthesizer.Speak("Would you like to print this document?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
            
        }

        List<string> settingsKeywords = ["set", "chang", "deskto", "searc"];
        keyword = finder.FindSubstring(input.ToLower(), settingsKeywords);
        if (keyword != null)
        {
            synthesizer.Speak(
                "Try to be more specific about what you want to change. For example: too bright to change the brightness");
            return;
        }
        
        
        List<string> fileKeywords = ["deskt", "fil", "doc"];
        keyword = finder.FindSubstring(input.ToLower(), fileKeywords);
        if (keyword != null)
        {
            IEnumerable<FileInfo> list =
                new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).GetFiles()
                    .Concat(new DirectoryInfo(
                        Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)).GetFiles())
                    .Distinct();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
        
        List<string> mailKeywords = ["mai", "emai", "gmai", "yaho"];
        keyword = finder.FindSubstring(input.ToLower(), mailKeywords);
        if (keyword != null)
        {
            // Lansez aplicatia de mail.
            Process processMail = new Process();
            processMail.StartInfo.FileName = "mailto:";
            // Fara aceasta linie nu mi ar fi recunoscut pathul.
            processMail.StartInfo.UseShellExecute = true;
            processMail.Start();
            return;
        }

        List<string> chromeKeywords = ["chrom", "googl", "inter", "brows", "net"];
        keyword = finder.FindSubstring(input.ToLower(), chromeKeywords);
        if (keyword != null)
        {
            _keyword = "chrome";
            askedQuestion = true;
            synthesizer.Speak("Would you like to use Google Chrome?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> fbKeywords = ["face", "fb"];
        keyword = finder.FindSubstring(input.ToLower(), fbKeywords);
        if (keyword != null)
        {
            _keyword = "facebook";
            askedQuestion = true;
            synthesizer.Speak("Would you like to open Facebook?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }
            
        List<string> instaKeywords = ["insta"];
        keyword = finder.FindSubstring(input.ToLower(), instaKeywords);
        if (keyword != null)
        {
            _keyword = "instagram";
            askedQuestion = true;
            synthesizer.Speak("Would you like to open Instagram?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> ytKeywords = ["yout", "yt"];
        keyword = finder.FindSubstring(input.ToLower(), ytKeywords);
        if (keyword != null)
        {
            _keyword = "youtube";
            askedQuestion = true;
            synthesizer.Speak("Would you like to open Youtube?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }

        List<string> spotKeywords = ["spot", "musi"];
        keyword = finder.FindSubstring(input.ToLower(), spotKeywords);
        if (keyword != null)
        {
            _keyword = "spotify";
            askedQuestion = true;
            synthesizer.Speak("Would you like to open Spotify?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }
        List<string> zoomKeywords = ["zoo"];
        keyword = finder.FindSubstring(input.ToLower(), zoomKeywords);
        if (keyword != null)
        {
            _keyword = "zoom";
            askedQuestion = true;
            synthesizer.Speak("Would you like to open Zoom?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }
        List<string> chatKeywords = ["chat", "gpt"];
        keyword = finder.FindSubstring(input.ToLower(), chatKeywords);
        if (keyword != null)
        {
            _keyword = "chatgpt";
            askedQuestion = true;
            synthesizer.Speak("Would you like to open ChatGPT?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100; // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
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
            if (_keyword == "brightness")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:display";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = trackBar1.Value * 10;
                synthesizer.Speak("In order to change the brightness use the slider in the top of the window.");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
            }

            if (_keyword == "volume")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:sound";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = trackBar1.Value * 10;
                synthesizer.Speak("In order to change the sound use the slider called volume.");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
            }

            if (_keyword == "keyboard")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:keyboard";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = trackBar1.Value * 10;
                synthesizer.Speak(
                    "Choose the language you want from this menu. If you don't have it use the plus button to download the pack for it.");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
                return;
            }

            if (_keyword == "about")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:about";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = trackBar1.Value * 10;
                synthesizer.Speak("You can see the details about the pc here");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
                return;
            }
            if (_keyword == "personalization")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:personalization";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = trackBar1.Value * 10;
                synthesizer.Speak("You can see the details about personalization here");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
                return;
            }
            if (_keyword == "apps")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:apps";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = trackBar1.Value * 10;
                synthesizer.Speak("You can see the details about applications here");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
                return;
            }
            if (_keyword == "internet")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:network";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = trackBar1.Value * 10;
                synthesizer.Speak("You can see the details about internet here");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
                return;
            }
            if (_keyword == "bluetooth")
            {
                Process process = new Process();
                process.StartInfo.FileName = "ms-settings:bluetooth";
                process.StartInfo.UseShellExecute = true;
                process.Start();
                Thread.Sleep(2000);
                synthesizer.Volume = trackBar1.Value * 10;
                synthesizer.Speak("You can see the details about bluetooth here");
                buttonClicked = true;
                waitTimer.Stop(); // Stop the timer once the button is clicked
                return;
            }
            if (_keyword == "chrome")
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
                    synthesizer.Speak("Google Chrome is not installed on this device. I will install it for you!");
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
                return;
            }
            if (_keyword == "facebook")
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
                    synthesizer.Speak("Google Chrome is not installed on this device. I will install it for you!");
                    Installer chrome = new Installer("chrome");
                    chrome.Install();
                    Process process = new Process();
                    process.StartInfo.FileName = chromePath;
                    process.StartInfo.Arguments = facebookUrl;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
                return;
            }
            if (_keyword == "instagram")
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
                    synthesizer.Speak("Google Chrome is not installed on this device. I will install it for you!");
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
            if (_keyword == "youtube")
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
                    synthesizer.Speak("Google Chrome is not installed on this device. I will install it for you!");
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
            if (_keyword == "chatgpt")
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
                    synthesizer.Speak("Google Chrome is not installed on this device. I will install it for you!");
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
            if (_keyword == "zoom")
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
                    synthesizer.Speak("Zoom is not installed on this device. I will install it for you!");
                    Installer spotify = new Installer("zoom");
                    spotify.Install();
                    Process process = new Process();
                    process.StartInfo.FileName = zoomPath;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
                return;
            }
            if (_keyword == "spotify")
            {
                Console.WriteLine("spotify");
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
                    synthesizer.Speak("Zoom is not installed on this device. I will install it for you!");
                    Installer spotify = new Installer("spotify");
                    spotify.Install();
                    Process process = new Process();
                    process.StartInfo.FileName = spotifyPath;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
                return;
            }
            if (_keyword == "print")
            {
                Console.WriteLine(_input);
                IEnumerable<FileInfo> list =
                    new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)).GetFiles()
                        .Concat(new DirectoryInfo(
                            Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)).GetFiles())
                        .Distinct();
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                foreach (var file in list)
                {
                    String filename = file.Name.ToLower();
                    String nameWithoutExt = Path.GetFileNameWithoutExtension(filename);
                    try
                    {
                        if (_input.Contains("\"" + filename + "\"") ||
                            (_input.Contains("\"" + nameWithoutExt + "\"") &&
                             nameWithoutExt == Path.GetFileNameWithoutExtension(file.Name).ToLower()))
                        {
                            string filePath = Path.Combine(desktopPath, file.Name);

                            Process process = new Process();
                            process.StartInfo.FileName = filePath;
                            process.StartInfo.Verb = "print"; // Automatically triggers printing
                            process.StartInfo.UseShellExecute = true;
                            process.Start();

                            synthesizer.Speak($"Printing {file.Name}.");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the error if needed
                        synthesizer.Speak($"Error printing file {file.Name}: {ex.Message}");
                    }
                }
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
    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        synthesizer.Volume = trackBar1.Value * 10;
    }
}