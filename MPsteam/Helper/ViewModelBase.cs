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
