using MediaPortal.GUI.Library;
using Microsoft.Win32;
using MPsteam.Common;
using MPsteam.Configuration;
using MPsteam.Helper;
using System.Collections.Generic;
using System.IO;

namespace MPsteam.Steam
{
   class SteamStarter : ISteamStarter
   {
      private readonly ConfigurationModel _configuration;
      private readonly ProcessLauncher _steamLauncher;

      public SteamStarter(ConfigurationModel configuration)
      {
         _configuration = configuration;
         _steamLauncher = new ProcessLauncher(GetSteamPath());
      }

      #region ISteamStarter interface
      /// <summary>
      /// Start steam
      /// </summary>
      public void Start()
      {
         MediaPortalService.StopPlayback();
         StartSteam();
      }

      /// <summary>
      /// Set Focus to steam
      /// </summary>
      public void SetFocus()
      {
         FocusChanger.SetFocusTo("Steam");
      }
      #endregion

      private void StartSteam()
      {
         if (_configuration.RunPreStartScript)
         {
            RunPreStartScript();
         }

         if (_configuration.SuspendMediaPortal)
         {
            SuspendMediaPortal();
         }
         _steamLauncher.Start(GetProcessArguments());
      }

      private void SuspendMediaPortal()
      {
         MediaPortalService.Suspend();
         _steamLauncher.AddExitedHandler((o, e) => ResumeMediaPortal());
      }

      private void ResumeMediaPortal()
      {
         MediaPortalService.Resume();
      }

      private string GetProcessArguments()
      {
         string arguments = "";
         if (_configuration.StartInBigPicture)
         {
            if (_steamLauncher.IsRunning())
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

      private string GetSteamPath()
      {
         //From Config
         if (_configuration.OverrideSteamPath)
         {
            return _configuration.SteamPath;
         }

         //From Registry
         return GetSteamPathFromRegistry();
      }

      private string GetSteamPathFromRegistry()
      {
         var regKey = Registry.CurrentUser;
         regKey = regKey.OpenSubKey(@"Software\Valve\Steam");

         if (regKey != null)
         {
            return regKey.GetValue("SteamExe").ToString();
         }

         const string errrorMessage = "Steam registry key not found";
         Log.Error(errrorMessage);
         throw new KeyNotFoundException(errrorMessage);
      }

      private void RunPreStartScript()
      {
         if (!File.Exists(_configuration.ScriptPath))
         {
            var errrorMessage = _configuration.ScriptPath;
            Log.Error(errrorMessage);
            throw new FileNotFoundException(errrorMessage);
         }

         var sciptPath = _configuration.ScriptPath;
         var scriptLauncher = new ProcessLauncher(sciptPath);
         var delay = _configuration.ScriptDelay;

         System.Threading.Thread.Sleep(delay);
         scriptLauncher.Start();
      }
   }
}
