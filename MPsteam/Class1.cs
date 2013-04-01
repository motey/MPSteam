using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;
using MediaPortal.Common.Utils;
[assembly: CompatibleVersion("1.2.100.0", "1.1.6.27644")]
[assembly: UsesSubsystem("MP.SkinEngine")]
[assembly: UsesSubsystem("MP.Config")]

namespace MpSteam
{
    public class Class1 : GUIWindow, ISetupForm
    {
        [SkinControlAttribute(2)] protected GUIButtonControl buttonOne=null;
        [SkinControlAttribute(3)] protected GUIButtonControl buttonTwo=null;
        ConfigReadWrite config = new ConfigReadWrite(@"D:\config.xml"); //TODO: PATH %PROGRAMDATA%/TeamMediaportal ..blabla
        public Class1()
        {

        }

        #region ISetupForm Members

        // Returns the name of the plugin which is shown in the plugin menu
        public string PluginName()
        {
            return "MPsteam";
        }

        // Returns the description of the plugin is shown in the plugin menu
        public string Description()
        {
            return "This tiny Plugin provides a menu item to start Steam in Big Picture Mode.";
        }

        // Returns the author of the plugin which is shown in the plugin menu
        public string Author()
        {
            return "Tim 'motey' Bleimehl";
        }

        // show the setup dialog
        public void ShowPlugin()
        {
            MessageBox.Show("Nothing to configure, this is just an example");
        }

        // Indicates whether plugin can be enabled/disabled
        public bool CanEnable()
        {
            return true;
        }

        // Get Windows-ID
        public int GetWindowId()
        {
            // WindowID of windowplugin belonging to this setup
            // enter your own unique code
            return 8465;
        }

        // Indicates if plugin is enabled by default;
        public bool DefaultEnabled()
        {
            return true;
        }

        // indicates if a plugin has it's own setup screen
        public bool HasSetup()
        {
            return true;
        }

        /// <summary>
        /// If the plugin should have it's own button on the main menu of MediaPortal then it
        /// should return true to this method, otherwise if it should not be on home
        /// it should return false
        /// </summary>
        /// <param name="strButtonText">text the button should have</param>
        /// <param name="strButtonImage">image for the button, or empty for default</param>
        /// <param name="strButtonImageFocus">image for the button, or empty for default</param>
        /// <param name="strPictureImage">subpicture for the button or empty for none</param>
        /// <returns>true : plugin needs it's own button on home
        /// false : plugin does not need it's own button on home</returns>

        public bool GetHome(out string strButtonText, out string strButtonImage,
          out string strButtonImageFocus, out string strPictureImage)
        {
            strButtonText = "Start Steam";
            strButtonImage = String.Empty;
            strButtonImageFocus = String.Empty;
            strPictureImage = String.Empty;
            return true;
        }

        // With GetID it will be an window-plugin / otherwise a process-plugin
        // Enter the id number here again
        public override int GetID
        {
            get
            {
                return 8465;
            }

            set
            {
            }
        }
        public override bool Init()
        {
            return Load(GUIGraphicsContext.Skin + @"\MPsteam.xml");
        }
        protected override void OnPageLoad()
        {
            StartSteam();
            GUIDialogNotify dlg = (GUIDialogNotify)GUIWindowManager.GetWindow(
              (int)GUIWindow.Window.WINDOW_DIALOG_NOTIFY);
            dlg.SetHeading("Info");
            dlg.SetText("Trying to start Steam!");
            dlg.TimeOut = 8;
            dlg.DoModal(GUIWindowManager.ActiveWindow);
        }
        protected override void OnClicked(int controlId, GUIControl control,MediaPortal.GUI.Library.Action.ActionType actionType)
        {
            if (control == buttonOne)
                OnButtonOne();
            if (control == buttonTwo)
                OnButtonTwo();
            base.OnClicked(controlId, control, actionType);
        }
        private void OnButtonOne()
        {
            StartSteam();
        }
        private void OnButtonTwo()
        {
            GetSteaminForeground.AlreadyRunning();
        }

        public bool IsSteamRunning()
        {
            foreach (Process steamProcess in System.Diagnostics.Process.GetProcesses())
            {
                if (steamProcess.ProcessName.Contains("Steam"))
                {
                        return true;
                }
            }
            return false;
        }

        public string GetSteamExePath()
        {
            if (config.ReadConfigItem("ManualSteamPath") == "true")
            {
                return config.ReadConfigItem("SteamPath");
            }
            else
            {
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.OpenSubKey(@"Software\Valve\Steam");

                if (regKey != null)
                {
                    string installpath = regKey.GetValue("SteamExe").ToString();
                    return installpath;
                }
                else
                {
                    return "NF"; //Not found
                }
            }
            
        }

        public void StartSteam()
        {
            if (config.ReadConfigItem("StartScript") == "true")
            {
                string scriptPath = config.ReadConfigItem("StartScriptPath");
                Process script = new Process();
                script.StartInfo.FileName = scriptPath;
                script.Start();
            }
            string steamapp = GetSteamExePath();
            if (steamapp != "NF" && File.Exists(steamapp))
            {

                if (IsSteamRunning())
                {
                    Process steam = new Process();
                    steam.StartInfo.FileName = steamapp;
                    if (config.ReadConfigItem("BigPictureMode") == "false")
                    {
                        steam.StartInfo.Arguments = "";
                    }
                    else
                    {
                        steam.StartInfo.Arguments = "steam://open/bigpicture";
                    }
                    steam.Start();
                }
                else
                {
                    Process steam = new Process();
                    steam.StartInfo.FileName = steamapp;
                    if (config.ReadConfigItem("BigPictureMode") == "false")
                    {
                        steam.StartInfo.Arguments = "";
                    }
                    else
                    {
                        steam.StartInfo.Arguments = "-bigpicture";
                    }
                    
                    steam.Start();

                }
            }
            else
            {
                GUIDialogOK dlg = (GUIDialogOK)GUIWindowManager.GetWindow(
                (int)GUIWindow.Window.WINDOW_DIALOG_OK);
                dlg.SetHeading("Steam Not Found");
                dlg.SetLine(1, "Sorry, can't find your Steam.exe!");
                dlg.SetLine(2, String.Empty);
                dlg.SetLine(3, String.Empty);
                dlg.DoModal(GUIWindowManager.ActiveWindow);
            }
        }
        #endregion
    }

    public static class GetSteaminForeground
    {
        [DllImport("user32.dll")]
        private static extern
            bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern
            bool IsIconic(IntPtr hWnd);

        /// -------------------------------------------------------------------------------------------------
        /// <summary> check if current process already running. if running, set focus to existing process and 
        ///           returns <see langword="true"/> otherwise returns <see langword="false"/>. </summary>
        /// <returns> <see langword="true"/> if it succeeds, <see langword="false"/> if it fails. </returns>
        /// -------------------------------------------------------------------------------------------------
        public static bool AlreadyRunning()
        {
            bool success = false;
            /*
            const int SW_HIDE = 0;
            const int SW_SHOWNORMAL = 1;
            const int SW_SHOWMINIMIZED = 2;
            const int SW_SHOWMAXIMIZED = 3;
            const int SW_SHOWNOACTIVATE = 4;
            const int SW_RESTORE = 9;
            const int SW_SHOWDEFAULT = 10;
            */
            const int swRestore = 9;
            var arrProcesses = Process.GetProcessesByName("Steam");
            for (var i = 0; i < arrProcesses.Length; i++)
            {  
                // get the window handle
                IntPtr hWnd = arrProcesses[i].MainWindowHandle;

                // if iconic, we need to restore the window
                if (IsIconic(hWnd))
                {
                    ShowWindowAsync(hWnd, swRestore);
                }
                // bring it to the foreground
                SetForegroundWindow(hWnd);
                success = true;
            }
            if (success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
