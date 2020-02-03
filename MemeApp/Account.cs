using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemeApp
{
    class Account
    {
        public static string username = "";
        public static string password = "";

        //Logs in user, if login or password is incorrect sets account to guest
        public static void LoadDataFromFile()
        {
            if (File.Exists("AccountData.txt"))
            {
                try
                {
                    string[] data = new string[2];

                    data = File.ReadAllLines("AccountData.txt");
                    username = data[0];
                    password = data[1];

                    if (!DataAccess.LogIn(username, password))
                    {
                        CreateAccountDataFile();
                    }
                }
                catch
                {
                    CreateAccountDataFile();
                }
            }
            else
            {
                CreateAccountDataFile();
            }
        }

        public static void CreateAccountDataFile(string username = "Guest", string password="")
        {
            string text = username + Environment.NewLine
                + password + Environment.NewLine;
            File.WriteAllText("AccountData.txt", text);

            Account.username = username;
            Account.password = password;
        }

        public static void CreateNewAccount(string username, string password)
        {

        }
    }
}
