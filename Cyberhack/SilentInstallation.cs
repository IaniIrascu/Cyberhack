using System;
using System.Diagnostics;
using System.IO;

namespace Cyberhack
{
    class UniversalInstallation
    {
        // static void Main(string[] args)
        // {
        //     if (args.Length == 0)
        //     {
        //         Console.WriteLine("Usage: UniversalInstaller.exe <path_to_installer> [arguments]");
        //         return;
        //     }
        //
        //     string installerPath = args[0];
        //     string installArguments = args.Length > 1 ? args[1] : "/quiet /norestart";
        //
        //     try
        //     {
        //         InstallApplication(installerPath, installArguments);
        //         Console.WriteLine("Installation completed successfully.");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"An error occurred: {ex.Message}");
        //     }
        // }

        public static void InstallApplication(string installerPath, string arguments)
        {
            if (!File.Exists(installerPath))
            {
                throw new FileNotFoundException($"Installer not found at {installerPath}");
            }

            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "msiexec.exe",
                Arguments = $"/i \"{installerPath}\" {arguments}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (Process process = Process.Start(processInfo))
            {
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"Installation failed with exit code {process.ExitCode}");
                }
            }
        }
    }
}