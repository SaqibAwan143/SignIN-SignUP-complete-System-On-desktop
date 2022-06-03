using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WindowsFormsApp4.BL;

namespace WindowsFormsApp4.DL
{
    class MUserDL
    {
        private static List<MUser> usersList = new List<MUser>();

        internal static List<MUser> UsersList { get => usersList; set => usersList = value; }

        public static void addUserIntoList(MUser user)
        {
            UsersList.Add(user);
        }

        public static MUser SignIn(MUser user)
        {
            foreach (MUser storedUser in UsersList)
            {
                if (storedUser.UserName == user.UserName && storedUser.UserPassword == user.UserPassword)
                {
                    return storedUser;
                }
            }
            return null;
        }

        public static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static bool readDataFromFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string userName = parseData(record, 1);
                    string userPassword = parseData(record, 2);
                    string userRole = parseData(record, 3);
                    MUser user = new MUser(userName, userPassword, userRole);
                    addUserIntoList(user);
                }
                fileVariable.Close();
                return true;
            }
            else
                return false;
        }

        public static void storeUserIntoFile(MUser user, string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.UserName + "," + user.UserPassword + "," + user.UserRole);
            file.Flush();
            file.Close();

        }

        public static void deleteUserFromList(MUser user)
        {
            for (int index = 0; index < usersList.Count; index++)
            {
                if (usersList[index].UserName == user.UserName && usersList[index].UserPassword == user.UserPassword)
                {
                    usersList.RemoveAt(index);
                }
            }

        }

        public static void EditUserFromList(MUser previous, MUser updated)
        {
            foreach (MUser user in usersList)
            {
                if (user.UserName == previous.UserName && user.UserPassword == previous.UserPassword)
                {
                    user.UserName = updated.UserName;
                    user.UserPassword = updated.UserPassword;
                    user.UserRole = updated.UserRole;
                }
            }

        }
        public static void storeAllDataIntoFile(string path)
        {
            StreamWriter file = new StreamWriter(path);
            foreach (MUser storedUser in UsersList)
            {

                file.WriteLine(storedUser.UserName + "," + storedUser.UserPassword + "," + storedUser.UserRole);
            }
            file.Flush();
            file.Close();

        }
    }
}
