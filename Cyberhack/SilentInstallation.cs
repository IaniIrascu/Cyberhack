using System;
using System.Diagnostics;
using System.IO;

namespace Cyberhack
{
    class UniversalInstallation
    {

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
        public static void InstallFromMicrosoftStore(string appId)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("App ID or name cannot be empty.");
            }

            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-Command \"Install-StoreApp -AppId {appId}\"",
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

        public static void InstallFromExe(string exePath, string arguments)
        {
            if (!File.Exists(exePath))
            {
                throw new FileNotFoundException($"Installer not found at {exePath}");
            }
            ProcessStartInfo processInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = arguments, // Pass installer arguments like /S for silent installation
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true // Avoid showing a window for the process
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