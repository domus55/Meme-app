﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MemeApp
{
    public class Account
    {
        public static Image image;
        public static string username = "";
        public static string password = "";
        public static int id = 1;

        /// <summary>
        /// Logs in user using txt file, if login or password is incorrect sets account to guest
        /// </summary>
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

            id = DataAccess.GetUserId(username);
            image = DataAccess.GetUserImage(id);
        }

        public static void CreateAccountDataFile(string username = "Guest", string password="")
        {
            string text = username + Environment.NewLine
                + password + Environment.NewLine;
            File.WriteAllText("AccountData.txt", text);

            Account.username = username;
            Account.password = password;
            Account.id = DataAccess.GetUserId(username);
            image = DataAccess.GetUserImage(id);
        }

        ///<summary>
        ///<para>Creates new account if username is free </para>
        ///Returns false if username is already occupied
        ///</summary>
        public static bool CreateNewAccount(string username, string password)
        {
            if(DataAccess.CheckIfUsernameExists(username))
            {
                return false;
            }
            else
            {
                DataAccess.CreateNewUser(username, password);
                return true;
            }
        }
    }
}
