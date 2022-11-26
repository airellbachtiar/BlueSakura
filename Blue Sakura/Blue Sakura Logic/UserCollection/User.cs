using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Logic.UserCollection
{
    public class User
    {
        private static int idCounter = 1;

        private int id;
        private string name;
        private string email;
        private string username;
        private string password;
        private string salt;
        private string picture;
        private bool isAdmin = false;

        private int? personalListID;

        public User(string email, string username, string password, string salt)
        {
            id = idCounter;
            idCounter = idCounter + 1;

            this.email = email;
            this.username = username;
            this.password = password;
            this.salt = salt;
        }

        public User(int id, string name, string email, string username, string password, string salt, string picture, int? personalListID)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.picture = picture;
            this.personalListID = personalListID;
        }

        public int Id
        { get { return id; } }

        public string Name
        { get { return name; } set { name = value; } }

        public string Email
        { get { return email; } set { email = value; } }

        public string Username
        { get { return username; } set { username = value; } }

        public string Password
        { get { return password; } set { password = value; } }

        public string Salt
        { get { return salt; } set { Salt = value; } }

        public string Picture
        { get { return picture; } set { picture = value; } }

        public bool IsAdmin
        { get { return isAdmin; } set { isAdmin = value; } }

        public int? PersonalListID
        { get { return personalListID; } set { personalListID = value; } }
    }
}
