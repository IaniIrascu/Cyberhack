using System.Runtime.CompilerServices;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using static Cyberhack.UniversalInstallation;

namespace Cyberhack;

public class Installer
{
    private string program;
    public Installer(String program)
    {
        this.program = program;
    }
    public void Install() 
    {
        if (this.program == "chrome" || this.program == "google")
        {
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
            return;
        }
        if (this.program == "whatsapp")
        {
            const string whatsappInstallerUrl = "https://get.microsoft.com/installer/download/9NKSQGP7F2NH?cid=website_cta_psi";
            const string installerPath = @"C:\Temp\WhatsappInstaller.exe";
            try
            {
                Console.WriteLine("Downloading WhatsApp installer...");
                using (WebClient client = new WebClient())
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(installerPath));
                    client.DownloadFile(whatsappInstallerUrl, installerPath);
                }
                Console.WriteLine("Download completed!");
                
                Console.WriteLine("Installing application...");
                InstallFromExe(installerPath, "/quiet /norestart");
                Console.WriteLine("Application installation completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Installation failed: {ex.Message}");
            }

            return;
        }
        if (this.program == "spotify")
        {
            const string spotifyInstallerUrl = "https://download.scdn.co/SpotifySetup.exe";
            const string installerPath = @"C:\Temp\SpotifyInstaller.exe";
            try
            {
                Console.WriteLine("Downloading Spotify installer...");
                using (WebClient client = new WebClient())
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(installerPath));
                    client.DownloadFile(spotifyInstallerUrl, installerPath);
                }
                Console.WriteLine("Download completed!");
        
                Console.WriteLine("Installing application...");
                InstallFromExe(installerPath, "/silent /norestart");
                Console.WriteLine("Application installation completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Installation failed: {ex.Message}");
            }
            return;
        }
        if (this.program == "zoom")
        {
            const string zoomInstallerUrl = "https://zoom.us/client/6.2.7.49583/ZoomInstallerFull.exe?archType=x64\n";
            const string installerPath = @"C:\Temp\ZoomInstaller.exe";
            try
            {
                Console.WriteLine("Downloading Zoom installer...");
                using (WebClient client = new WebClient())
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(installerPath));
                    client.DownloadFile(zoomInstallerUrl, installerPath);
                }
                Console.WriteLine("Download completed!");
        
                Console.WriteLine("Installing application...");
                InstallFromExe(installerPath, "/silent /norestart");
                Console.WriteLine("Application installation completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Installation failed: {ex.Message}");
            }
            return;
        }
        
    }
    
}