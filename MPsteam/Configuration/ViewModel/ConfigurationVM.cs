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

using MPsteam.Helper;
using System;
using System.IO;

namespace MPsteam.Configuration
{
   public class ConfigurationVM : ViewModelBase, ICloneable
   {
      public ConfigurationVM(ConfigurationModel model)
      {
         //TODO: Kann man den MP Path auch über die MediaPortalAPI direkt abfragen?
         ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Team MediaPortal\MediaPortal\MPsteam.xml");
         Title = "MPsteam Configuration";
         Model = model;
      }

      public ConfigurationVM() : this (new ConfigurationModel())
      {
      }

      /// <summary>
      /// Copy constructor
      /// </summary>
      /// <param name="configToCopy">Configuration that is cloned</param>
      public ConfigurationVM(ConfigurationVM configToCopy)
      {
         Title = configToCopy.Title.Clone() as string;
         ConfigPath = configToCopy.ConfigPath.Clone() as string;
         StartInBigPicture = configToCopy.StartInBigPicture;
         RunPreStartScript = configToCopy.RunPreStartScript;
         OverrideSteamPath = configToCopy.OverrideSteamPath;
         SteamPath = configToCopy.SteamPath.Clone() as string;
         PreStartScriptPath = configToCopy.PreStartScriptPath.Clone() as string;
         PreStartScriptDelay = configToCopy.PreStartScriptDelay;
         HomeMenuTitle = configToCopy.HomeMenuTitle.Clone() as string;
      }

      #region Additional VM properties and methods
      /// <summary>
      /// Title, used for Window title
      /// </summary>
      public string Title { get; private set; }

      /// <summary>
      /// Actual data class that is beeing stored
      /// </summary>
      public ConfigurationModel Model 
      { 
         get 
         {
            return _configurationModel; 
         }
         private set
         {
            _configurationModel = value;
         }
      }

      /// <summary>
      /// Path to the configuration file
      /// </summary>
      public string ConfigPath
      {
         get
         {
            return _configurationPath;
         }
         private set
         {
            if (value != null && value != _configurationPath)
            {
               _configurationPath = value;
            }
         }
      }

      /// <summary>
      /// Load data from given file
      /// </summary>
      /// <param name="configPath">Path to configuration file</param>
      public void LoadFromFile(string configPath)
      {
         try
         {
            _configurationModel = XMLSerializer.Load(configPath, typeof(ConfigurationModel)) as ConfigurationModel;
         }
         catch (Exception e)
         {
            //TODO: Log4Net here?
            Console.WriteLine("LoadFromFile failed: " + e.Message);
         }
      }

      /// <summary>
      /// Save data to given file
      /// </summary>
      /// <param name="configPath">Path to configuration file</param>
      public void SaveToFile(string configPath)
      {
         try
         {
            XMLSerializer.Save(configPath, Model);
         }
         catch (Exception e)
         {
            //TODO: Log4Net here?
            Console.WriteLine("SaveToFile failed: " + e.Message);
         }
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

      #region IClonable
      public object Clone()
      {
         return new ConfigurationVM(this);
      }
      #endregion

      #region private members
      private String _configurationPath;
      private ConfigurationModel _configurationModel = new ConfigurationModel();   
      #endregion    
   } 
}
