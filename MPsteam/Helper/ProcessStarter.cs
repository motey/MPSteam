using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MPsteam
{
   class ProcessStarter
   {
      public static void Start(string path, string arguments = "")
      {
         Process proc = new Process();
         proc.StartInfo.FileName = path;
         proc.StartInfo.Arguments = arguments;
         proc.Start();
      }

      public static bool IsRunning(string processName)
      {
         return Process.GetProcesses().Any(proc => proc.ProcessName.Contains("Steam"));
      }
   }
}
