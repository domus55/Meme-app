using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace MemeApp
{
    public partial class MainPage : Form
    {
        public static MainPage mainPage;
        public static OpenMeme formShowMeme = new OpenMeme();
        public static bool darkMode = true;
        public static bool noInternetConnection = false;
        AddMeme formAddMeme = new AddMeme();
        LogIn formLogIn = new LogIn();
        Label lblYouHaveToLogInFirst = new Label();
        Button btnLoginRegister = new Button();

        public float height = 0;
        List<PictureBox> pics = new List<PictureBox>();
        List<Label> titles = new List<Label>();

        public MainPage()
        {
            InitializeComponent();
            this.LblBackground.MouseWheel += MouseWheel;
            mainPage = this;
            try
            {
                Account.LoadDataFromFile();
            }
            catch
            {
                //No internet connection
                Label errorMessage = new Label();
                errorMessage.AutoSize = false;
                errorMessage.TextAlign = ContentAlignment.MiddleCenter;
                errorMessage.Dock = DockStyle.Fill;
                errorMessage.Text = "No internet connection!";
                errorMessage.Font = new Font("Microsoft Sans Serif", 20);
                errorMessage.ForeColor = Color.FromArgb(255, 255, 255, 255);
                errorMessage.BringToFront();
                LblBackground.Visible = false;
                mainPage.Controls.Add(errorMessage);

                noInternetConnection = true;
            }
            
            CheckIfIsLoggedIn();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            if(!noInternetConnection) ShowAllMemes();
            this.Controls.Add(lblYouHaveToLogInFirst);
            this.Controls.Add(btnLoginRegister);
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

        public void BringEverythingToFront()
        {
            PicBoxTopBar.BringToFront();
            BtnAddMeme.BringToFront();
            PicBoxUserIcon.BringToFront();
            BtnLogIn.BringToFront();
        }

        ///<summary>
        ///Moves images and titles up and down whenever user uses wheel
        ///</summary>
        public void MouseWheel(object sender, MouseEventArgs e)
        {
            if(OpenMeme.thisFormIsShown)
            {
                OpenMeme.height += e.Delta * 0.4f;
                if (OpenMeme.height > -45) OpenMeme.height = -45;
                OpenMeme.openMeme.SetLocation();
                Comment.SetLocation();
            }
            else
            {
                height += e.Delta * 0.4f;
                if (height > 0) height = 0;
            }

            Meme.SetLocation();
        }

        private void ShowAllMemes()
        {
            int allMemes = DataAccess.CountAllMemes();

            for(int i = 0; i<allMemes; i++)
            {
                Meme.ShowMeme(i+1);
            }
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

        /// <summary>
        /// Shows account menu if it is hidden or hide it if it is visible
        /// </summary>
        private void ShowAccountMenu()
        {
            ShowAccountMenu(!PicBoxAccountMenu.Visible);
        }

        /// <summary>
        /// Show/hide account menu
        /// </summary>
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
            ReloadForm();
        }

        public void ReloadForm()
        {
            Meme.memes.Clear();
            Meme.memesNotFound = 0;
            this.Controls.Clear();
            this.InitializeComponent();
            ShowAllMemes();
            this.LblBackground.MouseWheel += MouseWheel;
            CheckIfIsLoggedIn();
        }
    }
}