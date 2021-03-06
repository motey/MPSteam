﻿#region Copyright (C) 2014 MPsteam

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

using System;
using System.Xml.Serialization;

namespace MPsteam.Configuration
{
   [XmlRootAttribute("MPsteamConfiguration")]
   public class ConfigurationModel
   {
      public ConfigurationModel()
      {
         //Set defaults
         StartInBigPicture = true;
         RunPreStartScript = false;
         OverrideSteamPath = false;
         SuspendMediaPortal = false;
         SteamPath = String.Empty;
         ScriptPath = String.Empty;
         ScriptDelay = 0;
         HomeMenuTitle = "Steam";
      }

      public bool StartInBigPicture { get; set; }
      public bool RunPreStartScript { get; set; }
      public bool SuspendMediaPortal { get; set; }
      public bool OverrideSteamPath { get; set; }
      public int ScriptDelay { get; set; }
      public string ScriptPath { get; set; }        
      public string SteamPath { get; set; }
      public string HomeMenuTitle { get; set; }
   }
}
