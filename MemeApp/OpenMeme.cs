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
    public partial class OpenMeme : Form
    {
        public static OpenMeme openMeme;
        public static bool thisFormIsShown = false;
        public static int memeIdInArray = 0;
        public static int memeIdInDatabase = 0;
        public static float height = 20;
        TextBox txtBoxWriteComment = new TextBox();
        Button btnSendComment = new Button();

        public OpenMeme()
        {
            InitializeComponent();
            openMeme = this;
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
            LblBackground.MouseWheel += MouseWheel;
            btnSendComment.MouseWheel += MouseWheel;
            btnSendComment.Click += SendMessage;
        }

        private void ShowMeme_Load(object sender, EventArgs e)
        {
            txtBoxWriteComment.Location = new Point(0, 635);
            txtBoxWriteComment.Font = new Font("Arial", 20);
            txtBoxWriteComment.BackColor = Color.FromArgb(255, 51, 51, 51);
            txtBoxWriteComment.ForeColor = Color.FromArgb(255, 150, 150, 150);
            txtBoxWriteComment.Text = "Write comment";
            txtBoxWriteComment.Width = 400;
            txtBoxWriteComment.TabStop = false;
            txtBoxWriteComment.GotFocus += TextBoxWriteCommentGotFocus;

            btnSendComment.Location = new Point(410, 635);
            btnSendComment.Font = new Font("Arial", 20);
            btnSendComment.BackColor = Color.FromArgb(255, 10, 10, 10);
            btnSendComment.ForeColor = Color.FromArgb(255, 150, 150, 150);
            btnSendComment.Text = "Send";
            btnSendComment.FlatStyle = FlatStyle.Flat;
            btnSendComment.Width = 150;
            btnSendComment.Height = 38;
            btnSendComment.TabStop = false;

            this.Controls.Add(txtBoxWriteComment);
            this.Controls.Add(btnSendComment);
            txtBoxWriteComment.BringToFront();
            btnSendComment.BringToFront();
        }

        public void OpenComments()
        {
            List<int> comments = DataAccess.returnCommentsIds(memeIdInDatabase);

            for (int i = 0; i < comments.Count; i++)
            {
                Comment.ShowComment(comments[i]);
            }
        }

        private static void MouseWheel(object sender, MouseEventArgs e)
        {
            MainPage.mainPage.MouseWheel(sender, e);
        }

        private void TextBoxWriteCommentGotFocus(Object sender, EventArgs e)
        {
            if (txtBoxWriteComment.Text == "Write comment")
            {
                txtBoxWriteComment.Text = "";
            }

            txtBoxWriteComment.ForeColor = Color.FromArgb(255, 255, 255, 255);
        }

        private void SendMessage(Object sender, EventArgs e)
        {
            if (txtBoxWriteComment.Text != "") DataAccess.AddComment(memeIdInDatabase, Account.id, txtBoxWriteComment.Text);

            txtBoxWriteComment.Text = "";
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainPage.mainPage.Show();
            MainPage.mainPage.Location = this.Location;
            this.Hide();
            thisFormIsShown = false;
            Meme.CloseMeme(memeIdInArray);
            e.Cancel = true;
        }

        public void SetLocation()
        {
            txtBoxWriteComment.Location = new Point(0, 680 + (int)height);
            btnSendComment.Location = new Point(410, 680 + (int)height);
        }
    }
}
