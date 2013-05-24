using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MpSteam
{
   [XmlRootAttribute("MPsteamConfiguration")]
   public class ConfigurationModel
   {
      public ConfigurationModel()
      {
         //Set defaults
         StartInBigPicture = true;
         RunPreStartScript = false;
         OverrideSteamPath = false;
         SteamPath = String.Empty;
         ScriptPath = String.Empty;
         ScriptDelay = 0;
         HomeMenuTitle = "Start Steam";
      }

      [XmlElementAttribute("BigPictureMode")]
      public bool StartInBigPicture { get; set; }
      [XmlElementAttribute("ScriptActive")]
      public bool RunPreStartScript { get; set; }
      public string ScriptPath { get; set; }
      public int ScriptDelay { get; set; }
      public bool OverrideSteamPath { get; set; }
      public string SteamPath { get; set; }
      public string HomeMenuTitle { get; set; }
   }
}
