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
        public static int memesNotFound = 0;
        public string title;
        public Image image;
        public int idInDatabase;
        public int idInArray;
        public int pointsAddedByThisUser = 0;
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
            lblTitle = new Label();
            upvote = new Button();
            downvote = new Button();
            comments = new Button();

            upvote.MouseClick += UpvoteClick;
            downvote.MouseClick += DownvoteClick;
            comments.MouseClick += OpenMemeClick;
            lblTitle.MouseClick += OpenMemeClick;
        }

        /// <summary>
        /// Shows meme with provided id
        /// </summary>
        public static void ShowMeme(int id)
        {
            Meme meme = DataAccess.ShowImage(id + memesNotFound);

            while (meme.title == null)
            {
                memesNotFound++;
                meme = DataAccess.ShowImage(id + memesNotFound);
            }

            //Initialize title label
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
            meme.pointsAndComments = new Label();
            meme.ShowPointsAndComments();
            meme.pointsAndComments.AutoSize = true;
            if (MainPage.darkMode) meme.pointsAndComments.ForeColor = Color.FromArgb(150, 255, 255, 255);
            else meme.pointsAndComments.ForeColor = Color.FromArgb(150, 0, 0, 0);

            //Initialize upvote button
            meme.upvote.BackgroundImageLayout = ImageLayout.Zoom;
            meme.upvote.Size = new Size(52, 40);
            meme.upvote.TabStop = false;
            meme.upvote.FlatStyle = FlatStyle.Flat;
            meme.upvote.FlatAppearance.BorderSize = 0;
            if (meme.pointsAddedByThisUser == 1) meme.upvote.BackgroundImage = imgUpvoteClicked;
            else meme.upvote.BackgroundImage = imgUpvoteNormal;

            //Initialize downvote button
            meme.downvote.BackgroundImageLayout = ImageLayout.Zoom;
            meme.downvote.Size = new Size(52, 40);
            meme.downvote.TabStop = false;
            meme.downvote.FlatStyle = FlatStyle.Flat;
            meme.downvote.FlatAppearance.BorderSize = 0;
            if (meme.pointsAddedByThisUser == -1) meme.downvote.BackgroundImage = imgDownvoteClicked;
            else meme.downvote.BackgroundImage = imgDownvoteNormal;

            //Initialize comments button
            meme.comments.BackgroundImageLayout = ImageLayout.Zoom;
            meme.comments.Size = new Size(52, 40);
            meme.comments.TabStop = false;
            meme.comments.FlatStyle = FlatStyle.Flat;
            meme.comments.FlatAppearance.BorderSize = 0;
            meme.comments.Location = new Point(800, 400);
            meme.comments.BackgroundImage = imgComments;

            //Handle events
            meme.picBoxImage.MouseWheel += MouseWheel;
            meme.pointsAndComments.MouseWheel += MouseWheel;
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
            meme.comments.BringToFront();
            meme.idInArray = memes.Count;
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
                DataAccess.AddPointsToMeme(idInDatabase, 1);
                downvote.BackgroundImage = imgDownvoteNormal;
            }
            if (pointsAddedByThisUser == 1) pointsAddedByThisUser = 0;
            else pointsAddedByThisUser = 1;
            lblTitle.Focus();
            Button btn = (Button)sender;
            if (pointsAddedByThisUser == 1)
            {
                btn.BackgroundImage = imgUpvoteClicked;
                DataAccess.AddPointsToMeme(idInDatabase, 1);
            }
            else
            {
                DataAccess.AddPointsToMeme(idInDatabase, -1);
                btn.BackgroundImage = imgUpvoteNormal;
            }

            DataAccess.SetPointsOnMeme(idInDatabase, pointsAddedByThisUser);
            ShowPointsAndComments();   
        }

        void DownvoteClick(object sender, MouseEventArgs e)
        {
            if (pointsAddedByThisUser == 1)
            {
                upvote.BackgroundImage = imgUpvoteNormal;
                DataAccess.AddPointsToMeme(idInDatabase, -1);
            }
            if (pointsAddedByThisUser == -1) pointsAddedByThisUser = 0;
            else pointsAddedByThisUser = -1;

            lblTitle.Focus();
            Button btn = (Button)sender;

            if (pointsAddedByThisUser == -1)
            {
                btn.BackgroundImage = imgDownvoteClicked;
                DataAccess.AddPointsToMeme(idInDatabase, -1);
            }
            else
            {
                btn.BackgroundImage = imgDownvoteNormal;
                DataAccess.AddPointsToMeme(idInDatabase, 1);
            }

            DataAccess.SetPointsOnMeme(idInDatabase, pointsAddedByThisUser);
            ShowPointsAndComments();
        }

        void OpenMemeClick(object sender, MouseEventArgs e)
        {
            OpenMeme.thisFormIsShown = true;
            MainPage.formShowMeme.Show();
            MainPage.formShowMeme.Location = MainPage.mainPage.Location;
            MainPage.mainPage.Hide();

            OpenMeme.height = -45;
            OpenMeme.memeIdInArray = idInArray;
            OpenMeme.memeIdInDatabase = idInDatabase;
            OpenMeme.openMeme.OpenComments();
            OpenMeme.openMeme.Controls.Add(lblTitle);
            OpenMeme.openMeme.Controls.Add(picBoxImage);
            OpenMeme.openMeme.Controls.Add(pointsAndComments);
            OpenMeme.openMeme.Controls.Add(upvote);
            OpenMeme.openMeme.Controls.Add(downvote);
            OpenMeme.openMeme.Controls.Add(comments);

            comments.Visible = false;
            BringMemeToFront();

            SetLocation();
        }

        public static void CloseMeme(int memeId)
        {
            MainPage.mainPage.Controls.Add(memes[memeId].lblTitle);
            MainPage.mainPage.Controls.Add(memes[memeId].pointsAndComments);
            MainPage.mainPage.Controls.Add(memes[memeId].upvote);
            MainPage.mainPage.Controls.Add(memes[memeId].downvote);
            MainPage.mainPage.Controls.Add(memes[memeId].comments);
            MainPage.mainPage.Controls.Add(memes[memeId].picBoxImage);

            memes[memeId].BringMemeToFront();
            memes[memeId].comments.Visible = true;
            MainPage.mainPage.BringEverythingToFront();
            SetLocation();
        }

        public void ShowPointsAndComments()
        {
            pointsAndComments.Text = DataAccess.CountPointsInMeme(idInDatabase).ToString() + " points, " + DataAccess.CountCommentsInMeme(idInDatabase).ToString() + " comments";
        }

        private void BringMemeToFront()
        {
            lblTitle.BringToFront();
            pointsAndComments.BringToFront();
            upvote.BringToFront();
            downvote.BringToFront();
            comments.BringToFront();
            picBoxImage.BringToFront();
        }

        /// <summary>
        /// Sets position of title, picture, and buttons(upvote, downvote, comments) depending on height variable
        /// </summary>
        public static void SetLocation()
        {
            int height = (int)MainPage.mainPage.height;

            for (int i = 0; i<memes.Count; i++)
            {
                if(OpenMeme.thisFormIsShown)
                {
                    memes[i].lblTitle.Location = new Point(10, (int)OpenMeme.height + 50);
                    memes[i].picBoxImage.Location = new Point(10, (int)OpenMeme.height + 100);
                    memes[i].pointsAndComments.Location = new Point(10, (int)OpenMeme.height + 600);
                    memes[i].upvote.Location = new Point(10, (int)OpenMeme.height + 620);
                    memes[i].downvote.Location = new Point(70, (int)OpenMeme.height + 620);
                    if (Account.username == "Guest") memes[i].comments.Location = new Point(10, (int)OpenMeme.height + 620);
                    else memes[i].comments.Location = new Point(130, (int)OpenMeme.height + 620);
                }
                else
                {
                    memes[i].lblTitle.Location = new Point(10, (int)height + 50 + i * interspaceBetweenMemes);
                    memes[i].picBoxImage.Location = new Point(10, (int)height + 100 + i * interspaceBetweenMemes);
                    memes[i].pointsAndComments.Location = new Point(10, (int)height + 600 + i * interspaceBetweenMemes);
                    memes[i].upvote.Location = new Point(10, (int)height + 620 + i * interspaceBetweenMemes);
                    memes[i].downvote.Location = new Point(70, (int)height + 620 + i * interspaceBetweenMemes);
                    if (Account.username == "Guest") memes[i].comments.Location = new Point(10, (int)height + 620 + i * interspaceBetweenMemes);
                    else memes[i].comments.Location = new Point(130, (int)height + 620 + i * interspaceBetweenMemes);
                }
            }
        }

        public void SetDarkMode()
        {
            if (MainPage.darkMode)
            {
                lblTitle.BackColor = Color.FromArgb(255, 25, 25, 30);
                lblTitle.ForeColor = Color.FromArgb(255, 255, 255, 255);
                picBoxImage.BackColor = Color.FromArgb(255, 25, 25, 30);
                upvote.BackColor = Color.FromArgb(255, 0, 0, 0);
                downvote.BackColor = Color.FromArgb(255, 0, 0, 0);
                comments.BackColor = Color.FromArgb(255, 0, 0, 0);
                pointsAndComments.BackColor = Color.FromArgb(255, 25, 25, 30);
                pointsAndComments.ForeColor = Color.FromArgb(255, 255, 255, 255);
            }
            else
            {
                lblTitle.BackColor = Color.FromArgb(255, 255, 255, 255);
                lblTitle.ForeColor = Color.FromArgb(255, 0, 0, 0);
                picBoxImage.BackColor = Color.FromArgb(255, 255, 255, 255);
                upvote.BackColor = Color.FromArgb(255, 255, 255, 255);
                downvote.BackColor = Color.FromArgb(255, 255, 255, 255);
                comments.BackColor = Color.FromArgb(255, 255, 255, 255);
                pointsAndComments.BackColor = Color.FromArgb(255, 255, 255, 255);
                pointsAndComments.ForeColor = Color.FromArgb(255, 0, 0, 0);
            }
        }

        public static void SetDarkModeToAll()
        {
            for (int i = 0; i<memes.Count; i++)
            {
                memes[i].SetDarkMode();
            }
        }
    }
}
