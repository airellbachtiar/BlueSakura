using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace WADAssignmentS2
{
    public class User
    {
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Insert email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        public string Name { get; set; }

        public int ID { get; set; }

        public string Picture { get; set; }

        public User()
        {
            
        }

        public User(int id, string name, string username, string email, string password, string picture)
        {
            this.ID = id;
            this.Name = name;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.Picture = picture;
        }
    }
}
