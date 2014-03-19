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

namespace MPsteam
{
    partial class configWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configWindow));
         this.b_save = new System.Windows.Forms.Button();
         this.cB_notBIG = new System.Windows.Forms.CheckBox();
         this.cB_StartScriptActivated = new System.Windows.Forms.CheckBox();
         this.groupBoxMediaPortal = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.tB_HomeMenuTitle = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.spin_delay = new System.Windows.Forms.NumericUpDown();
         this.b_searchScript = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.tB_script = new System.Windows.Forms.TextBox();
         this.groupBoxSteam = new System.Windows.Forms.GroupBox();
         this.b_SearchSteam = new System.Windows.Forms.Button();
         this.cB_SetSteamActivated = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.tB_steam = new System.Windows.Forms.TextBox();
         this.b_cancel = new System.Windows.Forms.Button();
         this.groupBoxScript = new System.Windows.Forms.GroupBox();
         this.cB_SuspendMP = new System.Windows.Forms.CheckBox();
         this.groupBoxMediaPortal.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spin_delay)).BeginInit();
         this.groupBoxSteam.SuspendLayout();
         this.groupBoxScript.SuspendLayout();
         this.SuspendLayout();
         // 
         // b_save
         // 
         this.b_save.Location = new System.Drawing.Point(230, 280);
         this.b_save.Name = "b_save";
         this.b_save.Size = new System.Drawing.Size(75, 23);
         this.b_save.TabIndex = 0;
         this.b_save.Text = "OK";
         this.b_save.UseVisualStyleBackColor = true;
         this.b_save.Click += new System.EventHandler(this.b_ok_Click);
         // 
         // cB_notBIG
         // 
         this.cB_notBIG.AutoSize = true;
         this.cB_notBIG.Location = new System.Drawing.Point(9, 19);
         this.cB_notBIG.Name = "cB_notBIG";
         this.cB_notBIG.Size = new System.Drawing.Size(140, 17);
         this.cB_notBIG.TabIndex = 1;
         this.cB_notBIG.Text = "Start in big picture mode";
         this.cB_notBIG.UseVisualStyleBackColor = true;
         // 
         // cB_StartScriptActivated
         // 
         this.cB_StartScriptActivated.AutoSize = true;
         this.cB_StartScriptActivated.Location = new System.Drawing.Point(9, 20);
         this.cB_StartScriptActivated.Name = "cB_StartScriptActivated";
         this.cB_StartScriptActivated.Size = new System.Drawing.Size(175, 17);
         this.cB_StartScriptActivated.TabIndex = 4;
         this.cB_StartScriptActivated.Text = "Run script before starting steam";
         this.cB_StartScriptActivated.UseVisualStyleBackColor = true;
         this.cB_StartScriptActivated.CheckedChanged += new System.EventHandler(this.cB_StartScriptActivated_CheckedChanged);
         // 
         // groupBoxMediaPortal
         // 
         this.groupBoxMediaPortal.Controls.Add(this.label3);
         this.groupBoxMediaPortal.Controls.Add(this.cB_SuspendMP);
         this.groupBoxMediaPortal.Controls.Add(this.tB_HomeMenuTitle);
         this.groupBoxMediaPortal.Location = new System.Drawing.Point(12, 112);
         this.groupBoxMediaPortal.Name = "groupBoxMediaPortal";
         this.groupBoxMediaPortal.Size = new System.Drawing.Size(293, 63);
         this.groupBoxMediaPortal.TabIndex = 5;
         this.groupBoxMediaPortal.TabStop = false;
         this.groupBoxMediaPortal.Text = "MediaPortal";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 19);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(86, 13);
         this.label3.TabIndex = 10;
         this.label3.Text = "Home menu title:";
         // 
         // tB_HomeMenuTitle
         // 
         this.tB_HomeMenuTitle.Location = new System.Drawing.Point(103, 16);
         this.tB_HomeMenuTitle.Name = "tB_HomeMenuTitle";
         this.tB_HomeMenuTitle.Size = new System.Drawing.Size(137, 20);
         this.tB_HomeMenuTitle.TabIndex = 9;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 66);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(59, 13);
         this.label4.TabIndex = 12;
         this.label4.Text = "Delay (ms):";
         // 
         // spin_delay
         // 
         this.spin_delay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
         this.spin_delay.Location = new System.Drawing.Point(104, 63);
         this.spin_delay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
         this.spin_delay.Name = "spin_delay";
         this.spin_delay.Size = new System.Drawing.Size(137, 20);
         this.spin_delay.TabIndex = 11;
         // 
         // b_searchScript
         // 
         this.b_searchScript.Location = new System.Drawing.Point(247, 38);
         this.b_searchScript.Name = "b_searchScript";
         this.b_searchScript.Size = new System.Drawing.Size(40, 23);
         this.b_searchScript.TabIndex = 7;
         this.b_searchScript.Text = "...";
         this.b_searchScript.UseVisualStyleBackColor = true;
         this.b_searchScript.Click += new System.EventHandler(this.b_searchScript_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 43);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(32, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "Path:";
         // 
         // tB_script
         // 
         this.tB_script.Location = new System.Drawing.Point(44, 40);
         this.tB_script.Name = "tB_script";
         this.tB_script.Size = new System.Drawing.Size(197, 20);
         this.tB_script.TabIndex = 5;
         // 
         // groupBoxSteam
         // 
         this.groupBoxSteam.Controls.Add(this.b_SearchSteam);
         this.groupBoxSteam.Controls.Add(this.cB_SetSteamActivated);
         this.groupBoxSteam.Controls.Add(this.label1);
         this.groupBoxSteam.Controls.Add(this.tB_steam);
         this.groupBoxSteam.Controls.Add(this.cB_notBIG);
         this.groupBoxSteam.Location = new System.Drawing.Point(12, 12);
         this.groupBoxSteam.Name = "groupBoxSteam";
         this.groupBoxSteam.Size = new System.Drawing.Size(293, 94);
         this.groupBoxSteam.TabIndex = 6;
         this.groupBoxSteam.TabStop = false;
         this.groupBoxSteam.Text = "Steam";
         // 
         // b_SearchSteam
         // 
         this.b_SearchSteam.Location = new System.Drawing.Point(247, 63);
         this.b_SearchSteam.Name = "b_SearchSteam";
         this.b_SearchSteam.Size = new System.Drawing.Size(40, 23);
         this.b_SearchSteam.TabIndex = 8;
         this.b_SearchSteam.Text = "...";
         this.b_SearchSteam.UseVisualStyleBackColor = true;
         this.b_SearchSteam.Click += new System.EventHandler(this.b_SearchSteam_Click);
         // 
         // cB_SetSteamActivated
         // 
         this.cB_SetSteamActivated.AutoSize = true;
         this.cB_SetSteamActivated.Location = new System.Drawing.Point(9, 42);
         this.cB_SetSteamActivated.Name = "cB_SetSteamActivated";
         this.cB_SetSteamActivated.Size = new System.Drawing.Size(183, 17);
         this.cB_SetSteamActivated.TabIndex = 9;
         this.cB_SetSteamActivated.Text = "Set path to \"steam.exe\" manually";
         this.cB_SetSteamActivated.UseVisualStyleBackColor = true;
         this.cB_SetSteamActivated.CheckedChanged += new System.EventHandler(this.cB_SetSteamActivated_CheckedChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 68);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 13);
         this.label1.TabIndex = 7;
         this.label1.Text = "Path:";
         // 
         // tB_steam
         // 
         this.tB_steam.Location = new System.Drawing.Point(44, 65);
         this.tB_steam.Name = "tB_steam";
         this.tB_steam.Size = new System.Drawing.Size(197, 20);
         this.tB_steam.TabIndex = 0;
         // 
         // b_cancel
         // 
         this.b_cancel.Location = new System.Drawing.Point(149, 280);
         this.b_cancel.Name = "b_cancel";
         this.b_cancel.Size = new System.Drawing.Size(75, 23);
         this.b_cancel.TabIndex = 8;
         this.b_cancel.Text = "Cancel";
         this.b_cancel.UseVisualStyleBackColor = true;
         this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
         // 
         // groupBoxScript
         // 
         this.groupBoxScript.Controls.Add(this.tB_script);
         this.groupBoxScript.Controls.Add(this.cB_StartScriptActivated);
         this.groupBoxScript.Controls.Add(this.label4);
         this.groupBoxScript.Controls.Add(this.label2);
         this.groupBoxScript.Controls.Add(this.spin_delay);
         this.groupBoxScript.Controls.Add(this.b_searchScript);
         this.groupBoxScript.Location = new System.Drawing.Point(12, 182);
         this.groupBoxScript.Name = "groupBoxScript";
         this.groupBoxScript.Size = new System.Drawing.Size(293, 92);
         this.groupBoxScript.TabIndex = 9;
         this.groupBoxScript.TabStop = false;
         this.groupBoxScript.Text = "Script";
         // 
         // cB_SuspendMP
         // 
         this.cB_SuspendMP.AutoSize = true;
         this.cB_SuspendMP.Location = new System.Drawing.Point(9, 42);
         this.cB_SuspendMP.Name = "cB_SuspendMP";
         this.cB_SuspendMP.Size = new System.Drawing.Size(228, 17);
         this.cB_SuspendMP.TabIndex = 4;
         this.cB_SuspendMP.Text = "Suspend MediaPortal before starting steam";
         this.cB_SuspendMP.UseVisualStyleBackColor = true;
         this.cB_SuspendMP.CheckedChanged += new System.EventHandler(this.cB_StartScriptActivated_CheckedChanged);
         // 
         // configWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(317, 312);
         this.Controls.Add(this.b_cancel);
         this.Controls.Add(this.groupBoxSteam);
         this.Controls.Add(this.groupBoxMediaPortal);
         this.Controls.Add(this.b_save);
         this.Controls.Add(this.groupBoxScript);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(333, 350);
         this.MinimumSize = new System.Drawing.Size(333, 350);
         this.Name = "configWindow";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "MPsteam Configuration";
         this.Load += new System.EventHandler(this.configWindow_Load);
         this.groupBoxMediaPortal.ResumeLayout(false);
         this.groupBoxMediaPortal.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spin_delay)).EndInit();
         this.groupBoxSteam.ResumeLayout(false);
         this.groupBoxSteam.PerformLayout();
         this.groupBoxScript.ResumeLayout(false);
         this.groupBoxScript.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.CheckBox cB_notBIG;
        private System.Windows.Forms.CheckBox cB_StartScriptActivated;
        private System.Windows.Forms.GroupBox groupBoxMediaPortal;
        private System.Windows.Forms.Button b_searchScript;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB_script;
        private System.Windows.Forms.GroupBox groupBoxSteam;
        private System.Windows.Forms.CheckBox cB_SetSteamActivated;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_steam;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_HomeMenuTitle;
        private System.Windows.Forms.Button b_SearchSteam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown spin_delay;
        private System.Windows.Forms.GroupBox groupBoxScript;
        private System.Windows.Forms.CheckBox cB_SuspendMP;
    }
}