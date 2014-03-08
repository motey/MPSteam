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
using System.IO;
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
         cB_SetSteamActivated.Checked = _configuration.OverrideSteamPath;
         cB_StartScriptActivated.Checked = _configuration.RunPreStartScript;
         cB_notBIG.Checked = _configuration.StartInBigPicture;
         tB_script.Text = _configuration.PreStartScriptPath;
         tB_steam.Text = _configuration.SteamPath;
         tB_HomeMenuTitle.Text = _configuration.HomeMenuTitle;
         spin_delay.Value = _configuration.PreStartScriptDelay;
      }

      private void b_searchScript_Click(object sender, EventArgs e)
      {
         OpenFileDialog openFileDialog_script = new OpenFileDialog();
         openFileDialog_script.Filter = "Executable|*.exe;*.bat;*.vbs";
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

      private void b_ok_Click(object sender, EventArgs e)
      {
         _configuration.OverrideSteamPath = cB_SetSteamActivated.Checked;
         _configuration.RunPreStartScript = cB_StartScriptActivated.Checked;
         _configuration.StartInBigPicture = cB_notBIG.Checked;
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
          if (cB_StartScriptActivated.Checked)
          {
              if (tB_script.Text == "" || !File.Exists(tB_script.Text))
              {
                  MessageBox.Show("Please specify a valid Path!");
                  cB_StartScriptActivated.Checked = false;
              }
          }
      }

      private void cB_SetSteamActivated_CheckedChanged(object sender, EventArgs e)
      {
          if (cB_SetSteamActivated.Checked)
          {
              if (tB_steam.Text == "" || !File.Exists(tB_steam.Text))
              {
                  MessageBox.Show("Please specify a valid Path!");
                  cB_SetSteamActivated.Checked = false;
              }
          }
      }

      ConfigurationVM _configuration;
   }
}
