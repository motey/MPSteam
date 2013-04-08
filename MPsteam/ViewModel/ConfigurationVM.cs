﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpSteam
{
   public class ConfigurationVM : ViewModelBase, ICloneable
   {
      public ConfigurationVM(ConfigurationModel model)
      {
         Title = "MPsteam settings";
         _configurationModel = model;
      }

      /// <summary>
      /// Copy constructor
      /// </summary>
      /// <param name="configToCopy">Configuration that is cloned</param>
      public ConfigurationVM(ConfigurationVM configToCopy)
      {
         Title = configToCopy.Title.Clone() as string;
         StartInBigPicture = configToCopy.StartInBigPicture;
         RunPreStartScript = configToCopy.RunPreStartScript;
         OverrideSteamPath = configToCopy.OverrideSteamPath;
         SteamPath = configToCopy.SteamPath.Clone() as string;
         PreStartScriptPath = configToCopy.PreStartScriptPath.Clone() as string;
         HomeMenuTitle = configToCopy.HomeMenuTitle.Clone() as string;
      }

      public string Title { get; set; }
      public ConfigurationModel Model { get { return _configurationModel; } }

      //Wrapped properties from configruation data
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
      

      public object Clone()
      {
         return new ConfigurationVM(this);
      }

      private ConfigurationModel _configurationModel = new ConfigurationModel();   
   } 
}
