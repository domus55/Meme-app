using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemeApp
{
    public class Meme
    {
        public static List<Meme> memes = new List<Meme>();
        public string title { get; set; }
        public Image image { get; set; }
        public int id;
        public int points = 0;
        public int pointsAddedByThisUser = 0;
        public int numberOfComments = 0;
        private Label lblTitle;
        private PictureBox picBoxImage;
        private Label pointsAndComments;
        private Button upvote;
        private Button downvote;
        private Button comments;
        private const int interspaceBetweenMemes = 680;
        private static Image imgUpvoteNormal = Image.FromFile("images/upvote.png");
        private static Image imgUpvoteClicked = Image.FromFile("images/upvoteClicked.png");
        private static Image imgDownvoteNormal = Image.FromFile("images/downvote.png");
        private static Image imgDownvoteClicked = Image.FromFile("images/downvoteClicked.png");
        private static Image imgComments = Image.FromFile("images/comments.png");

        public Meme()
        {
            upvote = new Button();
            downvote = new Button();
            comments = new Button();

            upvote.MouseClick += UpvoteClick;
            downvote.MouseClick += DownvoteClick;

            //load from database if downvote/upvote is clicked
        }

        /// <summary>
        /// Shows meme with provided id
        /// </summary>
        public static void ShowMeme(int id)
        {
            Meme meme = DataAccess.ShowImage(id);

            //Initialize title label
            meme.lblTitle = new Label();
            meme.lblTitle.Text = meme.title;
            meme.lblTitle.ForeColor = Color.FromArgb(255, 255, 255, 255);
            meme.lblTitle.Font = new Font("Arial", 30);
            meme.lblTitle.AutoSize = true;

            ////Initialize meme picturebox
            meme.picBoxImage = new PictureBox();
            meme.picBoxImage.Image = meme.image;
            Size size = meme.picBoxImage.GetPreferredSize(new Size(1000, 500));
            float scale = size.Height / 500f;
            meme.picBoxImage.Height = 500;
            meme.picBoxImage.Width = (int)(size.Width / scale);
            meme.picBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

            //Initialize points and comments label
            meme.pointsAndComments = new Label();;
            meme.ShowPointsAndComments();
            meme.pointsAndComments.AutoSize = true;
            if (MainPage.darkMode) meme.pointsAndComments.ForeColor = Color.FromArgb(150, 255, 255, 255);
            else meme.pointsAndComments.ForeColor = Color.FromArgb(150, 0, 0, 0);

            //Initialize upvote button
            meme.upvote.BackgroundImageLayout = ImageLayout.Zoom;
            meme.upvote.Size = new Size(52, 40);
            meme.upvote.TabStop = false;
            meme.upvote.FlatStyle = FlatStyle.Flat;
            if (meme.pointsAddedByThisUser == 1) meme.upvote.BackgroundImage = imgUpvoteClicked;
            else meme.upvote.BackgroundImage = imgUpvoteNormal;

            //Initialize downvote button
            meme.downvote.BackgroundImageLayout = ImageLayout.Zoom;
            meme.downvote.Size = new Size(52, 40);
            meme.downvote.TabStop = false;
            meme.downvote.FlatStyle = FlatStyle.Flat;
            if (meme.pointsAddedByThisUser == -1) meme.downvote.BackgroundImage = imgDownvoteClicked;
            else meme.downvote.BackgroundImage = imgDownvoteNormal;

            //Handle events
            meme.picBoxImage.MouseWheel += MainPage.mainPage.MouseWheel;
            meme.pointsAndComments.MouseWheel += MainPage.mainPage.MouseWheel;
            meme.lblTitle.MouseWheel += MouseWheel;

            MainPage.mainPage.Controls.Add(meme.lblTitle);
            MainPage.mainPage.Controls.Add(meme.picBoxImage);
            MainPage.mainPage.Controls.Add(meme.pointsAndComments);
            MainPage.mainPage.Controls.Add(meme.upvote);
            MainPage.mainPage.Controls.Add(meme.downvote);
            MainPage.mainPage.Controls.Add(meme.comments);

            meme.lblTitle.BringToFront();
            meme.picBoxImage.BringToFront();
            meme.pointsAndComments.BringToFront();
            meme.upvote.BringToFront();
            meme.downvote.BringToFront();
            //meme.comments.BringToFront();
            memes.Add(meme);
            SetLocation();

            MainPage.mainPage.BringEverythingToFront();

            if (Account.username == "Guest")
            {
                meme.upvote.Visible = false;
                meme.downvote.Visible = false;
            }
        }

        private static void MouseWheel(object sender, MouseEventArgs e)
        {
            MainPage.mainPage.MouseWheel(sender, e);
        }

        void UpvoteClick(object sender, MouseEventArgs e)
        {

            if (pointsAddedByThisUser == -1)
            {
                DataAccess.AddPointsToMeme(id, 1);
                downvote.BackgroundImage = imgDownvoteNormal;
            }
            if (pointsAddedByThisUser == 1) pointsAddedByThisUser = 0;
            else pointsAddedByThisUser = 1;
            lblTitle.Focus();
            Button btn = (Button)sender;
            if (pointsAddedByThisUser == 1)
            {
                btn.BackgroundImage = imgUpvoteClicked;
                DataAccess.AddPointsToMeme(id, 1);
            }
            else
            {
                DataAccess.AddPointsToMeme(id, -1);
                btn.BackgroundImage = imgUpvoteNormal;
            }

            DataAccess.SetPointsOnMeme(id, pointsAddedByThisUser);
            ShowPointsAndComments();   
        }

        void DownvoteClick(object sender, MouseEventArgs e)
        {
            if (pointsAddedByThisUser == 1)
            {
                upvote.BackgroundImage = imgUpvoteNormal;
                DataAccess.AddPointsToMeme(id, -1);
            }
            if (pointsAddedByThisUser == -1) pointsAddedByThisUser = 0;
            else pointsAddedByThisUser = -1;

            lblTitle.Focus();
            Button btn = (Button)sender;

            if (pointsAddedByThisUser == -1)
            {
                btn.BackgroundImage = imgDownvoteClicked;
                DataAccess.AddPointsToMeme(id, -1);
            }
            else
            {
                btn.BackgroundImage = imgDownvoteNormal;
                DataAccess.AddPointsToMeme(id, 1);
            }

            DataAccess.SetPointsOnMeme(id, pointsAddedByThisUser);
            ShowPointsAndComments();
        }

        private void ShowPointsAndComments()
        {
            pointsAndComments.Text = DataAccess.CountPointsInMeme(id).ToString() + " points, " + numberOfComments.ToString() + " comments";
        }

        ///<summary>
        ///Moves all memes up or down
        ///</summary>
        public static void SetLocation()
        {
            int height = (int)MainPage.mainPage.height;

            for (int i = 0; i<memes.Count; i++)
            {
                memes[i].lblTitle.Location = new Point(10, (int)height + 50 + i * interspaceBetweenMemes);
                memes[i].picBoxImage.Location = new Point(10, (int)height + 100 + i * interspaceBetweenMemes);
                memes[i].pointsAndComments.Location = new Point(10, (int)height + 600 + i * interspaceBetweenMemes);
                memes[i].upvote.Location = new Point(10, (int)height + 620 + i * interspaceBetweenMemes);
                memes[i].downvote.Location = new Point(70, (int)height + 620 + i * interspaceBetweenMemes);
            }
        }
    }
}
