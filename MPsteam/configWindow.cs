using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MpSteam
{
    public partial class configWindow : Form
    {
        ConfigReadWrite config = new ConfigReadWrite(@"D:\config.xml"); //TODO: PATH %PROGRAMDATA%/TeamMediaportal ..blabla
        public configWindow()
        {
            InitializeComponent();
        }

        private void configWindow_Load(object sender, EventArgs e)
        {
            if (config.ReadConfigItem("ManualSteamPath") == "true")
            {
                cB_SetSteamActivated.Checked = true;
            }

            if (config.ReadConfigItem("StartScript") == "true")
            {
                cB_StartScriptActivated.Checked = true;
            }

            if (config.ReadConfigItem("BigPictureMode") == "false")
            {
                cB_notBIG.Checked = true;
            }
            tB_script.Text = config.ReadConfigItem("StartScriptPath");
            tB_steam.Text = config.ReadConfigItem("SteamPath");
        }

        private void b_searchScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_script = new OpenFileDialog();
            openFileDialog_script.Filter = "Executable|*.exe;*.bat;*.vb";
            openFileDialog_script.Title = "Select an executable File";
            if (openFileDialog_script.ShowDialog() == DialogResult.OK)
            {
                if ((openFileDialog_script.OpenFile()) != null)
                {
                    tB_script.Text = openFileDialog_script.FileName;
                }
            }
        }

        private void b_SearchSteam_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_steam = new OpenFileDialog();
            openFileDialog_steam.Filter = "Steam|steam.exe";
            openFileDialog_steam.Title = "Select Steam.exe";
            if (openFileDialog_steam.ShowDialog() == DialogResult.OK)
            {
                if ((openFileDialog_steam.OpenFile()) != null)
                {
                    tB_steam.Text = openFileDialog_steam.FileName;
                }
            }
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (cB_SetSteamActivated.Checked == true)
            {
                config.WriteConfigItem("ManualSteamPath", "true");
            }
            else
            {
                config.WriteConfigItem("ManualSteamPath", "false");
            }

            if (cB_StartScriptActivated.Checked == true)
            {
                config.WriteConfigItem("StartScript", "true");
            }
            else
            {
                config.WriteConfigItem("StartScript", "false");
            }

            if (cB_notBIG.Checked == true)
            {
                config.WriteConfigItem("BigPictureMode", "false");
            }
            else
            {
                config.WriteConfigItem("BigPictureMode", "true");
            }

            config.WriteConfigItem("StartScriptPath", tB_script.Text);
            config.WriteConfigItem("SteamPath", tB_steam.Text);
            config.SaveConfig(@"D:\MPTEST\config.xml"); //TODO: PATH %PROGRAMDATA%/TeamMediaportal ..blabla
            this.Close();
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
