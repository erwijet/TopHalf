using System;
using System.Reflection;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;

using static System.Environment;
using static System.Windows.Forms.Application;

namespace TopHalf
{
    struct Modifiers
    {
        const int NOMOD = 0x0000;
        const int CTRL = 0x0002;
        const int SHIFT = 0x0004;
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            string shortcutPath = GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TopHalf.lnk";
            
            if (!System.IO.File.Exists(shortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = Assembly.GetExecutingAssembly().Location;
                shortcut.WorkingDirectory = CurrentDirectory;
                shortcut.WindowStyle = 1;
                shortcut.Description = "TopHalf";
                shortcut.IconLocation = SystemDirectory + "\\wpdshext.dll, 16"; // UP ARROW
                shortcut.Hotkey = "CTRL+ALT+U";
                shortcut.Save();
            }

            OverlayForm frm = new OverlayForm();

            EnableVisualStyles();
            SetCompatibleTextRenderingDefault(false);
            
            GlobalHotkey ghk = new GlobalHotkey()
            
            Run(frm);
        }
    }
}
