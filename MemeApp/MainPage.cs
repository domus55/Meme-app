﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MemeApp
{
    public partial class MainPage : Form
    {
        public static MainPage mainPage;
        AddMeme formAddMeme = new AddMeme();
        LogIn formLogIn = new LogIn();

        float height = 0;
        List<PictureBox> pics = new List<PictureBox>();
        List<Label> titles = new List<Label>();

        public MainPage()
        {
            InitializeComponent();
            this.LblBackground.MouseWheel += MouseWheel;
            mainPage = this;
            Account.LoadDataFromFile();
            CheckIfIsLoggedIn();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            ShowAllMemes();
        }

        public void CheckIfIsLoggedIn()
        {
            if (Account.username == "Guest")
            {
                BtnLogIn.Enabled = true;
                BtnLogIn.Visible = true;

                PicBoxUserIcon.Enabled = false;
                PicBoxUserIcon.Visible = false;
            }
            else
            {
                BtnLogIn.Enabled = false;
                BtnLogIn.Visible = false;

                PicBoxUserIcon.Enabled = true;
                PicBoxUserIcon.Visible = true;
            }
        }

        //Moves images and titles up and down whenever user uses wheel
        private void MouseWheel(object sender, MouseEventArgs e)
        {
            height += e.Delta * 0.4f;
            if (height > 0) height = 0;

            for(int i = 0; i<titles.Count; i++)
            {
                titles[i].Location = new Point(10, (int)height + 50 + i * 600);
            }

            for (int i = 0; i < pics.Count; i++)
            {
                pics[i].Location = new Point(10, (int)height + 100 + i * 600);
            }
        }

        private void ShowAllMemes()
        {
            int allMemes = DataAccess.CountAllMemes();

            for(int i = 0; i<allMemes; i++)
            {
                ShowMeme(i+1);
            }
        }

        //Shows meme with an specific id
        public void ShowMeme(int id)
        {
            Meme meme = DataAccess.ShowImage(id);

            Label lbl = new Label();
            lbl.Text = meme.title;
            lbl.ForeColor = Color.FromArgb(255, 255, 255, 255);
            lbl.Location = new Point(10, 50 + (id-1)*600);
            lbl.Font = new Font("Arial", 30);
            lbl.AutoSize = true;

            PictureBox pic = new PictureBox();
            pic.Image = meme.image;
            pic.Location = new Point(10, 100 + (id - 1) * 600);
            Size size = pic.GetPreferredSize(new Size(1000, 500));
            float scale = size.Height / 500f;
            pic.Height = 500;
            pic.Width = (int)(size.Width / scale);
            pic.SizeMode = PictureBoxSizeMode.Zoom;

            //enables scrolling with wheel
            pic.MouseWheel += MouseWheel;
            lbl.MouseWheel += MouseWheel;

            this.Controls.Add(lbl);
            this.Controls.Add(pic);

            lbl.BringToFront();
            pic.BringToFront();
            PicBoxTopBar.BringToFront();
            BtnAddMeme.BringToFront();
            PicBoxUserIcon.BringToFront();
            BtnLogIn.BringToFront();

            pics.Add(pic);
            titles.Add(lbl);
        }

        private void BtnAddMeme_Click(object sender, EventArgs e)
        {
            formAddMeme.Show();
            formAddMeme.Location = this.Location;
            this.Hide();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            formLogIn.Show();
            formLogIn.Location = this.Location;
            this.Hide();
        }

        private void PicBoxUserIcon_Click(object sender, EventArgs e)
        {
            ShowAccountMenu();
        }

        private void LblBackground_Click(object sender, EventArgs e)
        {
            ShowAccountMenu(false);
        }

        //show account menu if it is hidden or hide it if it is visible
        private void ShowAccountMenu()
        {
            ShowAccountMenu(!PicBoxAccountMenu.Visible);
        }

        //show/hide account menu
        private void ShowAccountMenu(bool show)
        {
            PicBoxAccountMenu.Visible = show;
            BtnAccountSettings.Visible = show;
            BtnLogout.Visible = show;

            if(show)
            {
                PicBoxAccountMenu.BringToFront();
                BtnAccountSettings.BringToFront();
                BtnLogout.BringToFront();
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Account.CreateAccountDataFile();
            Account.LoadDataFromFile();
            CheckIfIsLoggedIn();
            ShowAccountMenu(false);
        }
    }
}