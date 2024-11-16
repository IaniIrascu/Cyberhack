using System.Runtime.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using static Cyberhack.UniversalInstallation;

namespace Cyberhack;

public class Installer
{
    private String program;
    public Installer(String program)
    {
        this.program = program;
    }

    public void Install() {
        if (this.program == "chrome" || this.program == "google") {
            const string chromeInstallerUrl = "https://dl.google.com/chrome/install/googlechromestandaloneenterprise64.msi";
            const string installerPath = @"C:\Temp\GoogleChromeInstaller.msi";

            try
            {
                
                Console.WriteLine("Downloading Google Chrome installer...");
                using (WebClient client = new WebClient())
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(installerPath));
                    client.DownloadFile(chromeInstallerUrl, installerPath);
                }
                Console.WriteLine("Download completed!");

                Console.WriteLine("Installing Google Chrome...");
                InstallApplication(installerPath, "/quiet /norestart");
                Console.WriteLine("Google Chrome installation completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
    
}