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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace MPsteam
{
   /// <summary>
   /// A base class implementation of INotifyPropertyChanged, 
   /// derive from this class for databinding objects (ViewModels).
   /// </summary>
   public abstract class ViewModelBase : INotifyPropertyChanged
   {
      /// <summary>
      /// Raised when a property on this object has a new value.
      /// </summary>
      public event PropertyChangedEventHandler PropertyChanged;

      #region INotifyPropertyChanged Members

      /// <summary>
      /// Raises this object's PropertyChanged event.
      /// </summary>
      /// <param name="propertyName">The property that has a new value.</param>
      protected virtual void OnPropertyChanged(string propertyName)
      {
         if (this.PropertyChanged != null)
         {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
      }

      #endregion // INotifyPropertyChanged Members
   }
}
