using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemeApp
{
    public static class DataAccess
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
                string com = "Insert into Memes(Creator_Id, Title, Image) values(@Id, @Title, @Img)";
                SqlCommand command = new SqlCommand(com, connection);

                command.Parameters.Add("Id", SqlDbType.VarChar).Value = Account.id;
                command.Parameters.Add("Title", SqlDbType.VarChar).Value = title;
                command.Parameters.Add("Img", SqlDbType.Image).Value = img;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static Meme ShowImage(int id)
        {
            Meme meme = new Meme();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "Select Title, Image, Points from Memes Where id=@id";
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
                        meme.points = (int)reader[2];
                        meme.id = id;
                    }
                }

                com = "Select Points from Points where User_id = @User_id AND Meme_id = @Meme_id";
                command = new SqlCommand(com, connection);
                command.Parameters.Add("@User_id", SqlDbType.Int).Value = Account.id;
                command.Parameters.Add("@Meme_id", SqlDbType.Int).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        meme.pointsAddedByThisUser = (int)reader[0];
                    }
                }
                connection.Close();
            }

            return meme;
        }

        public static bool LogIn(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "dbo.LogIn";
                SqlCommand command = new SqlCommand(com, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Username", SqlDbType.NVarChar).Value = username;
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

                connection.Close();
                return canLogIn;
            }
        }

        public static bool CheckIfUsernameExists(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "dbo.CheckIfUsernameExists";
                SqlCommand command = new SqlCommand(com, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Username", SqlDbType.NVarChar).Value = username;

                connection.Open();

                bool exists = true;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == "0") exists = false;
                    }
                }

                connection.Close();
                return exists;
            }
        }

        public static int GetUserId(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "dbo.GetUserId";
                SqlCommand command = new SqlCommand(com, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Username", SqlDbType.NVarChar).Value = username;

                connection.Open();

                int id = 1;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader[0];
                    }
                }

                connection.Close();
                return id;
            }
        }

        public static void CreateNewUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "dbo.CreateNewUser";
                SqlCommand command = new SqlCommand(com, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("Password", SqlDbType.NVarChar).Value = password;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static int CountAllMemes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "dbo.CountAllMemes";
                SqlCommand command = new SqlCommand(com, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                int Count = 1;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Count = (int)reader[0];
                    }
                }

                connection.Close();
                return Count;
            }
        }

        public static void AddPointsToMeme(int memeId, int pointsToAdd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int points = CountPointsInMeme(memeId);

                string com = "update Memes SET points=@points where id=@id";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = memeId;
                command.Parameters.Add("@points", SqlDbType.Int).Value = points + pointsToAdd;
                connection.Open();
                command.ExecuteNonQuery();

                com = "select count(id) from Points where User_id = @User_id AND Meme_id = @Meme_id";
                command = new SqlCommand(com, connection);
                command.Parameters.Add("@User_id", SqlDbType.Int).Value = Account.id;
                command.Parameters.Add("@Meme_id", SqlDbType.Int).Value = memeId;

                bool memeHasAlreadyVote = false;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[0] == 1) memeHasAlreadyVote = true;
                    }
                    reader.Close();
                }

                if(memeHasAlreadyVote)
                {
                    com = "UPDATE Points SET Points = @Points where User_id = @User_id AND Meme_id = @Meme_id";
                    command = new SqlCommand(com, connection);
                    command.Parameters.Add("@User_id", SqlDbType.Int).Value = Account.id;
                    command.Parameters.Add("@Meme_id", SqlDbType.Int).Value = memeId;
                    command.Parameters.Add("@Points", SqlDbType.Int).Value = pointsToAdd;
                    command.ExecuteNonQuery();
                }
                else
                {
                    com = "Insert into points(User_id, Meme_id, Points) values (@User_id, @Meme_id, @Points)";
                    command = new SqlCommand(com, connection);
                    command.Parameters.Add("@User_id", SqlDbType.Int).Value = Account.id;
                    command.Parameters.Add("@Meme_id", SqlDbType.Int).Value = memeId;
                    command.Parameters.Add("@Points", SqlDbType.Int).Value = pointsToAdd;
                    command.ExecuteNonQuery();
                }
            }
        }

        public static int CountPointsInMeme(int memeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "Select Points from Memes where id = @id";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = memeId;

                connection.Open();
                int points = 0;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        points = (int)reader[0];
                    }
                    reader.Close();
                }

                return points;
            }
        }
    }
}
