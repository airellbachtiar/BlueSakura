using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Application.Class
{
    public class User
    {
        private static int idCounter = 1;

        private int id;
        private string email;
        private string username;
        private string password;
        private bool isAdmin;

        private List<PersonalEntertainment> personalEntertainments;

        public User(string email, string username, string password)
        {
            id = idCounter;
            idCounter = idCounter + 1;

            this.email = email;
            this.username = username;
            this.password = password;
            this.isAdmin = false;

            personalEntertainments = new List<PersonalEntertainment>();
        }

        public int Id
        { get { return id; } }

        public string Username
        { get { return username; } }

        public string Password
        { get { return password; } }
        public bool IsAdmin
        { get { return isAdmin; } set { isAdmin = value; } }

        public List<PersonalEntertainment> PersonalEntertainments
        { get { return personalEntertainments; } }

        public bool AddPersonalEntertainment(PersonalEntertainment personalEntertainment)
        {
            bool check = true;
            foreach (PersonalEntertainment p in personalEntertainments)
            {
                if(p.Entertainment == personalEntertainment.Entertainment)
                {
                    check = false;
                }
            }
            if(check)
            {
                personalEntertainments.Add(personalEntertainment);
            }
            return check;
        }

        public PersonalEntertainment GetPersonalEntertainment(int id)
        {
            PersonalEntertainment personalEntertainment = null;
            foreach(PersonalEntertainment p in personalEntertainments)
            {
                if(p.Entertainment.Id == id)
                {
                    personalEntertainment = p;
                }
            }
            return personalEntertainment;
        }

        public List<Entertainment> GetEntertainments()
        {
            List<Entertainment> entertainments = new List<Entertainment>();
            foreach(PersonalEntertainment p in PersonalEntertainments)
            {
                entertainments.Add(p.Entertainment);
            }
            return entertainments;
        }

        public Entertainment GetEntertainment(int id)
        {
            Entertainment entertainment = null;
            foreach(PersonalEntertainment p in personalEntertainments)
            {
                if(p.Entertainment.Id == id)
                {
                    entertainment = p.Entertainment;
                }
            }
            return entertainment;
        }
    }
}
