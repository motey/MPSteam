﻿using System;
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

        //Construktor
        public ConfigReadWrite(string path)
        {
            if (this.CheckFile(path)) //Check if File exists (TODO:and Validate XML)
            { this.ReadConfigFile(path); } //Read existing Config in list "configItems"
            else
            { this.CreateFile(path); } //Create Config File
        }


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

        public string ReadConfigItem(string name)
        {
            string value = "null";
            configItems.ForEach(delegate(ConfigItem ci)
            {
                if (ci.Name == name)
                {
                    value = ci.Value.ToString(); //TODO Test auf array oder string
                }
            });
            return value;
        }

        public void SaveConfig(string path)
        {
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
