#region Copyright (C) 2013 MPSteam

// Copyright (C) 2013 Tim Bleimehl, Jens Bühl
// https://github.com/motey/MPSteam
//
// MPSteam is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
//
// MPSteam is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MPSteam. If not, see <http://www.gnu.org/licenses/>.

#endregion


using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace MPsteam
{
   public static class FocusChanger
   {
      [DllImport("user32.dll")]
      private static extern
            bool SetForegroundWindow(IntPtr hWnd);
      [DllImport("user32.dll")]
      private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
      [DllImport("user32.dll")]
      private static extern
            bool IsIconic(IntPtr hWnd);

      /// <summary>
      /// check if current process already running. if running, set focus to existing process and 
      /// returns <see langword="true"/> otherwise returns <see langword="false"/>.
      /// </summary>
      public static void SetFocusTo(string procName)
      {
         /*
         const int SW_HIDE = 0;
         const int SW_SHOWNORMAL = 1;
         const int SW_SHOWMINIMIZED = 2;
         const int SW_SHOWMAXIMIZED = 3;
         const int SW_SHOWNOACTIVATE = 4;      
         const int SW_SHOWDEFAULT = 10;
         */
         const int SW_RESTORE = 9;

         var arrProcesses = Process.GetProcessesByName(procName);
         for (var i = 0; i < arrProcesses.Length; i++)
         {
            // get the window handle
            IntPtr hWnd = arrProcesses[i].MainWindowHandle;

            // if iconic, we need to restore the window
            if (IsIconic(hWnd))
            {
               ShowWindowAsync(hWnd, SW_RESTORE);
            }
            // bring it to the foreground
            SetForegroundWindow(hWnd);
         }
      }
   }
}
