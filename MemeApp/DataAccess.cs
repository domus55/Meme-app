using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemeApp
{
    class DataAccess
    {
        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Meme"].ConnectionString;

        public static void SaveImage(string title, string picLoc)
        {
            byte[] img = null;
            FileStream fs = new FileStream(picLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "Insert into Memes(Creator_Id, Title, Image) values(0, @Title, @Img)";
                SqlCommand command = new SqlCommand(com, connection);

                command.Parameters.Add("Title", SqlDbType.VarChar).Value = title;
                command.Parameters.Add("Img", SqlDbType.Image).Value = img;

                connection.Open();

                int x = command.ExecuteNonQuery();
                MessageBox.Show(x.ToString() + " record(s) saved");

                connection.Close();
            }
        }

        public static Meme ShowImage(int id)
        {
            Meme meme = new Meme();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "Select Title, Image from Memes Where id=@id";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.Add("id", SqlDbType.VarChar).Value = id;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader[0].ToString();
                        byte[] img = (byte[]) reader[1];

                        MemoryStream ms = new MemoryStream(img);

                        meme.image = Image.FromStream(ms);
                        meme.title = title;
                    }
                }

                connection.Close();
            }

            return meme;
        }

        public static bool LogIn(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "dbo.LogIn";
                SqlCommand command = new SqlCommand(com, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Login", SqlDbType.NVarChar).Value = login;
                command.Parameters.Add("Password", SqlDbType.NVarChar).Value = password;

                connection.Open();

                bool canLogIn = false;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == "1") canLogIn = true;
                    }
                }

                return canLogIn;
            }
        }
    }
}
