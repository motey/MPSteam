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

using MediaPortal.GUI.Library;
using MediaPortal.Player;
using System.ComponentModel;
using System.Threading;

namespace MPsteam.Helper
{
   /// <summary>
   /// A base class implementation of INotifyPropertyChanged, 
   /// derive from this class for databinding objects (ViewModels).
   /// </summary>
   public static class MediaPortalAccessor
   {
      public static void StopPlayback()
      {
         if (GUIGraphicsContext.IsPlaying)
         {
            g_Player.Stop();
            while (GUIGraphicsContext.IsPlaying)
            {
               Thread.Sleep(100);
            }
         }
      }
   }
}
