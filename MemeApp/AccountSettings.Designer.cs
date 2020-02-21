namespace MemeApp
{
    partial class AccountSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountSettings));
            this.PicBoxUserImage = new System.Windows.Forms.PictureBox();
            this.BtnChangeImage = new System.Windows.Forms.Button();
            this.LblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUserImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBoxUserImage
            // 
            this.PicBoxUserImage.Location = new System.Drawing.Point(20, 20);
            this.PicBoxUserImage.Name = "PicBoxUserImage";
            this.PicBoxUserImage.Size = new System.Drawing.Size(300, 300);
            this.PicBoxUserImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxUserImage.TabIndex = 0;
            this.PicBoxUserImage.TabStop = false;
            // 
            // BtnChangeImage
            // 
            this.BtnChangeImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BtnChangeImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChangeImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.BtnChangeImage.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.BtnChangeImage.Location = new System.Drawing.Point(20, 351);
            this.BtnChangeImage.Name = "BtnChangeImage";
            this.BtnChangeImage.Size = new System.Drawing.Size(300, 56);
            this.BtnChangeImage.TabIndex = 1;
            this.BtnChangeImage.Text = "Change Image";
            this.BtnChangeImage.UseVisualStyleBackColor = false;
            this.BtnChangeImage.Click += new System.EventHandler(this.BtnChangeImage_Click);
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.LblUsername.ForeColor = System.Drawing.Color.White;
            this.LblUsername.Location = new System.Drawing.Point(340, 20);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(147, 31);
            this.LblUsername.TabIndex = 2;
            this.LblUsername.Text = "Username:";
            // 
            // AccountSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.BtnChangeImage);
            this.Controls.Add(this.PicBoxUserImage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AccountSettings";
            this.Text = "Account Settings";
            this.Load += new System.EventHandler(this.AccountSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUserImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBoxUserImage;
        private System.Windows.Forms.Button BtnChangeImage;
        private System.Windows.Forms.Label LblUsername;
    }
}