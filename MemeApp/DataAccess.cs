using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MemeApp
{
    public static class DataAccess
    {
        static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Meme"].ConnectionString;

        /// <summary>
        /// Saves meme into database
        /// </summary>
        public static void SaveImage(string title, string picLoc)
        {
            byte[] img = null;
            FileStream fs = new FileStream(picLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "Insert into Memes(Creator_Id, Title, Image, Points, Comments) values(@Id, @Title, @Img, 0, 0)";
                SqlCommand command = new SqlCommand(com, connection);

                command.Parameters.Add("Id", SqlDbType.VarChar).Value = Account.id;
                command.Parameters.Add("Title", SqlDbType.VarChar).Value = title;
                command.Parameters.Add("Img", SqlDbType.Image).Value = img;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Returns meme with provided id
        /// </summary>
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
                        meme.idInDatabase = id;
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

        /// <summary>
        /// Returns comment with provided id
        /// </summary>
        public static Comment ShowComment(int id)
        {
            Comment comment = new Comment();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "Select Accounts.Username, Accounts.Image, Comments.CommentText from Comments, Accounts where Comments.id=@id AND Comments.userId = Accounts.id";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.Add("id", SqlDbType.VarChar).Value = id;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader[0].ToString();
                        byte[] img = (byte[])reader[1];
                        string text = reader[2].ToString();
                        

                        MemoryStream ms = new MemoryStream(img);

                        comment.username = username;
                        comment.image = Image.FromStream(ms);
                        comment.text = text;
                        comment.idInDatabase = id;
                    }
                }

                /*com = "Select Points from Points where User_id = @User_id AND Meme_id = @Meme_id";
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
                connection.Close();*/
            }

            return comment;
        }

        /// <summary>
        /// Returns list of comments ids of meme
        /// </summary>
        public static List<int> ReturnCommentsIds(int memeId)
        {
            List<int> comments = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "Select id from Comments where memeId=@memeId";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.Add("memeId", SqlDbType.VarChar).Value = memeId;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comments.Add((int)reader[0]);
                    }
                }
            }
            return comments;
        }

        /// <summary>
        /// Returns true if there is user with this username and provided password
        /// </summary>
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

        /// <summary>
        /// Returns image of user with provided id
        /// </summary>
        public static Image GetUserImage(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "select image from accounts where id = @id";
                SqlCommand command = new SqlCommand(com, connection);

                command.Parameters.Add("id", SqlDbType.Int).Value = userId;

                connection.Open();

                MemoryStream ms = new MemoryStream();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] img = (byte[])reader[0];

                        ms = new MemoryStream(img);
                    }
                }

                connection.Close();
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// Returns true if this username already exists in the database
        /// </summary>
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

        /// <summary>
        /// Returns id of the username
        /// </summary>
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

        /// <summary>
        /// Creates new user with provided username and password in the database
        /// </summary>
        public static void CreateNewUser(string username, string password)
        {
            string picLoc = "Images/UserIcons/Default.png";
            byte[] img = null;
            FileStream fs = new FileStream(picLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "dbo.CreateNewUser";
                SqlCommand command = new SqlCommand(com, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("Password", SqlDbType.NVarChar).Value = password;
                command.Parameters.Add("Image", SqlDbType.Image).Value = img;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Returns how many memes are in the database;
        /// </summary>
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

        /// <summary>
        /// Adds or substract points in meme with provided id
        /// Don't forget to call 'SetPointsOnMeme' method to save what user clicked
        /// </summary>
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
            }
        }

        /// <summary>
        /// Saves to database if user clicked upvote(point = 1), downvote(points = -1), or clicked nothing(points = 0);
        /// </summary>
        public static void SetPointsOnMeme(int memeId, int points)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool memeHasAlreadyVote = false;
                string com = "select count(id) from Points where User_id = @User_id AND Meme_id = @Meme_id";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.Add("@User_id", SqlDbType.Int).Value = Account.id;
                command.Parameters.Add("@Meme_id", SqlDbType.Int).Value = memeId;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ((int)reader[0] == 1) memeHasAlreadyVote = true;
                    }
                    reader.Close();
                }

                if (memeHasAlreadyVote)
                {
                    com = "UPDATE Points SET Points = @Points where User_id = @User_id AND Meme_id = @Meme_id";
                    command = new SqlCommand(com, connection);
                    command.Parameters.Add("@User_id", SqlDbType.Int).Value = Account.id;
                    command.Parameters.Add("@Meme_id", SqlDbType.Int).Value = memeId;
                    command.Parameters.Add("@Points", SqlDbType.Int).Value = points;
                    command.ExecuteNonQuery();
                }
                else
                {
                    com = "Insert into points(User_id, Meme_id, Points) values (@User_id, @Meme_id, @Points)";
                    command = new SqlCommand(com, connection);
                    command.Parameters.Add("@User_id", SqlDbType.Int).Value = Account.id;
                    command.Parameters.Add("@Meme_id", SqlDbType.Int).Value = memeId;
                    command.Parameters.Add("@Points", SqlDbType.Int).Value = points;
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Returns how many points have meme with provided id
        /// </summary>
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

        /// <summary>
        /// Returns how many comments have meme with provided id
        /// </summary>
        public static int CountCommentsInMeme(int memeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "Select Comments from Memes where id = @id";
                SqlCommand command = new SqlCommand(com, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = memeId;

                connection.Open();
                int comments = 0;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comments = (int)reader[0];
                    }
                    reader.Close();
                }

                return comments;
            }
        }

        /// <summary>
        /// Adds comment to database
        /// </summary>
        public static void AddComment(int memeId, int userId, string commentText)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "dbo.AddComment";
                SqlCommand command = new SqlCommand(com, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@memeId", SqlDbType.Int).Value = memeId;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                command.Parameters.Add("@commentText", SqlDbType.NVarChar).Value = commentText;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void ChangeUserImage(int userId, string imgLoc)
        {
            byte[] img = null;
            FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "UPDATE Accounts SET Image = @Image where id = @id";
                SqlCommand command = new SqlCommand(com, connection);

                command.Parameters.Add("id", SqlDbType.VarChar).Value = userId;
                command.Parameters.Add("Image", SqlDbType.Image).Value = img;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void ChangePassword(int userId, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string com = "UPDATE Accounts SET Password = @Password where id = @id";
                SqlCommand command = new SqlCommand(com, connection);

                command.Parameters.Add("id", SqlDbType.VarChar).Value = userId;
                command.Parameters.Add("Password", SqlDbType.VarChar).Value = newPassword;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
