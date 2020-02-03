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
        static MainPage mainPage;

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
            DataAccess.SaveImage(TxtBoxTitle.Text, imgLoc);
        }

        public static void GetReferenceToMainForm(MainPage main)
        {
            mainPage = main;
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainPage.Show();
            mainPage.Location = this.Location;
            this.Hide();
            e.Cancel = true;
        }
    }
}
