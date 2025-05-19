namespace CasinoWindowsForms
{
    partial class LoginForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.gbRegisterLink = new System.Windows.Forms.GroupBox();
            this.lblNoAccount = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gbLogin.SuspendLayout();
            this.gbRegisterLink.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(40, 46);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(155, 32);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F);
            this.lblPassword.Location = new System.Drawing.Point(40, 124);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(150, 32);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // gbLogin
            // 
            this.gbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbLogin.Controls.Add(this.tbxPassword);
            this.gbLogin.Controls.Add(this.tbxUsername);
            this.gbLogin.Controls.Add(this.lblUsername);
            this.gbLogin.Controls.Add(this.lblPassword);
            this.gbLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLogin.Location = new System.Drawing.Point(200, 100);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(873, 239);
            this.gbLogin.TabIndex = 7;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login";
            // 
            // gbRegisterLink
            // 
            this.gbRegisterLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRegisterLink.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbRegisterLink.Controls.Add(this.lblRegister);
            this.gbRegisterLink.Controls.Add(this.lblNoAccount);
            this.gbRegisterLink.Location = new System.Drawing.Point(200, 345);
            this.gbRegisterLink.Name = "gbRegisterLink";
            this.gbRegisterLink.Size = new System.Drawing.Size(873, 116);
            this.gbRegisterLink.TabIndex = 8;
            this.gbRegisterLink.TabStop = false;
            // 
            // lblNoAccount
            // 
            this.lblNoAccount.AutoSize = true;
            this.lblNoAccount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.lblNoAccount.Location = new System.Drawing.Point(6, 18);
            this.lblNoAccount.Name = "lblNoAccount";
            this.lblNoAccount.Size = new System.Drawing.Size(237, 23);
            this.lblNoAccount.TabIndex = 9;
            this.lblNoAccount.Text = "Don\'t have an account?";
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegister.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRegister.Location = new System.Drawing.Point(264, 18);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(163, 23);
            this.lblRegister.TabIndex = 10;
            this.lblRegister.Text = "Create Account";
            this.lblRegister.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbxUsername
            // 
            this.tbxUsername.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbxUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F);
            this.tbxUsername.Location = new System.Drawing.Point(46, 82);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(361, 39);
            this.tbxUsername.TabIndex = 9;
            // 
            // tbxPassword
            // 
            this.tbxPassword.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbxPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F);
            this.tbxPassword.Location = new System.Drawing.Point(46, 159);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '♠';
            this.tbxPassword.Size = new System.Drawing.Size(361, 39);
            this.tbxPassword.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1169, 624);
            this.Controls.Add(this.gbRegisterLink);
            this.Controls.Add(this.gbLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbRegisterLink.ResumeLayout(false);
            this.gbRegisterLink.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.GroupBox gbRegisterLink;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label lblNoAccount;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

