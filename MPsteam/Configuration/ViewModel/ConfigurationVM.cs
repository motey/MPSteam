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
using MPsteam.Common;
using System;

namespace MPsteam.Configuration
{
   public class ConfigurationVM : ViewModelBase
   {
      public ConfigurationVM(ConfigurationModel model)
      {
         _configurationModel = model;
         Title = "MPsteam Configuration";
      }

      #region Additional VM properties and methods
      
      public string Title { get; private set; }

      public ConfigurationModel Model
      {
         get { return _configurationModel; }
      }
      
      #endregion

      #region Wrapped properties from configruation data
      public bool StartInBigPicture 
      { 
         get
         {
            return _configurationModel.StartInBigPicture;
         }
         set
         {
            if (value != _configurationModel.StartInBigPicture)
            {
               _configurationModel.StartInBigPicture = value;
               OnPropertyChanged("StartInBigPicture");
            }
         }
      }

      public bool RunPreStartScript
      {
         get
         {
            return _configurationModel.RunPreStartScript;
         }
         set
         {
            if (value != _configurationModel.RunPreStartScript)
            {
               _configurationModel.RunPreStartScript = value;
               OnPropertyChanged("RunPreStartScript");
            }
         }
      }

      public string PreStartScriptPath
      {
         get
         {
            return _configurationModel.ScriptPath;
         }
         set
         {
            if (value != _configurationModel.ScriptPath)
            {
               _configurationModel.ScriptPath = value;
               OnPropertyChanged("ScriptPath");
            }
         }
      }

      public int PreStartScriptDelay
      {
         get
         {
            return _configurationModel.ScriptDelay;
         }
         set
         {
            if (value != _configurationModel.ScriptDelay)
            {
               _configurationModel.ScriptDelay = value;
               OnPropertyChanged("ScriptDelay");
            }
         }
      }

      public bool OverrideSteamPath
      {
         get
         {
            return _configurationModel.OverrideSteamPath;
         }
         set
         {
            if (value != _configurationModel.OverrideSteamPath)
            {
               _configurationModel.OverrideSteamPath = value;
               OnPropertyChanged("OverrideSteamPath");
            }
         }
      }

      public bool SuspendMediaPortal
      {
         get
         {
            return _configurationModel.SuspendMediaPortal;
         }
         set
         {
            if (value != _configurationModel.SuspendMediaPortal)
            {
               _configurationModel.SuspendMediaPortal = value;
               OnPropertyChanged("SuspendMediaPortal");
            }
         }
      }

      public string SteamPath
      {
         get
         {
            return _configurationModel.SteamPath;
         }
         set
         {
            if (value != _configurationModel.SteamPath)
            {
               _configurationModel.SteamPath = value;
               OnPropertyChanged("SteamPath");
            }
         }
      }

      public string HomeMenuTitle
      {
         get 
         { 
            return _configurationModel.HomeMenuTitle; 
         }
         set
         {
            if (value != _configurationModel.HomeMenuTitle)
            {
               _configurationModel.HomeMenuTitle = value;
               OnPropertyChanged("HomeMenuTitle");
            }
         }
      }
      #endregion

      private readonly ConfigurationModel _configurationModel;   
   } 
}
