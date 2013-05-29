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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this.spin_delay = new System.Windows.Forms.NumericUpDown();
         this.label3 = new System.Windows.Forms.Label();
         this.tB_HomeMenuTitle = new System.Windows.Forms.TextBox();
         this.b_searchScript = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.tB_script = new System.Windows.Forms.TextBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.b_SearchSteam = new System.Windows.Forms.Button();
         this.cB_SetSteamActivated = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.tB_steam = new System.Windows.Forms.TextBox();
         this.b_cancel = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spin_delay)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // b_save
         // 
         this.b_save.Location = new System.Drawing.Point(230, 232);
         this.b_save.Name = "b_save";
         this.b_save.Size = new System.Drawing.Size(75, 23);
         this.b_save.TabIndex = 0;
         this.b_save.Text = "OK";
         this.b_save.UseVisualStyleBackColor = true;
         this.b_save.Click += new System.EventHandler(this.b_save_Click);
         // 
         // cB_notBIG
         // 
         this.cB_notBIG.AutoSize = true;
         this.cB_notBIG.Location = new System.Drawing.Point(9, 19);
         this.cB_notBIG.Name = "cB_notBIG";
         this.cB_notBIG.Size = new System.Drawing.Size(176, 17);
         this.cB_notBIG.TabIndex = 1;
         this.cB_notBIG.Text = "Start Steam in Big Picture Mode";
         this.cB_notBIG.UseVisualStyleBackColor = true;
         // 
         // cB_StartScriptActivated
         // 
         this.cB_StartScriptActivated.AutoSize = true;
         this.cB_StartScriptActivated.Location = new System.Drawing.Point(9, 42);
         this.cB_StartScriptActivated.Name = "cB_StartScriptActivated";
         this.cB_StartScriptActivated.Size = new System.Drawing.Size(244, 17);
         this.cB_StartScriptActivated.TabIndex = 4;
         this.cB_StartScriptActivated.Text = "Start script or executable before starting steam";
         this.cB_StartScriptActivated.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.spin_delay);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.tB_HomeMenuTitle);
         this.groupBox1.Controls.Add(this.b_searchScript);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.tB_script);
         this.groupBox1.Controls.Add(this.cB_StartScriptActivated);
         this.groupBox1.Location = new System.Drawing.Point(12, 112);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(293, 114);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Plugin";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 88);
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
         this.spin_delay.Location = new System.Drawing.Point(103, 85);
         this.spin_delay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
         this.spin_delay.Name = "spin_delay";
         this.spin_delay.Size = new System.Drawing.Size(137, 20);
         this.spin_delay.TabIndex = 11;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 19);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(91, 13);
         this.label3.TabIndex = 10;
         this.label3.Text = "Home Menu Title:";
         // 
         // tB_HomeMenuTitle
         // 
         this.tB_HomeMenuTitle.Location = new System.Drawing.Point(103, 16);
         this.tB_HomeMenuTitle.Name = "tB_HomeMenuTitle";
         this.tB_HomeMenuTitle.Size = new System.Drawing.Size(137, 20);
         this.tB_HomeMenuTitle.TabIndex = 9;
         // 
         // b_searchScript
         // 
         this.b_searchScript.Location = new System.Drawing.Point(247, 61);
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
         this.label2.Location = new System.Drawing.Point(6, 65);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(32, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "Path:";
         // 
         // tB_script
         // 
         this.tB_script.Location = new System.Drawing.Point(44, 62);
         this.tB_script.Name = "tB_script";
         this.tB_script.Size = new System.Drawing.Size(197, 20);
         this.tB_script.TabIndex = 5;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.b_SearchSteam);
         this.groupBox2.Controls.Add(this.cB_SetSteamActivated);
         this.groupBox2.Controls.Add(this.label1);
         this.groupBox2.Controls.Add(this.tB_steam);
         this.groupBox2.Controls.Add(this.cB_notBIG);
         this.groupBox2.Location = new System.Drawing.Point(12, 12);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(293, 94);
         this.groupBox2.TabIndex = 6;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Steam";
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
         this.b_cancel.Location = new System.Drawing.Point(149, 232);
         this.b_cancel.Name = "b_cancel";
         this.b_cancel.Size = new System.Drawing.Size(75, 23);
         this.b_cancel.TabIndex = 8;
         this.b_cancel.Text = "Cancel";
         this.b_cancel.UseVisualStyleBackColor = true;
         this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
         // 
         // configWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(317, 266);
         this.Controls.Add(this.b_cancel);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.b_save);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(333, 305);
         this.MinimumSize = new System.Drawing.Size(333, 305);
         this.Name = "configWindow";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "MPsteam Settings";
         this.Load += new System.EventHandler(this.configWindow_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spin_delay)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.CheckBox cB_notBIG;
        private System.Windows.Forms.CheckBox cB_StartScriptActivated;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_searchScript;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB_script;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cB_SetSteamActivated;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_steam;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tB_HomeMenuTitle;
        private System.Windows.Forms.Button b_SearchSteam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown spin_delay;
    }
}