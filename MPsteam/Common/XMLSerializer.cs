#region Copyright (C) 2014 MPsteam

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

using System;
using System.IO;
using System.Xml.Serialization;

namespace MPsteam.Helper
{
   public static class XMLSerializer
   {
      public static void Save(string configPath, object objectToSave)
      {
         using (TextWriter writer = new StreamWriter(configPath, false))
         {
            var serializer = new XmlSerializer(objectToSave.GetType());
            serializer.Serialize(writer, objectToSave);
         }         
      }

      public static object Load(string configPath, Type typeToLoad)
      {
         object loadedObject;   
         using (var fs = new FileStream(configPath, FileMode.Open))
         {  
            var serializer = new XmlSerializer(typeToLoad);
            serializer.UnknownNode += serializer_UnknownNode;
            serializer.UnknownAttribute += serializer_UnknownAttribute;
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
