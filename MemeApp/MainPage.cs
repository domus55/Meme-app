using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MemeApp
{
    public partial class MainPage : Form
    {
        AddMeme formAddMeme = new AddMeme();
        LogIn formLogIn = new LogIn();

        float height = 0;
        List<PictureBox> pics = new List<PictureBox>();
        List<Label> titles = new List<Label>();

        public MainPage()
        {
            InitializeComponent();
            this.LblWheelHandler.MouseWheel += MouseWheel;
            AddMeme.GetReferenceToMainForm(this);
            Account.GetReferenceToMainForm(this);
            Account.LoadDataFromFile();
            if (Account.login == "Guest")
            {
                PicBoxUserIcon.Enabled = false;
                PicBoxUserIcon.Visible = false;
            }
            else
            {
                BtnLogIn.Enabled = false;
                BtnLogIn.Visible = false;
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            ShowMeme(1);
            ShowMeme(2);
            ShowMeme(3);
        }

        //Moves images and titles up and down whenever user uses wheel
        private void MouseWheel(object sender, MouseEventArgs e)
        {
            height += e.Delta * 0.2f;

            for(int i = 0; i<titles.Count; i++)
            {
                titles[i].Location = new Point(10, (int)height + i * 600);
            }

            for (int i = 0; i < pics.Count; i++)
            {
                pics[i].Location = new Point(10, (int)height + 50 + i * 600);
            }
        }

        //Shows meme with an specific id
        private void ShowMeme(int id)
        {
            Meme meme = DataAccess.ShowImage(id);

            Label lbl = new Label();
            lbl.Text = meme.title;
            lbl.ForeColor = Color.FromArgb(255, 255, 255, 255);
            lbl.Location = new Point(10, 0 + (id-1)*600);
            lbl.Font = new Font("Arial", 30);
            lbl.AutoSize = true;

            PictureBox pic = new PictureBox();
            pic.Image = meme.image;
            pic.Location = new Point(10, 50 + (id - 1) * 600);
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
    }
}
