using System;
using MemeApp;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void LoadDataFromFile_FileDontExists_CreateNewFile()
        {
            if (File.Exists("AccountData.txt")) File.Delete("AccountData.txt");
            Account.LoadDataFromFile();


            Assert.IsTrue(File.Exists("AccountData.txt"));

            if(File.Exists("AccountData.txt"))
            {
                string[] data = new string[2];

                data = File.ReadAllLines("AccountData.txt");
                string username = data[0];
                string password = data[1];

                Assert.AreEqual(username, "Guest");
                Assert.AreEqual(Account.username, "Guest");
                Assert.AreEqual(password, "");
                Assert.AreEqual(Account.password, "");
            }
        }

        [TestMethod]
        public void LoadDataFromFile_FileIsEmpty_CreateNewFile()
        {
            File.WriteAllText("AccountData.txt", "");

            Account.LoadDataFromFile();

            Assert.IsTrue(File.Exists("AccountData.txt"));

            if (File.Exists("AccountData.txt"))
            {
                string[] data = new string[2];

                data = File.ReadAllLines("AccountData.txt");
                string username = data[0];
                string password = data[1];

                Assert.AreEqual(username, "Guest");
                Assert.AreEqual(Account.username, "Guest");
                Assert.AreEqual(password, "");
                Assert.AreEqual(Account.password, "");
            }
        }

        [TestMethod]
        public void LoadDataFromFile_IncorrectData_CreateNewFile()
        {
            string text = "Guest" + Environment.NewLine
                + "asfdsfsdf" + Environment.NewLine;
            File.WriteAllText("AccountData.txt", text);

            Account.LoadDataFromFile();

            Assert.IsTrue(File.Exists("AccountData.txt"));

            if (File.Exists("AccountData.txt"))
            {
                string[] data = new string[2];

                data = File.ReadAllLines("AccountData.txt");
                string username = data[0];
                string password = data[1];

                Assert.AreEqual(username, "Guest");
                Assert.AreEqual(Account.username, "Guest");
                Assert.AreEqual(password, "");
                Assert.AreEqual(Account.password, "");
            }
        }

        [TestMethod]
        public void CreateAccountDataFile_NormalInput_CreatesAccountDataFileWithProvidedUsernameAndPassword()
        {
            Account.CreateAccountDataFile("Adam", "asd");
            Assert.IsTrue(File.Exists("AccountData.txt"));

            if (File.Exists("AccountData.txt"))
            {
                string[] data = new string[2];

                data = File.ReadAllLines("AccountData.txt");
                string username = data[0];
                string password = data[1];

                Assert.AreEqual(username, "Adam");
                Assert.AreEqual(Account.username, "Adam");
                Assert.AreEqual(password, "asd");
                Assert.AreEqual(Account.password, "asd");
            }
        }
    }
}
