using MediaPortal.Dialogs;
using MediaPortal.GUI.Library;
using Microsoft.Win32;
using MPsteam.Configuration;
using MPsteam.Helper;
using System;
using System.Collections.Generic;
using System.IO;

namespace MPsteam.Steam
{
   class SteamStarter : ISteamStarter
   {
      public SteamStarter(ConfigurationVM configurationVM)
      {
         _configurationVM = configurationVM;
      }

      /// <summary>
      /// Start steam
      /// </summary>
      public void Start()
      {
         StartSteam();
      }

      /// <summary>
      /// Set Focus to steam
      /// </summary>
      public void SetFocus()
      {
         FocusChanger.SetFocusTo("Steam");
      }

      /// <summary>
      /// Start steam, method does too much at the moment
      /// </summary>
      private void StartSteam()
      {
         if (_configurationVM.RunPreStartScript)
         {
            RunPreStartScript(_configurationVM.PreStartScriptPath, _configurationVM.PreStartScriptDelay);
         }   

         try
         {
            ProcessStarter.Start(GetSteamPath(), GetProcessArguments());
         }
         catch (Exception)
         {
            var dlg = (GUIDialogOK)GUIWindowManager.GetWindow((int)GUIWindow.Window.WINDOW_DIALOG_OK);
            dlg.SetHeading("Steam not found");
            dlg.SetLine(1, "Could not find your steam.exe!");
            dlg.SetLine(2, String.Empty);
            dlg.SetLine(3, String.Empty);
            dlg.DoModal(GUIWindowManager.ActiveWindow);
         }
      }

      private string GetProcessArguments()
      {
         string arguments = "";
         if (_configurationVM.StartInBigPicture)
         {
            if (ProcessStarter.IsRunning("Steam"))
            {
               arguments = "steam://open/bigpicture";
            }
            else
            {
               arguments = "-bigpicture";
            }
         }
         return arguments;
      }

      /// <summary>
      /// Get path to steam executable
      /// </summary>
      /// <returns>Path to steam executable</returns>
      private string GetSteamPath()
      {
         string steamPath;

         //From Config
         if (_configurationVM.OverrideSteamPath)
         {
            steamPath = _configurationVM.SteamPath;
         }
         //From Registry
         else
         {
            steamPath = GetSteamPathFromRegistry();        
         }

         if (!File.Exists(steamPath))
         {
            throw new FileNotFoundException();
         }

         return steamPath;
      }

      private string GetSteamPathFromRegistry()
      {
         RegistryKey regKey = Registry.CurrentUser;
         regKey = regKey.OpenSubKey(@"Software\Valve\Steam");

         if (regKey != null)
         {
            return regKey.GetValue("SteamExe").ToString();
         }
         
         throw new KeyNotFoundException();
      }

      /// <summary>
      /// Starts a pre start script at given path with given delay in milliseconds
      /// </summary>
      /// <param name="path">Path to the executable</param>
      /// <param name="delay">Delay before executing the script</param>
      private void RunPreStartScript(string path, int delay)
      {
         if (!File.Exists(_configurationVM.PreStartScriptPath))
         {
            //Add log entry here?
            throw new FileNotFoundException("Script does not exist");
         }       

         //Delay the start, simple way, eventually blocking GUI?
         System.Threading.Thread.Sleep(delay);

         ProcessStarter.Start(path);
      }

      private readonly ConfigurationVM _configurationVM;
   }
}
