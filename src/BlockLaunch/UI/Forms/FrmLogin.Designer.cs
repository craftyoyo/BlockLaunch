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
            this.lblEmail = new MetroFramework.Controls.MetroLabel();
            this.lblPassword = new MetroFramework.Controls.MetroLabel();
            this.lblProfilName = new MetroFramework.Controls.MetroLabel();
            this.txbUser = new MetroFramework.Controls.MetroTextBox();
            this.txbPassword = new MetroFramework.Controls.MetroTextBox();
            this.txbProfileName = new MetroFramework.Controls.MetroTextBox();
            this.linkBuyMinecraft = new MetroFramework.Controls.MetroLink();
            this.cmdLogin = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(23, 30);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 19);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "E-Mail: ";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(23, 59);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(71, 19);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password: ";
            // 
            // lblProfilName
            // 
            this.lblProfilName.AutoSize = true;
            this.lblProfilName.Location = new System.Drawing.Point(23, 88);
            this.lblProfilName.Name = "lblProfilName";
            this.lblProfilName.Size = new System.Drawing.Size(96, 19);
            this.lblProfilName.TabIndex = 10;
            this.lblProfilName.Text = "Profile-Name: ";
            // 
            // txbUser
            // 
            this.txbUser.Lines = new string[0];
            this.txbUser.Location = new System.Drawing.Point(125, 26);
            this.txbUser.MaxLength = 32767;
            this.txbUser.Name = "txbUser";
            this.txbUser.PasswordChar = '\0';
            this.txbUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbUser.SelectedText = "";
            this.txbUser.Size = new System.Drawing.Size(347, 23);
            this.txbUser.TabIndex = 11;
            this.txbUser.UseSelectable = true;
            // 
            // txbPassword
            // 
            this.txbPassword.Lines = new string[0];
            this.txbPassword.Location = new System.Drawing.Point(125, 55);
            this.txbPassword.MaxLength = 32767;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '●';
            this.txbPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbPassword.SelectedText = "";
            this.txbPassword.Size = new System.Drawing.Size(347, 23);
            this.txbPassword.TabIndex = 12;
            this.txbPassword.UseSelectable = true;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // txbProfileName
            // 
            this.txbProfileName.Lines = new string[0];
            this.txbProfileName.Location = new System.Drawing.Point(125, 84);
            this.txbProfileName.MaxLength = 32767;
            this.txbProfileName.Name = "txbProfileName";
            this.txbProfileName.PasswordChar = '\0';
            this.txbProfileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbProfileName.SelectedText = "";
            this.txbProfileName.Size = new System.Drawing.Size(347, 23);
            this.txbProfileName.TabIndex = 13;
            this.txbProfileName.UseSelectable = true;
            // 
            // linkBuyMinecraft
            // 
            this.linkBuyMinecraft.Location = new System.Drawing.Point(23, 113);
            this.linkBuyMinecraft.Name = "linkBuyMinecraft";
            this.linkBuyMinecraft.Size = new System.Drawing.Size(172, 23);
            this.linkBuyMinecraft.TabIndex = 14;
            this.linkBuyMinecraft.Text = "Need an account? Click here!";
            this.linkBuyMinecraft.UseSelectable = true;
            this.linkBuyMinecraft.Click += new System.EventHandler(this.linkBuyMinecraft_Click);
            // 
            // cmdLogin
            // 
            this.cmdLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdLogin.Location = new System.Drawing.Point(23, 142);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(449, 23);
            this.cmdLogin.TabIndex = 15;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.UseSelectable = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 179);
            this.Controls.Add(this.cmdLogin);
            this.Controls.Add(this.linkBuyMinecraft);
            this.Controls.Add(this.txbProfileName);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbUser);
            this.Controls.Add(this.lblProfilName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShowIcon = false;
            this.Text = "BlockLaunch - v. Alpha - Einloggen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblEmail;
        private MetroFramework.Controls.MetroLabel lblPassword;
        private MetroFramework.Controls.MetroLabel lblProfilName;
        private MetroFramework.Controls.MetroTextBox txbUser;
        private MetroFramework.Controls.MetroTextBox txbPassword;
        private MetroFramework.Controls.MetroTextBox txbProfileName;
        private MetroFramework.Controls.MetroLink linkBuyMinecraft;
        private MetroFramework.Controls.MetroButton cmdLogin;

    }
}