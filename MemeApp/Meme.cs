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
        public int points = 1246;
        private Label lblTitle;
        private PictureBox picBoxImage;
        private Label pointsAndComments;
        private Button upvote;
        private Button downvote;
        private Button comments;
        private const int interspaceBetweenMemes = 680;
        private bool isUpvoteClicked = false;
        private bool isDownvoteClicked = false;
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
            meme.lblTitle.Location = new Point(10, 50 + (id - 1) * interspaceBetweenMemes);
            meme.lblTitle.Font = new Font("Arial", 30);
            meme.lblTitle.AutoSize = true;

            ////Initialize meme picturebox
            meme.picBoxImage = new PictureBox();
            meme.picBoxImage.Image = meme.image;
            meme.picBoxImage.Location = new Point(10, 100 + (id - 1) * interspaceBetweenMemes);
            Size size = meme.picBoxImage.GetPreferredSize(new Size(1000, 500));
            float scale = size.Height / 500f;
            meme.picBoxImage.Height = 500;
            meme.picBoxImage.Width = (int)(size.Width / scale);
            meme.picBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

            //Initialize points and comments label
            meme.pointsAndComments = new Label();
            meme.pointsAndComments.Location = new Point(10, 600 + (id - 1) * interspaceBetweenMemes);
            meme.pointsAndComments.Text = meme.points.ToString() + " points, 423 comments";
            meme.pointsAndComments.AutoSize = true;
            if (MainPage.darkMode) meme.pointsAndComments.ForeColor = Color.FromArgb(150, 255, 255, 255);
            else meme.pointsAndComments.ForeColor = Color.FromArgb(150, 0, 0, 0);

            //Initialize upvote button
            meme.upvote.Location = new Point(10, 620 + (id - 1) * interspaceBetweenMemes);
            meme.upvote.BackgroundImageLayout = ImageLayout.Zoom;
            meme.upvote.Size = new Size(52, 40);
            meme.upvote.TabStop = false;
            meme.upvote.FlatStyle = FlatStyle.Flat;
            if (meme.isUpvoteClicked) meme.upvote.BackgroundImage = imgUpvoteClicked;
            else meme.upvote.BackgroundImage = imgUpvoteNormal;

            //Initialize downvote button
            meme.downvote.Location = new Point(70, 620 + (id - 1) * interspaceBetweenMemes);
            meme.downvote.BackgroundImageLayout = ImageLayout.Zoom;
            meme.downvote.Size = new Size(52, 40);
            meme.downvote.TabStop = false;
            meme.downvote.FlatStyle = FlatStyle.Flat;
            if (meme.isDownvoteClicked) meme.downvote.BackgroundImage = imgDownvoteClicked;
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

            MainPage.mainPage.BringEverythingToFront();
        }

        private static void MouseWheel(object sender, MouseEventArgs e)
        {
            MainPage.mainPage.MouseWheel(sender, e);
        }

        void UpvoteClick(object sender, MouseEventArgs e)
        {
            isUpvoteClicked = !isUpvoteClicked;
            Button btn = (Button)sender;
            if(isUpvoteClicked) btn.BackgroundImage = imgUpvoteClicked;
            else btn.BackgroundImage = imgUpvoteNormal;

            if (isDownvoteClicked && isUpvoteClicked)
            {
                isDownvoteClicked = false;
                downvote.BackgroundImage = imgDownvoteNormal;
            }
        }

        void DownvoteClick(object sender, MouseEventArgs e)
        {
            isDownvoteClicked = !isDownvoteClicked;
            Button btn = (Button)sender;
            if (isDownvoteClicked) btn.BackgroundImage = imgDownvoteClicked;
            else btn.BackgroundImage = imgDownvoteNormal;

            if(isDownvoteClicked && isUpvoteClicked)
            {
                isUpvoteClicked = false;
                upvote.BackgroundImage = imgUpvoteNormal;
            }
        }

        ///<summary>
        ///Moves all memes up or down
        ///</summary>
        public static void SetLocation(float height)
        {
            for(int i = 0; i<memes.Count; i++)
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
