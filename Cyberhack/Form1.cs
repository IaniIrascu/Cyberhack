using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Apis.Translate.v2.Data;

namespace Cyberhack;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using static Cyberhack.KeyWordFinder;
using Google.Apis.Auth.OAuth2;

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
    private void Form1_KeyDown(object sender, KeyEventArgs e) 
    {
        if (e.KeyCode == Keys.Enter)
        {
            textBox2.Focus();
            button1.Focus();
            button1_Click(sender, e);
        }
    }
    
    private static UserCredential Login;
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
        WindowsSettingsBrightnessController.Set(100);
        string input = textBox2.Text.ToLower();
        // if(e.KeyCode==Keys.Enter)
        //     buttonSearch_Click(sender,e);
            // preiau textul din TextBox.

        // creez instanta si caut substringurile.
        KeyWordFinder finder = new KeyWordFinder();
        
        List<string> words = ["whatsapp", "desktop", "instagram", "chrome", "settings", "setting", "set", "change", "background", "word", "excel", "powerpoint", "gallery", "brightness", "files", "pictures", "documents"];

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
            }
            
        }
        else if (keyword == "desktop")
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
}