namespace BlockLaunch.UI.Forms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.cmdLogin = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbProfileName = new System.Windows.Forms.TextBox();
            this.lblProfilName = new System.Windows.Forms.Label();
            this.linkBuyMinecraft = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmdLogin
            // 
            this.cmdLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdLogin.Location = new System.Drawing.Point(15, 103);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(467, 23);
            this.cmdLogin.TabIndex = 0;
            this.cmdLogin.Text = "Einloggen";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 15);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "E-Mail:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 41);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Passwort:";
            // 
            // txbUser
            // 
            this.txbUser.Location = new System.Drawing.Point(57, 12);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(426, 20);
            this.txbUser.TabIndex = 3;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(71, 38);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(412, 20);
            this.txbPassword.TabIndex = 4;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // txbProfileName
            // 
            this.txbProfileName.Location = new System.Drawing.Point(82, 64);
            this.txbProfileName.Name = "txbProfileName";
            this.txbProfileName.Size = new System.Drawing.Size(401, 20);
            this.txbProfileName.TabIndex = 5;
            // 
            // lblProfilName
            // 
            this.lblProfilName.AutoSize = true;
            this.lblProfilName.Location = new System.Drawing.Point(12, 67);
            this.lblProfilName.Name = "lblProfilName";
            this.lblProfilName.Size = new System.Drawing.Size(64, 13);
            this.lblProfilName.TabIndex = 6;
            this.lblProfilName.Text = "Profil-Name:";
            // 
            // linkBuyMinecraft
            // 
            this.linkBuyMinecraft.AutoSize = true;
            this.linkBuyMinecraft.Location = new System.Drawing.Point(12, 87);
            this.linkBuyMinecraft.Name = "linkBuyMinecraft";
            this.linkBuyMinecraft.Size = new System.Drawing.Size(149, 13);
            this.linkBuyMinecraft.TabIndex = 7;
            this.linkBuyMinecraft.TabStop = true;
            this.linkBuyMinecraft.Text = "Need an account? Click here!";
            this.linkBuyMinecraft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBuyMinecraft_LinkClicked);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 136);
            this.Controls.Add(this.linkBuyMinecraft);
            this.Controls.Add(this.lblProfilName);
            this.Controls.Add(this.txbProfileName);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.cmdLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlockLaunch - v. Alpha - Einloggen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbProfileName;
        private System.Windows.Forms.Label lblProfilName;
        private System.Windows.Forms.LinkLabel linkBuyMinecraft;
    }
}