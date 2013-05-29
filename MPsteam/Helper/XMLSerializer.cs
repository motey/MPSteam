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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MpSteam
{
   public static class XMLSerializer
   {
      public static void Save(string configPath, object objectToSave)
      {
         using (TextWriter writer = new StreamWriter(configPath, false))
         {
            XmlSerializer serializer = new XmlSerializer(objectToSave.GetType());
            serializer.Serialize(writer, objectToSave);
         }         
      }

      public static object Load(string configPath, Type typeToLoad)
      {
         object loadedObject;   
         using (FileStream fs = new FileStream(configPath, FileMode.Open))
         {  
            XmlSerializer serializer = new XmlSerializer(typeToLoad);
            serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
            serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
            loadedObject = serializer.Deserialize(fs);
         }
         return loadedObject;      
      }

      private static void serializer_UnknownNode (object sender, XmlNodeEventArgs e)
      {
         //TODO: Log4Net here?
         Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
      }

      private static void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
      {
         //TODO: Log4Net here?
         System.Xml.XmlAttribute attr = e.Attr;
         Console.WriteLine("Unknown attribute " +
         attr.Name + "='" + attr.Value + "'");
      }
   }
}
