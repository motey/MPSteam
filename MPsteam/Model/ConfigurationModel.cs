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
         PreStartScriptPath = String.Empty;
      }

      [XmlElementAttribute("BigPictureMode")]
      public bool StartInBigPicture { get; set; }
      [XmlElementAttribute("ScriptActive")]
      public bool RunPreStartScript { get; set; }
      [XmlElementAttribute("ScriptPath")]
      public string PreStartScriptPath { get; set; }
      [XmlElementAttribute("OverrideSteamPath")]
      public bool OverrideSteamPath { get; set; }
      [XmlElementAttribute("SteamPath")]
      public string SteamPath { get; set; }
   }
}
