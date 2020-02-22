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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            LblIncorrectInput.Visible = false;

            if (DataAccess.LogIn(Account.username, TxtBoxOldPassword.Text))
            {
                if(TxtBoxNewPassword1.Text == "" || TxtBoxNewPassword2.Text == "")
                {
                    ShowErrorMessage(2);
                    return;
                }
                if (!TxtBoxNewPassword1.Text.Equals(TxtBoxNewPassword2.Text))
                {
                    ShowErrorMessage(3);
                    return;
                }

                DataAccess.ChangePassword(Account.id, TxtBoxNewPassword1.Text);
                Account.CreateAccountDataFile(Account.username, TxtBoxNewPassword1.Text);
                CloseForm();
            }
            else
            {
                ShowErrorMessage(1);
            }
        }

        /// <summary>
        /// Shows error message:<para></para>
        /// 1 - incorrect old password<para></para>
        /// 2 - password field is empty<para></para>
        /// 3 - new passwords do not match
        /// </summary>
        private void ShowErrorMessage(int errorNumber)
        {
            LblIncorrectInput.Visible = true;

            switch (errorNumber)
            {
                case 1:
                    LblIncorrectInput.Text = "Old password is incorrect";
                    break;
                case 2:
                    LblIncorrectInput.Text = "Password field is empty";
                    break;
                case 3:
                    LblIncorrectInput.Text = "New passwords do not match";
                    break;
            }
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseForm();
            e.Cancel = true;
        }

        private void CloseForm()
        {
            TxtBoxOldPassword.Text = "";
            TxtBoxNewPassword1.Text = "";
            TxtBoxNewPassword2.Text = "";
            MainPage.formAccountSettings.Show();
            MainPage.formAccountSettings.Location = this.Location;
            this.Hide();
        }
    }
}
