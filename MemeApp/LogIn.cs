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
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            string login = TxtBoxLogin.Text;
            string password = TxtBoxPassword.Text;

            if (DataAccess.LogIn(login, password)) MessageBox.Show("dziala");
            else MessageBox.Show("nie dziala");

        }
    }
}
