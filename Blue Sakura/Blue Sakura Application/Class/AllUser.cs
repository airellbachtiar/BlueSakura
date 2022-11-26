using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Application.Class
{
    public class AllUser
    {
        private List<User> users;

        public AllUser()
        {
            users = new List<User>();
        }

        public List<User> Users
        { get { return users; } }

        public bool addUser(User user)
        {
            bool check = true;
            foreach (User u in users)
            {
                if (u.Username == user.Username)
                {
                    check = false;
                }
            }
            if (check)
            { users.Add(user); }
            return check;
        }

        public User GetUser(int id)
        {
            User user = null;
            foreach (User u in users)
            {
                if (u.Id == id)
                { user = u; }
            }
            return user;
        }
    }
}
