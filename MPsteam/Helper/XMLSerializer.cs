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
