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

using System.IO;
using MediaPortal.GUI.Library;
using MPsteam.Common;
using System;

namespace MPsteam.Configuration
{
   public class ConfigurationAccessor : IConfigurationAccessor
   {
      private readonly String _configurationPath;
      private ConfigurationModel _configurationModel;

      public ConfigurationAccessor(string configurationPath)
      {
         _configurationPath = configurationPath;
         _configurationModel = new ConfigurationModel();

         CreateNewConfigurationFile();
      }

      public ConfigurationModel Model
      {
         get
         {
            return _configurationModel;
         }
      }

      public void Load()
      {
         try
         {
            _configurationModel = XMLSerializer.Load(_configurationPath, typeof(ConfigurationModel)) as ConfigurationModel;
         }
         catch (Exception e)
         {
            Log.Error(e);
         }
      }

      public void Save(ConfigurationModel model)
      {
         try
         {
            XMLSerializer.Save(_configurationPath, model);
            _configurationModel = model;
         }
         catch (Exception e)
         {
            Log.Error(e);
         }
      }

      private void CreateNewConfigurationFile()
      {
         if (!File.Exists(_configurationPath))
         {
            Save(_configurationModel);
         }
      }
   } 
}
