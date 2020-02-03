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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
            this.AcceptButton = BtnLogIn;
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            string username = TxtBoxLogin.Text;
            string password = TxtBoxPassword.Text;

            if (DataAccess.LogIn(username, password))
            {
                Account.CreateAccountDataFile(username, password);
                MainPage.mainPage.CheckIfIsLoggedIn();
                MainPage.mainPage.Show();
                MainPage.mainPage.Location = this.Location;
                this.Hide();
            }
            else
            {
                LblIncorrectInput.Visible = true;
            }
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
