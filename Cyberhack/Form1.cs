using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Apis.Translate.v2.Data;
using IronPython.Modules;

namespace Cyberhack;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using static Cyberhack.KeyWordFinder;
using Google.Apis.Auth.OAuth2;
using System.Speech.Synthesis;
using System.Threading;

/*namespace GoogleTranslate
{ 
    public class GoogleTranslate
    {
        private readonly UserCredential _credential;
        public GoogleTranslate(UserCredential credential)
        {
            _credential = credential;
        }

        public string TranslateText(string text, string inputLanguage, string targetLanguage)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(inputLanguage));
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(targetLanguage));

            using (var translateService = new TranslateService(new BaseClientService.Initializer()
                       { HttpClientInitializer = _credential }))
            {
                var translateRequest = translateService.Translations.Translate(new TranslateTextRequest()
                {
                    Q = new List<string> { text },
                    Source = inputLanguage,
                    Target = targetLanguage,
                    Format = "text"
                });
                
                var responce = translateRequest.Execute();
                return responce.Translations.First().TranslatedText;
            }
        }
    }
}
*/
public partial class Form1 : Form
{
    private String _keyword = null;
    private bool buttonClicked = false;
    private System.Windows.Forms.Timer waitTimer;
    private bool askedQuestion = false;
    SpeechSynthesizer synthesizer = new SpeechSynthesizer();
    
    private void CustomizeUI()
    {
        // Set modern font
        Font modernFont = new Font("Segoe UI", 10, FontStyle.Regular);
        // Style Button1 (Brighter)
        
        
        label1.Font = modernFont;
        label1.BackColor = Color.Black;
        label1.FlatStyle = FlatStyle.Flat;
        
        label1.ForeColor = Color.White;
        label1.TextAlign = ContentAlignment.MiddleCenter;
        label1.Text = "Welcome to my Config";
        
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

        // Style TextBox1 (Input)
        textBox1.Font = modernFont;
        textBox1.BackColor = Color.WhiteSmoke;
        textBox1.ForeColor = Color.Gray;
        textBox1.Text = "Type your query here...";
        textBox1.GotFocus += RemovePlaceholderText;
        textBox1.LostFocus += AddPlaceholderText;
        
        button1.Anchor = AnchorStyles.None;
        button2.Anchor = AnchorStyles.None;
        button3.Anchor = AnchorStyles.None;
        textBox1.Anchor = AnchorStyles.None;
        label1.Anchor = AnchorStyles.None;
    }
    
    /*
     private void trackBar1_Scroll(object sender, EventArgs e)
    {
    }

    private void button2_Click(object sender, EventArgs e)
    {
    
    } 
     */
    
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
    
    private static UserCredential Login;
    public Form1()
    {
        InitializeComponent();
        CustomizeUI();
    }

    private void textBox2_TextChanged(object sender, KeyEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void bindingSource1_CurrentChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        synthesizer.Volume = 100;
        //string workingDirectory = Environment.CurrentDirectory;
        //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        //Console.WriteLine(projectDirectory);
        //System.Media.SoundPlayer player = new System.Media.SoundPlayer(projectDirectory + "\\file_example_WAV_1MG.wav");
        //player.Play();
        WindowsSettingsBrightnessController.Set(100);
        string input = textBox1.Text.ToLower();
        // if(e.KeyCode==Keys.Enter)
        //     buttonSearch_Click(sender,e);
            // preiau textul din TextBox.

        // creez instanta si caut substringurile.
        KeyWordFinder finder = new KeyWordFinder();
        
        List<string> words = ["settings", "desktop", "brightness", "brighter", "bright", "dimmer", "sound", "speaker"];
        
        // Cautare keyword principal
        List<string> brightnessKeywords = ["brightness", "brighter", "dimmer", "bright"];
        String keyword = finder.FindSubstring(input.ToLower(), brightnessKeywords);
        if (keyword == "brightness" || keyword == "brighter" || keyword == "dimmer" || keyword == "bright")
        {
            _keyword = keyword;
            askedQuestion = true;
            synthesizer.Speak("Would you like to change the brightness?");
            waitTimer = new System.Windows.Forms.Timer();
            waitTimer.Interval = 100;  // Check every 100 milliseconds
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
            waitTimer.Interval = 100;  // Check every 100 milliseconds
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
            waitTimer.Interval = 100;  // Check every 100 milliseconds
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
            waitTimer.Interval = 100;  // Check every 100 milliseconds
            waitTimer.Tick += WaitForButtonClick;
        }
        /*
         * List<String> listaSetari = ["display", "keyboard", "recovery",
                "taskbar", "nightlight", "about", "sound", "apps-volume",
                "printers"];
         */
        
        List<string> settingsKeywords = ["settings", "setting", "set", "change", "desktop", "search"];
        keyword = finder.FindSubstring(input.ToLower(), settingsKeywords);
        if (keyword == "settings" || keyword == "setting" || keyword == "set" || keyword == "change")
        {
            synthesizer.Speak("Try to be more specific about what you want to change. For ex: too bright to change the brightness");
        }
        else if (keyword == "desktop" || keyword == "search")
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
        }
        
        // we have the keyword that the user type.
        // and now we apply the handlefunction for that keyword, keyword.
    }

    private void button1_Click(object sender, EventArgs e)
    {  
        WindowsSettingsBrightnessController.Set(WindowsSettingsBrightnessController.Get() + 10);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        WindowsSettingsBrightnessController.Set(WindowsSettingsBrightnessController.Get() - 10);
    }

    private void button4_Click(object sender, EventArgs e)
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

    private void button5_Click(object sender, EventArgs e)
    {
        if (askedQuestion == true)
        {
            if (_keyword == "brightness" || _keyword == "brighter" || _keyword == "dimmer" || _keyword == "bright")
            {
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
                synthesizer.Speak("Choose the language you want from this menu. If you don't have it use the plus button to download the pack for it.");
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

    private void StartWaiting()
    {
        waitTimer.Start();
    }

    private void WaitForButtonClick(object sender, EventArgs e)
    {
        if (buttonClicked)
        {
            waitTimer.Stop();
        }
    }
    
    private void label1_Click(object sender, EventArgs e)
    {
        
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
       
    }
}