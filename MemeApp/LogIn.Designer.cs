﻿namespace MemeApp
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.LblLogin = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtBoxUsername = new System.Windows.Forms.TextBox();
            this.TxtBoxPassword = new System.Windows.Forms.TextBox();
            this.BtnLogIn = new System.Windows.Forms.Button();
            this.LblIncorrectInput = new System.Windows.Forms.Label();
            this.BtnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblLogin
            // 
            this.LblLogin.AutoSize = true;
            this.LblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.LblLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblLogin.Location = new System.Drawing.Point(122, 181);
            this.LblLogin.Name = "LblLogin";
            this.LblLogin.Size = new System.Drawing.Size(183, 39);
            this.LblLogin.TabIndex = 0;
            this.LblLogin.Text = "Username:";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.LblPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblPassword.Location = new System.Drawing.Point(122, 263);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(176, 39);
            this.LblPassword.TabIndex = 1;
            this.LblPassword.Text = "Password:";
            // 
            // TxtBoxUsername
            // 
            this.TxtBoxUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.TxtBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.TxtBoxUsername.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtBoxUsername.Location = new System.Drawing.Point(334, 181);
            this.TxtBoxUsername.MaxLength = 120;
            this.TxtBoxUsername.Name = "TxtBoxUsername";
            this.TxtBoxUsername.Size = new System.Drawing.Size(506, 45);
            this.TxtBoxUsername.TabIndex = 2;
            // 
            // TxtBoxPassword
            // 
            this.TxtBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.TxtBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.TxtBoxPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtBoxPassword.Location = new System.Drawing.Point(334, 263);
            this.TxtBoxPassword.MaxLength = 120;
            this.TxtBoxPassword.Name = "TxtBoxPassword";
            this.TxtBoxPassword.Size = new System.Drawing.Size(506, 45);
            this.TxtBoxPassword.TabIndex = 3;
            this.TxtBoxPassword.UseSystemPasswordChar = true;
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.BtnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.BtnLogIn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnLogIn.Location = new System.Drawing.Point(334, 342);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(250, 45);
            this.BtnLogIn.TabIndex = 4;
            this.BtnLogIn.Text = "Log in";
            this.BtnLogIn.UseVisualStyleBackColor = false;
            this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click);
            // 
            // LblIncorrectInput
            // 
            this.LblIncorrectInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LblIncorrectInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblIncorrectInput.Location = new System.Drawing.Point(334, 430);
            this.LblIncorrectInput.Name = "LblIncorrectInput";
            this.LblIncorrectInput.Size = new System.Drawing.Size(506, 40);
            this.LblIncorrectInput.TabIndex = 5;
            this.LblIncorrectInput.Text = "Incorrect login or password";
            this.LblIncorrectInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblIncorrectInput.Visible = false;
            // 
            // BtnRegister
            // 
            this.BtnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.BtnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.BtnRegister.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnRegister.Location = new System.Drawing.Point(590, 342);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(250, 45);
            this.BtnRegister.TabIndex = 6;
            this.BtnRegister.Text = "Register";
            this.BtnRegister.UseVisualStyleBackColor = false;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.BtnRegister);
            this.Controls.Add(this.LblIncorrectInput);
            this.Controls.Add(this.BtnLogIn);
            this.Controls.Add(this.TxtBoxPassword);
            this.Controls.Add(this.TxtBoxUsername);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblLogin;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtBoxUsername;
        private System.Windows.Forms.TextBox TxtBoxPassword;
        private System.Windows.Forms.Button BtnLogIn;
        private System.Windows.Forms.Label LblIncorrectInput;
        private System.Windows.Forms.Button BtnRegister;
    }
}