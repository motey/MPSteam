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
using MediaPortal.Services;
using NLog;

namespace MPsteam.Common
{
   /// <summary>
   /// NLog loglevel prvider. Converts from MediaPortalLogLevel to NLog LogLevel
   /// </summary>
   public static class LogLevelProvider
   {
      /// <summary>
      /// Get current log level from MediaPortal
      /// </summary>
      /// <returns>NLog loglevel</returns>
       public static LogLevel GetLogLevel()
       {
          LogLevel logLevel;
          var xmlreader = new MediaPortal.Profile.Settings(Config.GetFile(Config.Dir.Config, "MediaPortal.xml"));

          switch ((Level)xmlreader.GetValueAsInt("general", "loglevel", 0))
          {
             case Level.Error:
                logLevel = LogLevel.Error;
                break;
             case Level.Warning:
                logLevel = LogLevel.Warn;
                break;
             case Level.Information:
                logLevel = LogLevel.Info;
                break;
             default:
                logLevel = LogLevel.Debug;
                break;
          }

          return logLevel;
       }
   }
}
