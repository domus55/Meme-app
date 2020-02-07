using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemeApp
{
    public partial class AddMeme : Form
    {
        string imgLoc = "";

        public AddMeme()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_Closing);
        }

        private void BtnFindImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*All Files (*.jpg;*.png)|*.jpg; *.png";
            dlg.Title = "Select meme";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgLoc = dlg.FileName.ToString();
                PicMeme.ImageLocation = imgLoc;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(TxtBoxTitle.Text == "")
            {
                LblInputError.Font = new Font("Microsoft Sans Serif", 14);
                LblInputError.Text = "Title field can't be empty";
                LblInputError.Visible = true;
                return;
            }

            if(imgLoc == "")
            {
                LblInputError.Font = new Font("Microsoft Sans Serif", 12);
                LblInputError.Text = "You have to chose an image";
                LblInputError.Visible = true;
                return;
            }
            
            {
                DataAccess.SaveImage(TxtBoxTitle.Text, imgLoc);
                Meme.ShowMeme(DataAccess.CountAllMemes());
                Close();
            }
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Close();
            e.Cancel = true;
        }

        new private void Close()
        {
            MainPage.mainPage.Show();
            MainPage.mainPage.Location = this.Location;
            this.Hide();
        }
    }
}
