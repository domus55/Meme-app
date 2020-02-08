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
            string username = TxtBoxUsername.Text;
            string password = TxtBoxPassword.Text;

            try
            {
                if (DataAccess.LogIn(username, password))
                {
                    Account.CreateAccountDataFile(username, password);
                    MainPage.mainPage.CheckIfIsLoggedIn();
                    MainPage.mainPage.Show();
                    MainPage.mainPage.Location = this.Location;
                    MainPage.mainPage.ReloadForm();
                    this.Hide();
                }
                else
                {
                    LblIncorrectInput.Text = "Incorrect login or password";
                    LblIncorrectInput.Visible = true;
                }
            }
            catch
            {
                LblIncorrectInput.Text = "No internet connection!";
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

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = TxtBoxUsername.Text;
            string password = TxtBoxPassword.Text;
            LblIncorrectInput.Text = "";

            if (username == "")
            {
                LblIncorrectInput.Text = "Username field can't be empty";
                LblIncorrectInput.Visible = true;
                return;
            }

            if(password == "")
            {
                LblIncorrectInput.Text = "Password field can't be empty";
                LblIncorrectInput.Visible = true;
                return;
            }

            try
            {
                if (Account.CreateNewAccount(username, password))    //if account have been created
                {
                    Account.CreateAccountDataFile(username, password);
                    MainPage.mainPage.CheckIfIsLoggedIn();
                    MainPage.mainPage.Show();
                    MainPage.mainPage.Location = this.Location;
                    MainPage.mainPage.ReloadForm();
                    this.Hide();
                }
                else
                {
                    LblIncorrectInput.Text = "This username already exists";
                    LblIncorrectInput.Visible = true;
                    return;
                }
            }
            catch
            {
                LblIncorrectInput.Text = "No internet connection!";
                LblIncorrectInput.Visible = true;
            }
        }
    }
}
