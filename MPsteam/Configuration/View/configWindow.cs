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
using System.Windows.Forms;
using MPsteam.Configuration;

namespace MPsteam
{
   public partial class configWindow : Form
   {
      public configWindow(ConfigurationVM configuration)
      {
         _configuration = configuration;
         InitializeComponent();
      }

      public ConfigurationVM GetResult()
      {
         return _configuration;
      }

      private void configWindow_Load(object sender, EventArgs e)
      {
         Text = _configuration.Title;
         cB_SetSteamActivated.Checked = _configuration.OverrideSteamPath;
         cB_StartScriptActivated.Checked = _configuration.RunPreStartScript;
         cB_notBIG.Checked = _configuration.StartInBigPicture;
         cB_SuspendMP.Checked = _configuration.SuspendMediaPortal;
         tB_script.Text = _configuration.PreStartScriptPath;
         tB_steam.Text = _configuration.SteamPath;
         tB_HomeMenuTitle.Text = _configuration.HomeMenuTitle;
         spin_delay.Value = _configuration.PreStartScriptDelay;

         //enable/disable text boxes
         tB_script.Enabled = cB_StartScriptActivated.Checked;
         b_searchScript.Enabled = cB_StartScriptActivated.Checked;
         tB_steam.Enabled = cB_SetSteamActivated.Checked;
         b_SearchSteam.Enabled = cB_SetSteamActivated.Checked;
      }

      private void b_searchScript_Click(object sender, EventArgs e)
      {
         var openFileDialog_script = new OpenFileDialog
         {
            Filter = "Executable|*.exe;*.bat;*.vbs",
            Title = "Select an executable File"
         };

         if (openFileDialog_script.ShowDialog() == DialogResult.OK)
         {
            if ((openFileDialog_script.OpenFile().CanRead))
            {
               tB_script.Text = openFileDialog_script.FileName;
            }
         }
      }

      private void b_SearchSteam_Click(object sender, EventArgs e)
      {
         var openFileDialog_steam = new OpenFileDialog
         {
            Filter = "Steam|steam.exe", Title = "Select Steam.exe"
         };

         if (openFileDialog_steam.ShowDialog() == DialogResult.OK)
         {
            if ((openFileDialog_steam.OpenFile().CanRead))
            {
               tB_steam.Text = openFileDialog_steam.FileName;
            }
         }
      }

      private void b_ok_Click(object sender, EventArgs e)
      {
         _configuration.OverrideSteamPath = cB_SetSteamActivated.Checked;
         _configuration.RunPreStartScript = cB_StartScriptActivated.Checked;
         _configuration.StartInBigPicture = cB_notBIG.Checked;
         _configuration.SuspendMediaPortal = cB_SuspendMP.Checked;
         _configuration.SteamPath = tB_steam.Text;
         _configuration.PreStartScriptPath = tB_script.Text;
         _configuration.HomeMenuTitle = tB_HomeMenuTitle.Text;
         _configuration.PreStartScriptDelay = decimal.ToInt32(spin_delay.Value);
         

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void b_cancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      private void cB_StartScriptActivated_CheckedChanged(object sender, EventArgs e)
      {
         tB_script.Enabled = cB_StartScriptActivated.Checked;
         b_searchScript.Enabled = cB_StartScriptActivated.Checked;
      }

      private void cB_SetSteamActivated_CheckedChanged(object sender, EventArgs e)
      {
         tB_steam.Enabled = cB_SetSteamActivated.Checked;
         b_SearchSteam.Enabled = cB_SetSteamActivated.Checked;
      }

      readonly ConfigurationVM _configuration;
   }
}
