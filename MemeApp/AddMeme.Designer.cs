namespace MemeApp
{
    partial class AddMeme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMeme));
            this.TxtBoxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PicMeme = new System.Windows.Forms.PictureBox();
            this.BtnFindImage = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicMeme)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBoxTitle
            // 
            this.TxtBoxTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            resources.ApplyResources(this.TxtBoxTitle, "TxtBoxTitle");
            this.TxtBoxTitle.ForeColor = System.Drawing.SystemColors.Info;
            this.TxtBoxTitle.Name = "TxtBoxTitle";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // PicMeme
            // 
            resources.ApplyResources(this.PicMeme, "PicMeme");
            this.PicMeme.Name = "PicMeme";
            this.PicMeme.TabStop = false;
            // 
            // BtnFindImage
            // 
            resources.ApplyResources(this.BtnFindImage, "BtnFindImage");
            this.BtnFindImage.Name = "BtnFindImage";
            this.BtnFindImage.UseVisualStyleBackColor = true;
            this.BtnFindImage.Click += new System.EventHandler(this.BtnFindImage_Click);
            // 
            // BtnSave
            // 
            resources.ApplyResources(this.BtnSave, "BtnSave");
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // AddMeme
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnFindImage);
            this.Controls.Add(this.PicMeme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBoxTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.HelpButton = true;
            this.Name = "AddMeme";
            ((System.ComponentModel.ISupportInitialize)(this.PicMeme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBoxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PicMeme;
        private System.Windows.Forms.Button BtnFindImage;
        private System.Windows.Forms.Button BtnSave;
    }
}