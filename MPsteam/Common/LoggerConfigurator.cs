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
using NLog;
using NLog.Config;
using NLog.Targets;

namespace MPsteam.Common
{
   /// <summary>
   /// Interactions with mediaportal
   /// </summary>
   public static class LoggerConfigurator
   {
      /// <summary>
      /// Configure logger
      /// </summary>
      public static void Configure(string logFileName)
      {
         //TODO: Inject ILogLevelProvider instead of adding dependency to static MPLogLevelProvider to allow unit testing
         var config = LogManager.Configuration ?? new LoggingConfiguration();

         DeleteExistingLogFile(logFileName);

         var fileTarget = CreateFileTarget(logFileName);
         var logLevel = LogLevelProvider.GetLogLevel();
         var rule = new LoggingRule("MPsteam*", logLevel, fileTarget); // only push logging from namespace "MPsteam*" to log file
         
         config.AddTarget("file", fileTarget);
         config.LoggingRules.Add(rule);

         LogManager.Configuration = config;
      }

      private static FileTarget CreateFileTarget(string logFileName)
      {
         var fileTarget = new FileTarget
         {
            FileName = logFileName,
            Layout = "${date:format=yyyy-MM-dd HH\\:mm\\:ss,fff} " +
                     "${level:fixedLength=true:padding=5} [" +
                     "${threadid:fixedLength=true:padding=3} | ${logger:fixedLength=true:padding=13:shortName=true} ]: " +
                     "${message} ${exception:format=tostring}"
         };
         return fileTarget;
      }

      private static void DeleteExistingLogFile(string logFileName)
      {
         var logFile = new FileInfo(logFileName);
         if (logFile.Exists)
         {
            logFile.Delete();
         }
      }
   }
}
