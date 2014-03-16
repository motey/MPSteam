using MediaPortal.Dialogs;
using MediaPortal.GUI.Library;
using Microsoft.Win32;
using MPsteam.Common;
using MPsteam.Configuration;
using MPsteam.Helper;
using System;
using System.Collections.Generic;
using System.IO;

namespace MPsteam.Steam
{
    class SteamStarter : ISteamStarter
    {
        public SteamStarter(ConfigurationVM configurationVM )
        {
            _configurationVM = configurationVM;
            _procLauncher = new ProcessLauncher(GetSteamPath());
        }

        /// <summary>
        /// Start steam
        /// </summary>
        public void Start()
        {
            MediaPortalHelper.StopPlayback();
            MediaPortalHelper.Suspend();
            StartSteam();
        }

        /// <summary>
        /// Set Focus to steam
        /// </summary>
        public void SetFocus()
        {
            FocusChanger.SetFocusTo("Steam");
        }

        private void StartSteam()
        {
            if (_configurationVM.RunPreStartScript)
            {
                RunPreStartScript(_configurationVM.PreStartScriptPath, _configurationVM.PreStartScriptDelay);
            }

            try
            {
                _procLauncher.AddExitedHandler(new EventHandler((o, e) => { OnExit(); }));
                _procLauncher.Start(GetProcessArguments());
            }
            catch (Exception)
            {
                //Logging
            }
        }

        private void OnExit()
        {
            MediaPortalHelper.Resume();
        }

        private string GetProcessArguments()
        {
            string arguments = "";
            if (_configurationVM.StartInBigPicture)
            {
                if (_procLauncher.IsRunning())
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
            //From Config
            if (_configurationVM.OverrideSteamPath)
            {
                return _configurationVM.SteamPath;
            }
            //From Registry
            else
            {
                return GetSteamPathFromRegistry();
            }
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
                //Logging
                throw new FileNotFoundException("Script does not exist");
            }

            System.Threading.Thread.Sleep(delay);
            _procLauncher.Start();
        }

        private readonly ConfigurationVM _configurationVM;
        private readonly ProcessLauncher _procLauncher;
    }
}
