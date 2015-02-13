namespace BlockLaunch.UI.Forms
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.ckbShowAlpha = new System.Windows.Forms.CheckBox();
            this.ckbShowBeta = new System.Windows.Forms.CheckBox();
            this.ckbShowSnapshot = new System.Windows.Forms.CheckBox();
            this.nudMemory = new System.Windows.Forms.NumericUpDown();
            this.lblMemory = new System.Windows.Forms.Label();
            this.ckbCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.ckbUseFullscreenMode = new System.Windows.Forms.CheckBox();
            this.cmdSaveSettings = new System.Windows.Forms.Button();
            this.ckbAllowLocalVersions = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).BeginInit();
            this.SuspendLayout();
            // 
            // ckbShowAlpha
            // 
            this.ckbShowAlpha.AutoSize = true;
            this.ckbShowAlpha.Location = new System.Drawing.Point(12, 12);
            this.ckbShowAlpha.Name = "ckbShowAlpha";
            this.ckbShowAlpha.Size = new System.Drawing.Size(149, 17);
            this.ckbShowAlpha.TabIndex = 0;
            this.ckbShowAlpha.Text = "Alpha-Versionen anzeigen";
            this.ckbShowAlpha.UseVisualStyleBackColor = true;
            // 
            // ckbShowBeta
            // 
            this.ckbShowBeta.AutoSize = true;
            this.ckbShowBeta.Location = new System.Drawing.Point(12, 35);
            this.ckbShowBeta.Name = "ckbShowBeta";
            this.ckbShowBeta.Size = new System.Drawing.Size(144, 17);
            this.ckbShowBeta.TabIndex = 1;
            this.ckbShowBeta.Text = "Beta-Versionen anzeigen";
            this.ckbShowBeta.UseVisualStyleBackColor = true;
            // 
            // ckbShowSnapshot
            // 
            this.ckbShowSnapshot.AutoSize = true;
            this.ckbShowSnapshot.Location = new System.Drawing.Point(12, 58);
            this.ckbShowSnapshot.Name = "ckbShowSnapshot";
            this.ckbShowSnapshot.Size = new System.Drawing.Size(167, 17);
            this.ckbShowSnapshot.TabIndex = 2;
            this.ckbShowSnapshot.Text = "Snapshot-Versionen anzeigen";
            this.ckbShowSnapshot.UseVisualStyleBackColor = true;
            // 
            // nudMemory
            // 
            this.nudMemory.Location = new System.Drawing.Point(129, 81);
            this.nudMemory.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudMemory.Name = "nudMemory";
            this.nudMemory.Size = new System.Drawing.Size(63, 20);
            this.nudMemory.TabIndex = 3;
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Location = new System.Drawing.Point(12, 83);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(111, 13);
            this.lblMemory.TabIndex = 4;
            this.lblMemory.Text = "Arbeitsspeicher in GB:";
            // 
            // ckbCheckForUpdates
            // 
            this.ckbCheckForUpdates.AutoSize = true;
            this.ckbCheckForUpdates.Location = new System.Drawing.Point(211, 12);
            this.ckbCheckForUpdates.Name = "ckbCheckForUpdates";
            this.ckbCheckForUpdates.Size = new System.Drawing.Size(168, 17);
            this.ckbCheckForUpdates.TabIndex = 5;
            this.ckbCheckForUpdates.Text = "Beim Start auf Updates prüfen";
            this.ckbCheckForUpdates.UseVisualStyleBackColor = true;
            // 
            // ckbUseFullscreenMode
            // 
            this.ckbUseFullscreenMode.AutoSize = true;
            this.ckbUseFullscreenMode.Location = new System.Drawing.Point(211, 35);
            this.ckbUseFullscreenMode.Name = "ckbUseFullscreenMode";
            this.ckbUseFullscreenMode.Size = new System.Drawing.Size(146, 17);
            this.ckbUseFullscreenMode.TabIndex = 6;
            this.ckbUseFullscreenMode.Text = "Vollbildmodus verwenden";
            this.ckbUseFullscreenMode.UseVisualStyleBackColor = true;
            // 
            // cmdSaveSettings
            // 
            this.cmdSaveSettings.Location = new System.Drawing.Point(15, 107);
            this.cmdSaveSettings.Name = "cmdSaveSettings";
            this.cmdSaveSettings.Size = new System.Drawing.Size(361, 23);
            this.cmdSaveSettings.TabIndex = 7;
            this.cmdSaveSettings.Text = "Einstellungen speichern";
            this.cmdSaveSettings.UseVisualStyleBackColor = true;
            // 
            // ckbAllowLocalVersions
            // 
            this.ckbAllowLocalVersions.AutoSize = true;
            this.ckbAllowLocalVersions.Location = new System.Drawing.Point(211, 58);
            this.ckbAllowLocalVersions.Name = "ckbAllowLocalVersions";
            this.ckbAllowLocalVersions.Size = new System.Drawing.Size(152, 17);
            this.ckbAllowLocalVersions.TabIndex = 8;
            this.ckbAllowLocalVersions.Text = "Lokale Versionen erlauben";
            this.ckbAllowLocalVersions.UseVisualStyleBackColor = true;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 142);
            this.Controls.Add(this.ckbAllowLocalVersions);
            this.Controls.Add(this.cmdSaveSettings);
            this.Controls.Add(this.ckbUseFullscreenMode);
            this.Controls.Add(this.ckbCheckForUpdates);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.nudMemory);
            this.Controls.Add(this.ckbShowSnapshot);
            this.Controls.Add(this.ckbShowBeta);
            this.Controls.Add(this.ckbShowAlpha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.Text = "BlockLaunch - v. Alpha - Einstellungen";
            ((System.ComponentModel.ISupportInitialize)(this.nudMemory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbShowAlpha;
        private System.Windows.Forms.CheckBox ckbShowBeta;
        private System.Windows.Forms.CheckBox ckbShowSnapshot;
        private System.Windows.Forms.NumericUpDown nudMemory;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.CheckBox ckbCheckForUpdates;
        private System.Windows.Forms.CheckBox ckbUseFullscreenMode;
        private System.Windows.Forms.Button cmdSaveSettings;
        private System.Windows.Forms.CheckBox ckbAllowLocalVersions;
    }
}