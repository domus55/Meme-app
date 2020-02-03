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
            this.LblWheelHandler = new System.Windows.Forms.Label();
            this.PicBoxTopBar = new System.Windows.Forms.PictureBox();
            this.BtnAddMeme = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTopBar)).BeginInit();
            this.SuspendLayout();
            // 
            // LblWheelHandler
            // 
            this.LblWheelHandler.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblWheelHandler.Location = new System.Drawing.Point(0, 0);
            this.LblWheelHandler.Name = "LblWheelHandler";
            this.LblWheelHandler.Size = new System.Drawing.Size(1064, 680);
            this.LblWheelHandler.TabIndex = 0;
            // 
            // PicBoxTopBar
            // 
            this.PicBoxTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PicBoxTopBar.Location = new System.Drawing.Point(0, 0);
            this.PicBoxTopBar.Name = "PicBoxTopBar";
            this.PicBoxTopBar.Size = new System.Drawing.Size(1064, 58);
            this.PicBoxTopBar.TabIndex = 1;
            this.PicBoxTopBar.TabStop = false;
            // 
            // BtnAddMeme
            // 
            this.BtnAddMeme.Location = new System.Drawing.Point(12, 12);
            this.BtnAddMeme.Name = "BtnAddMeme";
            this.BtnAddMeme.Size = new System.Drawing.Size(104, 33);
            this.BtnAddMeme.TabIndex = 2;
            this.BtnAddMeme.Text = "Add meme";
            this.BtnAddMeme.UseVisualStyleBackColor = true;
            this.BtnAddMeme.Click += new System.EventHandler(this.BtnAddMeme_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.BtnAddMeme);
            this.Controls.Add(this.PicBoxTopBar);
            this.Controls.Add(this.LblWheelHandler);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPage";
            this.Text = "Meme";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTopBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblWheelHandler;
        private System.Windows.Forms.PictureBox PicBoxTopBar;
        private System.Windows.Forms.Button BtnAddMeme;
    }
}

