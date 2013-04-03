using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace MpSteam
{
    class ConfigReadWrite
    {
        List<ConfigItem> configItems = new List<ConfigItem>();

        /// <summary>
        /// Constructor: Reads the Config File from a specified Path and transfers the Items to a List.
        /// </summary>
        /// <param name="name">Path to the config file</param>
        public ConfigReadWrite()
        {
            string path = GetConfigPath();
            if (this.CheckFile(path)) //Check if File exists (TODO:and Validate XML)
            { this.ReadConfigFile(path); } //Read existing Config in list "configItems"
            else
            { this.CreateFile(path); } //Create Config File
        }

        private string GetConfigPath()
        {
            string result = "";
            if (Environment.OSVersion.Version.Major > 4 && Environment.OSVersion.Version.Minor > 1)
            {
                        result = Path.Combine(Environment.GetEnvironmentVariable("PUBLIC"), @"Team MediaPortal\MediaPortal\MPsteam.xml");
            }
                    else
            {
                        result = Path.Combine(Environment.GetEnvironmentVariable("ALLUSERSPROFILE"), @"Team MediaPortal\MediaPortal\MPsteam.xml");
            }
            return result;

        }

        /// <summary>
        /// Write a ConfigItem in List "configItems". If 'name' exists in the List, the value will be overwriten. If not a new configItem will be created
        /// </summary>
        /// <param name="name">Name of the configItem</param>
        /// <param name="value">Value of the configItem</param>
        public void WriteConfigItem(string name, string value)
        {
            bool exists = false;
            configItems.ForEach(delegate(ConfigItem ci)
            {
                if (ci.Name == name)
                {
                    ci.Value = value;
                    exists = true;
                }
            });
            if (!exists)
            {
                ConfigItem ci = new ConfigItem();
                ci.Name = name;
                ci.Value = value;
                this.configItems.Add(ci);
            }
        }

        /// <summary>
        /// Reads a specified ConfigItem in List "configItems".
        /// </summary>
        /// <param name="name">Name of the configItem</param>
        /// <returns>The Value of the Config Item as String.
        /// </returns>
        public string ReadConfigItem(string name)
        {
            string value = "null";
            configItems.ForEach(delegate(ConfigItem ci)
            {
                if (ci.Name == name)
                {
                    value = ci.Value.ToString();
                }
            });
            return value;
        }

        /// <summary>
        /// Saves the configItems List to the specified Path. When there is a existing config File values will be synced. The config file will be written in XML.
        /// </summary>
        /// <param name="path">Path to config file</param>
        public void SaveConfig()
        {
            string path = GetConfigPath();
            if (!this.CheckFile(path)) //Check if File exists (TODO:and Validate XML)
            { this.CreateFile(path); } //Create File if not

            XmlDocument ConfigFile = new XmlDocument();
            ConfigFile.Load(path);
            XmlNode Node = ConfigFile.DocumentElement;
            for (int i = configItems.Count - 1; i >= 0; i--)
            {
                bool NodeExists = false;
                foreach (XmlNode ConfigNode in Node.ChildNodes)
                {
                    if (configItems[i].Name == ConfigNode.Name)
                    {
                        NodeExists = true;
                        ConfigNode.InnerText = configItems[i].Value;
                    }
                }
                if (!NodeExists)
                {
                    XmlNode NewConfigNode = ConfigFile.CreateNode(XmlNodeType.Element, configItems[i].Name, null);
                    NewConfigNode.InnerText = configItems[i].Value;
                    Node.AppendChild(NewConfigNode);
                }
            }
            ConfigFile.Save(path);
        }

        private void CreateFile(string path)
        {
            string directory = new FileInfo(path).DirectoryName.ToString();
            if (!Directory.Exists(directory))
            {
                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler: Beim erzeugen der Konfig-Directory. Systemmeldung:" + ex.ToString());
                }
            }
            try
            {
                using (FileStream configFile = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?> \r\n <!-- \r\n This file stores information about the Configuration of the MediaPortal-Plugin MPSteam \r\n --> \r\n <Config> \r\n </Config>");
                    configFile.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: Beim erzeugen der Konfig-Datei. Systemmeldung:" + ex.ToString());
            }
        }

        private bool CheckFile(string path)
        {
            if (File.Exists(path))
            {
                //TODO: Validate XML File

                return true;
            }
            else
            {
                return false;
            }
        }

        private void ReadConfigFile(string path)
        {
            XmlDocument config = new XmlDocument();
            config.Load(path);
            XmlNode Node = config.DocumentElement;
            foreach (XmlNode ConfigNode in Node.ChildNodes)
            {
                //PROTOTYPE: Maybe, in a later version it is possible to store and write arrays
                //Therefore you need Nodes with multiple SubNodes/Children
                /* if (ConfigNode.HasChildNodes)
                 {
                     List<string> ConfigList = new List<string>();
                     foreach (XmlNode ConfigNodeChild in ConfigNode)
                     {
                         ConfigList.Add(ConfigNodeChild.InnerText);
                     }
                     ConfigItem ci = new ConfigItem();
                     ci.Name = ConfigNode.Name;
                     ci.List = ConfigList;
                     this.configItems.Add(ci);
                 }
                 else
                 { 
                     ConfigItem ci = new ConfigItem();
                     ci.Name = ConfigNode.Name;
                     ci.Value = ConfigNode.InnerText;
                     this.configItems.Add(ci);
                 }*/

                ConfigItem ci = new ConfigItem(); //Create ConfigItem
                ci.Name = ConfigNode.Name;      //Name it
                ci.Value = ConfigNode.InnerText; //Store Value
                this.configItems.Add(ci);       //Write it to ConfigItems List

            }
        }

        

        private class ConfigItem
        {
            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            private string _value;
            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }
            //PROTOTYPE: Possibility to store Arrays/lists. Maybe in later Version.
            /*
            private List<string> _list;
            public List<string> List
            {
                get { return _list; }
                set { _list = value; }
            }*/

        }




    }
}
