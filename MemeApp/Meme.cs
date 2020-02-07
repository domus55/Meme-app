using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Label lblTitle;
        public PictureBox picBoxImage;

        /// <summary>
        /// Shows meme with provided id
        /// </summary>
        public static void ShowMeme(int id)
        {
            Meme meme = DataAccess.ShowImage(id);

            meme.lblTitle = new Label();
            meme.lblTitle.Text = meme.title;
            meme.lblTitle.ForeColor = Color.FromArgb(255, 255, 255, 255);
            meme.lblTitle.Location = new Point(10, 50 + (id - 1) * 600);
            meme.lblTitle.Font = new Font("Arial", 30);
            meme.lblTitle.AutoSize = true;

            meme.picBoxImage = new PictureBox();
            meme.picBoxImage.Image = meme.image;
            meme.picBoxImage.Location = new Point(10, 100 + (id - 1) * 600);
            Size size = meme.picBoxImage.GetPreferredSize(new Size(1000, 500));
            float scale = size.Height / 500f;
            meme.picBoxImage.Height = 500;
            meme.picBoxImage.Width = (int)(size.Width / scale);
            meme.picBoxImage.SizeMode = PictureBoxSizeMode.Zoom;

            //enables scrolling with wheel
            meme.picBoxImage.MouseWheel += MainPage.mainPage.MouseWheel;
            meme.lblTitle.MouseWheel += MouseWheel;

            MainPage.mainPage.Controls.Add(meme.lblTitle);
            MainPage.mainPage.Controls.Add(meme.picBoxImage);

            meme.lblTitle.BringToFront();
            meme.picBoxImage.BringToFront();
            memes.Add(meme);

            MainPage.mainPage.BringEverythingToFront();
        }

        private static void MouseWheel(object sender, MouseEventArgs e)
        {
            MainPage.mainPage.MouseWheel(sender, e);
        }

        ///<summary>
        ///Moves all memes up or down
        ///</summary>
        public static void SetLocation(float height)
        {
            for(int i = 0; i<memes.Count; i++)
            {
                memes[i].lblTitle.Location = new Point(10, (int)height + 50 + i * 600);
                memes[i].picBoxImage.Location = new Point(10, (int)height + 100 + i * 600);
            }
        }
    }
}
