using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blue_Sakura_Logic.DAL;

namespace Blue_Sakura_Logic.UserCollection
{
    public class UserController
    {
        private List<User> users;

        public UserController()
        {
            users = UserDAL.GetAllUsers();
        }

        public List<User> Users
        { get { return users; } }

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
