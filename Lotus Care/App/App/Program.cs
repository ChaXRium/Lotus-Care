using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace App
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Enable DPI awareness (fix blurry UI on high DPI screens)
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Application.Run(new Form1());
        }
    }
}
