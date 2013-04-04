using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using MediaPortal.Common.Utils;
using MediaPortal.Dialogs;
using MediaPortal.GUI.Library;
using Microsoft.Win32;

[assembly: CompatibleVersion("1.2.100.0", "1.1.6.27644")]
[assembly: UsesSubsystem("MP.SkinEngine")]
[assembly: UsesSubsystem("MP.Config")]

namespace MpSteam
{
   public class PluginBase : GUIWindow, ISetupForm
   {
      #region ISetupForm Members

      /// <summary>
      /// Returns the name of the plugin which is shown in the plugin menu
      /// </summary>
      public string PluginName()
      {
         return "MPsteam";
      }

      /// <summary>
      /// The description of the plugin is shown in the plugin menu
      /// </summary>
      /// <returns>Description string</returns>
      public string Description()
      {
         return "This plugin provides a menu item to start Steam in Big Picture Mode.";
      }

      /// <summary>
      /// Returns the author of the plugin which is shown in the plugin menu
      /// </summary>
      /// <returns>Author string</returns>
      public string Author()
      {
         return "Tim 'motey' Bleimehl";
      }

      /// <summary>
      /// Show the setup dialog
      /// </summary>
      public void ShowPlugin()
      {
         LoadConfiguration();
         configWindow wnd = new configWindow(_configuration.Clone() as ConfigurationVM);
         wnd.ShowDialog();

         if (wnd.DialogResult == DialogResult.OK)
         {
            //Save changes
            _configuration = wnd.GetResult();
            SaveConfiguration();
         }
         
      }

      /// <summary>
      /// Indicates whether plugin can be enabled/disabled
      /// </summary>
      /// <returns>True if plugin can be enabled/disbaled, else false</returns>
      public bool CanEnable()
      {
         return true;
      }

      /// <summary>
      /// Returns unique window ID belonging to this setup
      /// </summary>
      /// <returns>Unique Window ID</returns>
      public int GetWindowId()
      {
         return _windowID;
      }

      /// <summary>
      /// Indicates if plugin is enabled by default
      /// </summary>
      /// <returns>True if enabled by default, else false</returns>
      public bool DefaultEnabled()
      {
         return true;
      }

      /// <summary>
      /// indicates if a plugin has it's own setup screen
      /// </summary>
      /// <returns>True if it has it's own setup screen, else false</returns>
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
      public bool GetHome(out string strButtonText, out string strButtonImage, out string strButtonImageFocus, out string strPictureImage)
      {
         strButtonText = "Steam";
         strButtonImage = String.Empty;
         strButtonImageFocus = String.Empty;
         strPictureImage = String.Empty;
         return true;
      }

      #endregion

      #region  GUIWindows overrides

      /// <summary>
      /// If overridden it idicates that it is a "window-plugin", else it will be a process-plugin
      /// Return the unique window ID again
      /// </summary>
      public override int GetID
      {
         get
         {
            return _windowID;
         }
      }

      /// <summary>
      /// Initialize the plugin
      /// </summary>
      /// <returns>True if successfull, else false</returns>
      public override bool Init()
      {
         LoadConfiguration();      
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
      protected override void OnClicked(int controlId, GUIControl control, MediaPortal.GUI.Library.Action.ActionType actionType)
      {
         if (control == _buttonStart)
            OnButtonStart();
         else if (control == _buttonFocus)
            OnButtonFocus();

         base.OnClicked(controlId, control, actionType);
      }

      #endregion
      
      /// <summary>
      /// Button start click handler
      /// </summary>
      private void OnButtonStart()
      {
         StartSteam();
      }

      /// <summary>
      /// Button focus click handler
      /// </summary>
      private void OnButtonFocus()
      {
         FocusChanger.SetFocusToSteam();
      }

      /// <summary>
      /// Check if steam is already running or not
      /// </summary>
      /// <returns>True if steam is running, else false</returns>
      private bool IsSteamRunning()
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

      /// <summary>
      /// Get path to steam executable
      /// </summary>
      /// <returns>Path to steam executable</returns>
      private string GetSteamExePath()
      {
         if (_configuration.OverrideSteamPath)
         {
            return _configuration.SteamPath;
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

      /// <summary>
      /// Start steam, method does too much at the moment
      /// </summary>
      private void StartSteam()
      {
         if (_configuration.RunPreStartScript)
         {
            string scriptPath = _configuration.PreStartScriptPath;
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
               if (!_configuration.StartInBigPicture)
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
               if (!_configuration.StartInBigPicture)
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

      //TODO: Move to seperate class
      private void LoadConfiguration()
      {
	      string configPath = GetConfigurationPath();
         if (File.Exists(configPath))
         {
            ConfigurationModel configurationModel = XMLSerializer.Load(configPath, typeof(ConfigurationModel)) as ConfigurationModel;
            _configuration = new ConfigurationVM(configurationModel);
         }
      }

      //TODO: Move to seperate class
      private void SaveConfiguration()
      {
         string configPath = GetConfigurationPath();
         XMLSerializer.Save(configPath, _configuration.Model);
      }

      //TODO: Move to seperate class
      private string GetConfigurationPath()
      {
         return @"c:\temp\MPsteam.xml";
         /*if (Environment.OSVersion.Version.Major > 4 && Environment.OSVersion.Version.Minor > 1)
         {
            return Path.Combine(Environment.GetEnvironmentVariable("PUBLIC"), @"Team MediaPortal\MediaPortal\MPsteam.xml");
         }
         else
         {
            return Path.Combine(Environment.GetEnvironmentVariable("ALLUSERSPROFILE"), @"Team MediaPortal\MediaPortal\MPsteam.xml");
         }*/
      }

      #region private members

      [SkinControlAttribute(2)]
      protected GUIButtonControl _buttonStart = null;
      [SkinControlAttribute(3)]
      protected GUIButtonControl _buttonFocus = null; 

      private const short _windowID = 8465;
      private ConfigurationVM _configuration = new ConfigurationVM(new ConfigurationModel());

      #endregion    
   } 
}
