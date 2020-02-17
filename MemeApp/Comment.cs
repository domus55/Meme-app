﻿using System;
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
        public Image image;
        private Label lblUsername;
        private Label lblText;
        private PictureBox picBoxUserImage;
        private const int interspaceBetweenComments = 500;

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
            Comment comment = DataAccess.ShowComments(id + memesNotFound);

            while (comment.text == null)
            {
                memesNotFound++;
                comment = DataAccess.ShowComments(id + memesNotFound);
            }

            //Initialize username label
            comment.lblUsername.Text = comment.username;
            comment.lblUsername.ForeColor = Color.FromArgb(150, 255, 255, 255);
            comment.lblUsername.Font = new Font("Arial", 22);
            comment.lblUsername.AutoSize = true;

            //Initialize text label
            comment.lblText.Text = comment.text;
            comment.lblText.ForeColor = Color.FromArgb(255, 255, 255, 255);
            comment.lblText.Font = new Font("Arial", 14);
            comment.lblText.AutoSize = true;

            //Initialize user picturebox
            comment.picBoxUserImage = new PictureBox();
            comment.picBoxUserImage.Image = comment.image;
            comment.picBoxUserImage.Height = 50;
            comment.picBoxUserImage.Width = 50;
            comment.picBoxUserImage.SizeMode = PictureBoxSizeMode.Zoom;

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
            SetLocation();

            

            //MainPage.mainPage.BringEverythingToFront();
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
                comments[i].lblUsername.Location = new Point(70, height + 800 + interspaceBetweenComments * i);
                comments[i].lblText.Location = new Point(70, height + 840 + interspaceBetweenComments * i);
                comments[i].picBoxUserImage.Location = new Point(10, height + 800 + interspaceBetweenComments * i);
            }
        }
    }
}
