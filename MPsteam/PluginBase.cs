#region Copyright (C) 2013 MPSteam

// Copyright (C) 2013 Tim Bleimehl, Jens Bühl
// https://github.com/motey/MPSteam
//
// MPSteam is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
//
// MPSteam is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MPSteam. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using MediaPortal.Common.Utils;
using MediaPortal.Dialogs;
using MediaPortal.GUI.Library;



namespace MPsteam
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
         return "Tim 'motey' Bleimehl, Jens 'exe' Buehl";
      }

      /// <summary>
      /// Show the setup dialog
      /// </summary>
      public void ShowPlugin()
      {
         //Only load if configuration exists
         if (File.Exists(_configurationVM.ConfigPath))
            _configurationVM.LoadFromFile(_configurationVM.ConfigPath);

         //Init dialog with configuration data
         configWindow wnd = new configWindow(_configurationVM.Clone() as ConfigurationVM);
         wnd.ShowDialog();

         if (wnd.DialogResult == DialogResult.OK)
         {
            //Save changes
            _configurationVM = wnd.GetResult();
            _configurationVM.SaveToFile(_configurationVM.ConfigPath);
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
         strButtonText = _configurationVM.HomeMenuTitle;
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
      /// Initialize the window plugin
      /// </summary>
      /// <returns>True if successfull, else false</returns>
      public override bool Init()
      {
         //Only load if configuration exists
         if (File.Exists(_configurationVM.ConfigPath))
            _configurationVM.LoadFromFile(_configurationVM.ConfigPath);

         //Init facade with configuration data
         _steamFacade = new SteamFacade(_configurationVM);

         return Load(GUIGraphicsContext.Skin + @"\MPsteam.xml");
      }

      protected override void OnPageLoad()
      {
         _steamFacade.Start();
         GUIDialogNotify dlg = (GUIDialogNotify)GUIWindowManager.GetWindow(
           (int)GUIWindow.Window.WINDOW_DIALOG_NOTIFY);
         dlg.SetHeading("Info");
         dlg.SetText("Starting Steam!");
         dlg.TimeOut = 8;
         dlg.DoModal(GUIWindowManager.ActiveWindow);
      }

      protected override void OnClicked(int controlId, GUIControl control, MediaPortal.GUI.Library.Action.ActionType actionType)
      {
         if (control == _buttonStart)
            _steamFacade.Start();
         else if (control == _buttonFocus)
            _steamFacade.SetFocus();

         base.OnClicked(controlId, control, actionType);
      }
      #endregion  

      #region private members

      [SkinControlAttribute(2)]
      protected GUIButtonControl _buttonStart = null;
      [SkinControlAttribute(3)]
      protected GUIButtonControl _buttonFocus = null; 

      private const short _windowID = 8465;
      private SteamFacade _steamFacade;
      private ConfigurationVM _configurationVM = new ConfigurationVM();

      #endregion    
   } 
}
