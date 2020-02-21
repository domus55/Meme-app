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
    public partial class AccountSettings : Form
    {
        public AccountSettings()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
        }

        private void AccountSettings_Load(object sender, EventArgs e)
        {
            LoadUserPicture();
            LoadUsername();
        }

        private void LoadUserPicture()
        {
            int id = Account.id;
            PicBoxUserImage.Image = DataAccess.GetUserImage(id);
        }

        private void BtnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*All Files (*.jpg;*.png)|*.jpg; *.png";
            dlg.Title = "Select user picture";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string imgLoc = dlg.FileName.ToString();
                PicBoxUserImage.ImageLocation = imgLoc;
                DataAccess.ChangeUserImage(Account.id, imgLoc);
                MainPage.mainPage.RefreshUserImage();
            }
        }

        private void LoadUsername()
        {
            LblUsername.Text = "Username: " + Account.username;
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainPage.mainPage.Show();
            MainPage.mainPage.Location = this.Location;
            this.Hide();
            e.Cancel = true;
        }
    }
}
