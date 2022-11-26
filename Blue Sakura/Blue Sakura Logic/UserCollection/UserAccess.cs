using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blue_Sakura_Logic.DAL;

namespace Blue_Sakura_Logic.UserCollection
{
    public static class UserAccess
    {
        public static User Login(string username, string password)
        {
            User user = UserDAL.GetUser(username);
            if(user == null)
            {
                return null;
            }
            string passwordDB = HashSaltGenerator.GetHash(password, user.Salt);

            if (user == null || user.Password != passwordDB.ToString())
            {
                user = null;
            }

            return user;
        }

        public static bool RegisterUser(string email, string username, string password)
        {
            bool result = true;

            string salt = HashSaltGenerator.GetSalt();
            string hashPassword = HashSaltGenerator.GetHash(password, salt);
            User user = new User(email, username, hashPassword, salt);
            user.Picture = "default.jpg";
            
            if (!UserDAL.AddUser(user))
            {
                result = false;
            }

            return result;
        }
    }
}
