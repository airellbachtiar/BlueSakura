using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Blue_Sakura_Application.Class;

namespace Blue_Sakura_Application.Forms
{
    public partial class LoginForm : Form
    {
        AllUser users;
        AllEntertainment entertainments;

        public LoginForm(AllUser users, AllEntertainment entertainments)
        {
            InitializeComponent();
            this.users = users;
            this.entertainments = entertainments;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;
            try
            {
                username = tbxUsername.Text;
                password = tbxPassword.Text;
                foreach (User u in users.Users)
                {
                    if (username == u.Username && password == u.Password)
                    {
                        this.Hide();
                        Form index = new index(users, entertainments, u);
                        index.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form registerForm = new RegisterForm(users, entertainments);
            registerForm.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form index = new index(users, entertainments);
            index.ShowDialog();
            this.Close();
        }
    }
}
