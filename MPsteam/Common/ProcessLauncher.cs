using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MPsteam.Common
{
    public class ProcessLauncher
    {
        private Process _process;

        public ProcessLauncher(string path)
        {
            _process = new Process
            {
                StartInfo =
                {
                    FileName = path,
                }   
            };
        }

        public void AddExitedHandler(EventHandler evntHandler)
        {
            _process.EnableRaisingEvents = true;
            _process.Exited += evntHandler;
        }

        public void Start(string arguments = "")
        {
            _process.StartInfo.Arguments = arguments;
            _process.Start();
        }

        public bool IsRunning()
        {
            return Process.GetProcesses().Any(proc => proc.ProcessName.Contains(_process.StartInfo.FileName));
        }
    }
}
