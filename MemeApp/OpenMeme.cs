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
        private List<int> comments;
        private TextBox txtBoxWriteComment = new TextBox();
        private Button btnAddComment = new Button();

        public OpenMeme()
        {
            InitializeComponent();
            openMeme = this;
            this.FormClosing += new FormClosingEventHandler(Form_Closing);
            LblBackground.MouseWheel += MouseWheel;
            btnAddComment.MouseWheel += MouseWheel;
            txtBoxWriteComment.MouseWheel += TextBoxMouseWheel;
            btnAddComment.Click += AddComment;
        }

        private void ShowMeme_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            txtBoxWriteComment.Location = new Point(0, 635);
            txtBoxWriteComment.Font = new Font("Arial", 12);
            txtBoxWriteComment.BackColor = Color.FromArgb(255, 51, 51, 51);
            txtBoxWriteComment.ForeColor = Color.FromArgb(255, 150, 150, 150);
            txtBoxWriteComment.Text = "Write comment";
            txtBoxWriteComment.Width = 400;
            txtBoxWriteComment.Height = 50;
            txtBoxWriteComment.TabStop = false;
            txtBoxWriteComment.Multiline = true;
            txtBoxWriteComment.MaxLength = 1000;
            txtBoxWriteComment.GotFocus += TextBoxWriteCommentGotFocus;
            txtBoxWriteComment.KeyDown += TextBoxKeyPress;

            btnAddComment.Location = new Point(410, 635);
            btnAddComment.Font = new Font("Arial", 20);
            btnAddComment.BackColor = Color.FromArgb(255, 10, 10, 10);
            btnAddComment.ForeColor = Color.FromArgb(255, 150, 150, 150);
            btnAddComment.Text = "Send";
            btnAddComment.FlatStyle = FlatStyle.Flat;
            btnAddComment.Width = 150;
            btnAddComment.Height = 50;
            btnAddComment.TabStop = false;

            this.Controls.Add(txtBoxWriteComment);
            this.Controls.Add(btnAddComment);
            txtBoxWriteComment.BringToFront();
            btnAddComment.BringToFront();
        }

        public void OpenComments()
        {
            comments = DataAccess.returnCommentsIds(memeIdInDatabase);

            if(comments.Count >= 2)
            {
                Comment.ShowComment(comments[0]);
                Comment.ShowComment(comments[1]);
            }
            else
            {
                for (int i = 0; i < comments.Count; i++)
                {
                    Comment.ShowComment(comments[i]);
                }
            }
        }

        private static void MouseWheel(object sender, MouseEventArgs e)
        {
            MainPage.mainPage.MouseWheel(sender, e);
        }

        private static void TextBoxMouseWheel(object sender, MouseEventArgs e)
        {
            if(OpenMeme.openMeme.txtBoxWriteComment.Text.Length < 82) MainPage.mainPage.MouseWheel(sender, e);
        }

        private void TextBoxWriteCommentGotFocus(Object sender, EventArgs e)
        {
            if (txtBoxWriteComment.Text == "Write comment")
            {
                txtBoxWriteComment.Text = "";
            }

            txtBoxWriteComment.ForeColor = Color.FromArgb(255, 255, 255, 255);
        }

        private void TextBoxKeyPress(Object sender, EventArgs e)
        {
            if(txtBoxWriteComment.Text.Length >= 82) txtBoxWriteComment.ScrollBars = ScrollBars.Vertical;
            else txtBoxWriteComment.ScrollBars = ScrollBars.None;
        }

        private void AddComment(Object sender, EventArgs e)
        {
            if (txtBoxWriteComment.Text != "") DataAccess.AddComment(memeIdInDatabase, Account.id, txtBoxWriteComment.Text);

            txtBoxWriteComment.ForeColor = Color.FromArgb(255, 150, 150, 150);
            txtBoxWriteComment.Text = "Write comment";

            List<int> comments = DataAccess.returnCommentsIds(memeIdInDatabase);
            Comment.ShowComment(comments[comments.Count - 1]);
            Comment.SetLocation();
            Meme.memes[memeIdInArray].ShowPointsAndComments();
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainPage.mainPage.Show();
            MainPage.mainPage.Location = this.Location;
            this.Hide();
            thisFormIsShown = false;
            ReloadForm();
            Meme.CloseMeme(memeIdInArray);
            e.Cancel = true;
        }

        private void ReloadForm()
        {
            Comment.comments.Clear();
            Controls.Clear();
            InitializeComponent();
            LoadForm();
            LblBackground.MouseWheel += MouseWheel;
        }

        public void SetLocation()
        {
            txtBoxWriteComment.Location = new Point(10, 680 + (int)height);
            btnAddComment.Location = new Point(420, 680 + (int)height);

            if (comments.Count > 2)
            {
                while ((Comment.comments[Comment.comments.Count - 1].height + 50) < -height && Comment.comments.Count < comments.Count)
                {
                    Comment.ShowComment(comments[Comment.comments.Count]);
                }
            }
        }
    }
}
