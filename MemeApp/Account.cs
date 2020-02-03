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
        static MainPage mainForm;
        static string login = "";
        static string password = "";
        
        public static void GetReferenceToMainForm(MainPage main)
        {
            mainForm = main;
        }

        //Loads name, isLoggedIn variable from txt file;
        public static void LoadDataFromFile()
        {
            if (File.Exists("AccountData.txt"))
            {
                try
                {
                    string[] data = new string[2];

                    data = File.ReadAllLines("AccountData.txt");
                    login = data[0];
                    password = data[1];

                    if (DataAccess.LogIn(login, password))
                    {
                        MessageBox.Show("Udalo sie!");
                    }
                    else
                    {
                        CreateAccountDataFile();
                        LoadDataFromFile();
                    }
                }
                catch
                {
                    CreateAccountDataFile();
                    LoadDataFromFile();
                }
            }
            else
            {
                CreateAccountDataFile();
                LoadDataFromFile();
            }
        }

        static void CreateAccountDataFile()
        {
            string text = "Guest" + Environment.NewLine //username
                + "" + Environment.NewLine;             //password
            File.WriteAllText("AccountData.txt", text);
        }
    }
}
