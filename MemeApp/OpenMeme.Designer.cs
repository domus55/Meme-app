namespace MemeApp
{
    partial class OpenMeme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenMeme));
            this.LblBackground = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblBackground
            // 
            this.LblBackground.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblBackground.Location = new System.Drawing.Point(0, 0);
            this.LblBackground.Name = "LblBackground";
            this.LblBackground.Size = new System.Drawing.Size(1064, 680);
            this.LblBackground.TabIndex = 2;
            // 
            // OpenMeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.LblBackground);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OpenMeme";
            this.Text = "ShowMeme";
            this.Load += new System.EventHandler(this.ShowMeme_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblBackground;
    }
}