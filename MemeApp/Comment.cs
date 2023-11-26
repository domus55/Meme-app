using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemeApp
{
    public class Comment
    {
        public static List<Comment> comments = new List<Comment>();
        public static int memesNotFound = 0;
        public string username;
        public string text;
        public int idInDatabase;
        public int idInArray;
        public int height;
        public Image image;
        private Label lblUsername;
        private Label lblText;
        private PictureBox picBoxUserImage;
        private const int interspaceBetweenComments = -160;
        public Comment()
        {
            lblUsername = new Label();
            lblText = new Label();
        }

        /// <summary>
        /// Shows comment with provided id
        /// </summary>
        public static void ShowComment(int id)
        {
            Comment comment = DataAccess.ShowComment(id + memesNotFound);

            while (comment.text == null)
            {
                memesNotFound++;
                comment = DataAccess.ShowComment(id + memesNotFound);
            }

            //Initialize username label
            comment.lblUsername.Text = comment.username;
            comment.lblUsername.ForeColor = Color.FromArgb(150, 255, 255, 255);
            comment.lblUsername.Font = new Font("Arial", 22);
            comment.lblUsername.AutoSize = true;

            //Initialize text label
            comment.lblText.Text = comment.text;
            comment.lblText.ForeColor = Color.FromArgb(255, 255, 255, 255);
            comment.lblText.MaximumSize = new Size(500, 2000);
            comment.lblText.Font = new Font("Arial", 14);
            comment.lblText.AutoSize = true;

            //Initialize user picturebox
            comment.picBoxUserImage = new PictureBox();
            comment.picBoxUserImage.Image = comment.image;
            comment.picBoxUserImage.Height = 50;
            comment.picBoxUserImage.Width = 50;
            comment.picBoxUserImage.SizeMode = PictureBoxSizeMode.StretchImage;

            //Handle events
            comment.picBoxUserImage.MouseWheel += MouseWheel;
            comment.lblText.MouseWheel += MouseWheel;
            comment.lblUsername.MouseWheel += MouseWheel;

            OpenMeme.openMeme.Controls.Add(comment.lblUsername);
            OpenMeme.openMeme.Controls.Add(comment.lblText);
            OpenMeme.openMeme.Controls.Add(comment.picBoxUserImage);

            comment.lblUsername.BringToFront();
            comment.lblText.BringToFront();
            comment.picBoxUserImage.BringToFront();
            comment.idInArray = comments.Count;
            comments.Add(comment);
            comment.SetDarkMode();
            SetLocation();

            //Set height
            if(comment.idInArray == 0)
            {
                comment.height = 0;
            }
            else
            {
                int prevCommentHeight = comments[comment.idInArray - 1].height;
                comment.height = prevCommentHeight + comments[comment.idInArray - 1].lblText.Height + interspaceBetweenComments;
            }
            
        }

        private static void MouseWheel(object sender, MouseEventArgs e)
        {
            MainPage.mainPage.MouseWheel(sender, e);
        }

        /// <summary>
        /// Sets position of title, picture, and buttons(upvote, downvote, comments) depending on height variable
        /// </summary>
        public static void SetLocation()
        {
            int height = (int)OpenMeme.height;

            for (int i = 0; i < comments.Count; i++)
            {
                comments[i].lblUsername.Location = new Point(70, height + 740 + comments[i].height);
                comments[i].lblText.Location = new Point(70, height + 780 + comments[i].height);
                comments[i].picBoxUserImage.Location = new Point(10, height + 740 + comments[i].height);
            }
        }

        private void SetDarkMode()
        {
            if(MainPage.darkMode)
            {

            }
            else
            {
                lblUsername.BackColor = Color.FromArgb(255, 255, 255, 255);
                lblUsername.ForeColor = Color.FromArgb(255, 0, 0, 0);
                lblText.BackColor = Color.FromArgb(255, 255, 255, 255);
                lblText.ForeColor = Color.FromArgb(255, 0, 0, 0);
            }
        }

        public static void SetDarkModeToAll()
        {
            for (int i = 0; i < comments.Count; i++)
            {
                comments[i].SetDarkMode();
            }
        }
    }
}
