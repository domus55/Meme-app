namespace MemeApp
{
    partial class MainPage
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.LblBackground = new System.Windows.Forms.Label();
            this.PicBoxTopBar = new System.Windows.Forms.PictureBox();
            this.BtnAddMeme = new System.Windows.Forms.Button();
            this.BtnLogIn = new System.Windows.Forms.Button();
            this.PicBoxUserIcon = new System.Windows.Forms.PictureBox();
            this.PicBoxAccountMenu = new System.Windows.Forms.PictureBox();
            this.BtnAccountSettings = new System.Windows.Forms.Button();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.PicBoxNightMode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTopBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAccountMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxNightMode)).BeginInit();
            this.SuspendLayout();
            // 
            // LblBackground
            // 
            this.LblBackground.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblBackground.Location = new System.Drawing.Point(0, 0);
            this.LblBackground.Name = "LblBackground";
            this.LblBackground.Size = new System.Drawing.Size(1064, 680);
            this.LblBackground.TabIndex = 1;
            this.LblBackground.Click += new System.EventHandler(this.LblBackground_Click);
            // 
            // PicBoxTopBar
            // 
            this.PicBoxTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PicBoxTopBar.Location = new System.Drawing.Point(0, 0);
            this.PicBoxTopBar.Name = "PicBoxTopBar";
            this.PicBoxTopBar.Size = new System.Drawing.Size(1064, 58);
            this.PicBoxTopBar.TabIndex = 1;
            this.PicBoxTopBar.TabStop = false;
            // 
            // BtnAddMeme
            // 
            this.BtnAddMeme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.BtnAddMeme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddMeme.ForeColor = System.Drawing.Color.White;
            this.BtnAddMeme.Location = new System.Drawing.Point(12, 12);
            this.BtnAddMeme.Name = "BtnAddMeme";
            this.BtnAddMeme.Size = new System.Drawing.Size(104, 33);
            this.BtnAddMeme.TabIndex = 20;
            this.BtnAddMeme.TabStop = false;
            this.BtnAddMeme.Text = "Add meme";
            this.BtnAddMeme.UseVisualStyleBackColor = false;
            this.BtnAddMeme.Click += new System.EventHandler(this.BtnAddMeme_Click);
            // 
            // BtnLogIn
            // 
            this.BtnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.BtnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogIn.ForeColor = System.Drawing.Color.White;
            this.BtnLogIn.Location = new System.Drawing.Point(948, 12);
            this.BtnLogIn.Name = "BtnLogIn";
            this.BtnLogIn.Size = new System.Drawing.Size(104, 33);
            this.BtnLogIn.TabIndex = 3;
            this.BtnLogIn.Text = "Log in";
            this.BtnLogIn.UseVisualStyleBackColor = false;
            this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click);
            // 
            // PicBoxUserIcon
            // 
            this.PicBoxUserIcon.Location = new System.Drawing.Point(1010, 4);
            this.PicBoxUserIcon.Name = "PicBoxUserIcon";
            this.PicBoxUserIcon.Size = new System.Drawing.Size(50, 50);
            this.PicBoxUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxUserIcon.TabIndex = 4;
            this.PicBoxUserIcon.TabStop = false;
            this.PicBoxUserIcon.Click += new System.EventHandler(this.PicBoxUserIcon_Click);
            // 
            // PicBoxAccountMenu
            // 
            this.PicBoxAccountMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PicBoxAccountMenu.Location = new System.Drawing.Point(886, 64);
            this.PicBoxAccountMenu.Name = "PicBoxAccountMenu";
            this.PicBoxAccountMenu.Size = new System.Drawing.Size(174, 90);
            this.PicBoxAccountMenu.TabIndex = 5;
            this.PicBoxAccountMenu.TabStop = false;
            this.PicBoxAccountMenu.Visible = false;
            // 
            // BtnAccountSettings
            // 
            this.BtnAccountSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.BtnAccountSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAccountSettings.ForeColor = System.Drawing.Color.White;
            this.BtnAccountSettings.Location = new System.Drawing.Point(896, 74);
            this.BtnAccountSettings.Name = "BtnAccountSettings";
            this.BtnAccountSettings.Size = new System.Drawing.Size(158, 32);
            this.BtnAccountSettings.TabIndex = 6;
            this.BtnAccountSettings.Text = "Settings";
            this.BtnAccountSettings.UseVisualStyleBackColor = false;
            this.BtnAccountSettings.Visible = false;
            this.BtnAccountSettings.Click += new System.EventHandler(this.BtnAccountSettings_Click);
            // 
            // BtnLogout
            // 
            this.BtnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.BtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogout.ForeColor = System.Drawing.Color.White;
            this.BtnLogout.Location = new System.Drawing.Point(896, 112);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(158, 32);
            this.BtnLogout.TabIndex = 7;
            this.BtnLogout.Text = "Logout";
            this.BtnLogout.UseVisualStyleBackColor = false;
            this.BtnLogout.Visible = false;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // PicBoxNightMode
            // 
            this.PicBoxNightMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.PicBoxNightMode.Image = ((System.Drawing.Image)(resources.GetObject("PicBoxNightMode.Image")));
            this.PicBoxNightMode.Location = new System.Drawing.Point(912, 14);
            this.PicBoxNightMode.Name = "PicBoxNightMode";
            this.PicBoxNightMode.Size = new System.Drawing.Size(30, 30);
            this.PicBoxNightMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBoxNightMode.TabIndex = 21;
            this.PicBoxNightMode.TabStop = false;
            this.PicBoxNightMode.Click += new System.EventHandler(this.PicBoxNightMode_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.PicBoxNightMode);
            this.Controls.Add(this.BtnLogout);
            this.Controls.Add(this.BtnAccountSettings);
            this.Controls.Add(this.PicBoxAccountMenu);
            this.Controls.Add(this.PicBoxUserIcon);
            this.Controls.Add(this.BtnLogIn);
            this.Controls.Add(this.BtnAddMeme);
            this.Controls.Add(this.PicBoxTopBar);
            this.Controls.Add(this.LblBackground);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPage";
            this.Text = "Meme";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTopBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxUserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxAccountMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxNightMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblBackground;
        private System.Windows.Forms.PictureBox PicBoxTopBar;
        private System.Windows.Forms.Button BtnAddMeme;
        private System.Windows.Forms.Button BtnLogIn;
        private System.Windows.Forms.PictureBox PicBoxUserIcon;
        private System.Windows.Forms.PictureBox PicBoxAccountMenu;
        private System.Windows.Forms.Button BtnAccountSettings;
        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.PictureBox PicBoxNightMode;
    }
}

