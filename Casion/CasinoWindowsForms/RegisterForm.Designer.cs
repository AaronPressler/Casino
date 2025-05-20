namespace CasinoWindowsForms
{
    partial class RegisterForm
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
            this.gbRegisterLink = new System.Windows.Forms.GroupBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblAlreadyAccount = new System.Windows.Forms.Label();
            this.gbRegister = new System.Windows.Forms.GroupBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gbRegisterLink.SuspendLayout();
            this.gbRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRegisterLink
            // 
            this.gbRegisterLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRegisterLink.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbRegisterLink.Controls.Add(this.lblLogin);
            this.gbRegisterLink.Controls.Add(this.lblAlreadyAccount);
            this.gbRegisterLink.Location = new System.Drawing.Point(35, 421);
            this.gbRegisterLink.Name = "gbRegisterLink";
            this.gbRegisterLink.Size = new System.Drawing.Size(606, 58);
            this.gbRegisterLink.TabIndex = 10;
            this.gbRegisterLink.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLogin.Location = new System.Drawing.Point(264, 18);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(64, 23);
            this.lblLogin.TabIndex = 10;
            this.lblLogin.Text = "Login";
            // 
            // lblAlreadyAccount
            // 
            this.lblAlreadyAccount.AutoSize = true;
            this.lblAlreadyAccount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.lblAlreadyAccount.Location = new System.Drawing.Point(6, 18);
            this.lblAlreadyAccount.Name = "lblAlreadyAccount";
            this.lblAlreadyAccount.Size = new System.Drawing.Size(262, 23);
            this.lblAlreadyAccount.TabIndex = 9;
            this.lblAlreadyAccount.Text = "Already have an account?";
            // 
            // gbRegister
            // 
            this.gbRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbRegister.Controls.Add(this.btnRegister);
            this.gbRegister.Controls.Add(this.dateTimePicker1);
            this.gbRegister.Controls.Add(this.lblDateTime);
            this.gbRegister.Controls.Add(this.tbxPassword);
            this.gbRegister.Controls.Add(this.tbxUsername);
            this.gbRegister.Controls.Add(this.lblUsername);
            this.gbRegister.Controls.Add(this.lblPassword);
            this.gbRegister.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRegister.Location = new System.Drawing.Point(35, 31);
            this.gbRegister.Name = "gbRegister";
            this.gbRegister.Size = new System.Drawing.Size(606, 384);
            this.gbRegister.TabIndex = 9;
            this.gbRegister.TabStop = false;
            this.gbRegister.Text = "Register";
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.Location = new System.Drawing.Point(429, 334);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(171, 44);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(46, 236);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(361, 39);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F);
            this.lblDateTime.Location = new System.Drawing.Point(40, 201);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(354, 32);
            this.lblDateTime.TabIndex = 12;
            this.lblDateTime.Text = "Birthdate (18+ Required)";
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
            // tbxUsername
            // 
            this.tbxUsername.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbxUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F);
            this.tbxUsername.Location = new System.Drawing.Point(46, 82);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(361, 39);
            this.tbxUsername.TabIndex = 9;
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
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1189, 664);
            this.Controls.Add(this.gbRegisterLink);
            this.Controls.Add(this.gbRegister);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.gbRegisterLink.ResumeLayout(false);
            this.gbRegisterLink.PerformLayout();
            this.gbRegister.ResumeLayout(false);
            this.gbRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRegisterLink;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblAlreadyAccount;
        private System.Windows.Forms.GroupBox gbRegister;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnRegister;
    }
}