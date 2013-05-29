using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPsteam
{
   public interface ISteamStarter
   {
      /// <summary>
      /// Start Steam
      /// </summary>
      void Start();

      /// <summary>
      /// Set Focus to Steam
      /// </summary>
      void SetFocus();
   }
}
