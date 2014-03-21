#region Copyright (C) 2014 MPsteam

// Copyright (C) 2014 motey, exe
// https://github.com/motey/MPsteam
//
// MPsteam is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
//
// MPsteam is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MPsteam. If not, see <http://www.gnu.org/licenses/>.

#endregion

using MediaPortal.Configuration;
using MediaPortal.GUI.Library;
using MPsteam.Common;
using MPsteam.Configuration;
using MPsteam.Steam;
//using NLog;
using System;
using System.Windows.Forms;

namespace MPsteam
{
   [PluginIcons("MPsteam.Resources.MPsteam-icon-small.png", "MPsteam.Resources.MPsteam-icon-faded-small.png")]
   public class MPsteamPlugin : GUIWindow, ISetupForm
   {
      #region private members

      //MP GUI
      private const short PLUGIN_WINDOW_ID = 8465;
      [SkinControlAttribute(2)]
      private readonly GUIButtonControl _buttonStart = null;
      [SkinControlAttribute(3)]
      private readonly GUIButtonControl _buttonFocus = null;

      //Services
      private ISteamStarter _steamStarter;
      private IConfigurationAccessor _configAccessor;

      //Paths
      private string _configFilePath;
      private string _logFilePath;
      private string _skinFilePath;

      //NLog logger
      //private static Logger _log = LogManager.GetCurrentClassLogger();

      #endregion

      public MPsteamPlugin()
      {
         InitMPsteam();
      }

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
         return "Provides a menu item to start Steam in big picture mode.";
      }

      /// <summary>
      /// Returns the author of the plugin which is shown in the plugin menu
      /// </summary>
      /// <returns>Author string</returns>
      public string Author()
      {
         return "motey, exe";
      }

      /// <summary>
      /// Show the setup dialog
      /// </summary>
      public void ShowPlugin()
      {
         //Load config file
         _configAccessor.Load();

         //Init dialog with config data
         var wnd = new configWindow(new ConfigurationVM(_configAccessor.Model));
         wnd.ShowDialog();

         if (wnd.DialogResult == DialogResult.OK)
         {
            //Save changes
            var configurationVM = wnd.GetResult();
            _configAccessor.Save(configurationVM.Model);
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
         return PLUGIN_WINDOW_ID;
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
         strButtonText = _configAccessor.Model.HomeMenuTitle;
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
            return PLUGIN_WINDOW_ID;
         }
      }

      /// <summary>
      /// Initialize the window plugin
      /// </summary>
      /// <returns>True if successfull, else false</returns>
      public override bool Init()
      {
         Log.Info("MPsteam.PluginBase.Init()");
         //_log.Info("MPsteam.PluginBase.Init()");

         //Init steam starter
         _steamStarter = new SteamStarter(_configAccessor.Model);

         //Load skin
         _skinFilePath = GUIGraphicsContext.Skin + @"\MPsteam.xml";
         return Load(_skinFilePath);
      }

      protected override void OnPageLoad()
      {
          _steamStarter.Start();
      }

      protected override void OnClicked(int controlId, GUIControl control, MediaPortal.GUI.Library.Action.ActionType actionType)
      {
         if (control == _buttonStart)
            _steamStarter.Start();
         else if (control == _buttonFocus)
            _steamStarter.SetFocus();

         base.OnClicked(controlId, control, actionType);
      }
      #endregion

      private void InitMPsteam()
      {
         //Init paths
         _configFilePath = Config.GetFolder(Config.Dir.Config) + @"\MPsteam.xml";
         _logFilePath = Config.GetFolder(Config.Dir.Log) + @"\MPsteam.log";

         //Init configuration
         _configAccessor = new ConfigurationAccessor(_configFilePath);
         _configAccessor.Load();

         //Init logger
         //LoggerConfigurator.Configure(_logFilePath);

         Log.Info("MPsteam initialized");
         //_log.Info("MPsteam initialized");
      }
   } 
}
