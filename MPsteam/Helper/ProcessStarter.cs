using System.Diagnostics;
using System.Linq;

namespace MPsteam.Helper
{
   static class ProcessStarter
   {
      public static void Start(string path, string arguments = "")
      {
         var proc = new Process
         {
            StartInfo =
            {
               FileName = path, 
               Arguments = arguments
            }
         };
         proc.Start();
      }

      public static bool IsRunning(string processName)
      {
         return Process.GetProcesses().Any(proc => proc.ProcessName.Contains(processName));
      }
   }
}
