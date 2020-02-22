namespace MemeApp
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.LblIncorrectInput = new System.Windows.Forms.Label();
            this.BtnChangePassword = new System.Windows.Forms.Button();
            this.TxtBoxNewPassword1 = new System.Windows.Forms.TextBox();
            this.TxtBoxOldPassword = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblLogin = new System.Windows.Forms.Label();
            this.TxtBoxNewPassword2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblIncorrectInput
            // 
            this.LblIncorrectInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LblIncorrectInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblIncorrectInput.Location = new System.Drawing.Point(473, 474);
            this.LblIncorrectInput.Name = "LblIncorrectInput";
            this.LblIncorrectInput.Size = new System.Drawing.Size(506, 40);
            this.LblIncorrectInput.TabIndex = 12;
            this.LblIncorrectInput.Text = "Incorrect password";
            this.LblIncorrectInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblIncorrectInput.Visible = false;
            // 
            // BtnChangePassword
            // 
            this.BtnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.BtnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.BtnChangePassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnChangePassword.Location = new System.Drawing.Point(473, 392);
            this.BtnChangePassword.Name = "BtnChangePassword";
            this.BtnChangePassword.Size = new System.Drawing.Size(506, 45);
            this.BtnChangePassword.TabIndex = 11;
            this.BtnChangePassword.TabStop = false;
            this.BtnChangePassword.Text = "Change password";
            this.BtnChangePassword.UseVisualStyleBackColor = false;
            this.BtnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // TxtBoxNewPassword1
            // 
            this.TxtBoxNewPassword1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.TxtBoxNewPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.TxtBoxNewPassword1.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtBoxNewPassword1.Location = new System.Drawing.Point(473, 228);
            this.TxtBoxNewPassword1.MaxLength = 120;
            this.TxtBoxNewPassword1.Name = "TxtBoxNewPassword1";
            this.TxtBoxNewPassword1.Size = new System.Drawing.Size(506, 45);
            this.TxtBoxNewPassword1.TabIndex = 2;
            this.TxtBoxNewPassword1.UseSystemPasswordChar = true;
            // 
            // TxtBoxOldPassword
            // 
            this.TxtBoxOldPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.TxtBoxOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.TxtBoxOldPassword.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtBoxOldPassword.Location = new System.Drawing.Point(473, 146);
            this.TxtBoxOldPassword.MaxLength = 120;
            this.TxtBoxOldPassword.Name = "TxtBoxOldPassword";
            this.TxtBoxOldPassword.Size = new System.Drawing.Size(506, 45);
            this.TxtBoxOldPassword.TabIndex = 1;
            this.TxtBoxOldPassword.UseSystemPasswordChar = true;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.LblPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblPassword.Location = new System.Drawing.Point(85, 228);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(250, 39);
            this.LblPassword.TabIndex = 8;
            this.LblPassword.Text = "New password:";
            // 
            // LblLogin
            // 
            this.LblLogin.AutoSize = true;
            this.LblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.LblLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblLogin.Location = new System.Drawing.Point(85, 146);
            this.LblLogin.Name = "LblLogin";
            this.LblLogin.Size = new System.Drawing.Size(234, 39);
            this.LblLogin.TabIndex = 7;
            this.LblLogin.Text = "Old password:";
            // 
            // TxtBoxNewPassword2
            // 
            this.TxtBoxNewPassword2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.TxtBoxNewPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.TxtBoxNewPassword2.ForeColor = System.Drawing.SystemColors.Window;
            this.TxtBoxNewPassword2.Location = new System.Drawing.Point(473, 310);
            this.TxtBoxNewPassword2.MaxLength = 120;
            this.TxtBoxNewPassword2.Name = "TxtBoxNewPassword2";
            this.TxtBoxNewPassword2.Size = new System.Drawing.Size(506, 45);
            this.TxtBoxNewPassword2.TabIndex = 3;
            this.TxtBoxNewPassword2.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(85, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 39);
            this.label1.TabIndex = 15;
            this.label1.Text = "Confirm new password:";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBoxNewPassword2);
            this.Controls.Add(this.LblIncorrectInput);
            this.Controls.Add(this.BtnChangePassword);
            this.Controls.Add(this.TxtBoxNewPassword1);
            this.Controls.Add(this.TxtBoxOldPassword);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChangePassword";
            this.Text = "Change password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblIncorrectInput;
        private System.Windows.Forms.Button BtnChangePassword;
        private System.Windows.Forms.TextBox TxtBoxNewPassword1;
        private System.Windows.Forms.TextBox TxtBoxOldPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblLogin;
        private System.Windows.Forms.TextBox TxtBoxNewPassword2;
        private System.Windows.Forms.Label label1;
    }
}