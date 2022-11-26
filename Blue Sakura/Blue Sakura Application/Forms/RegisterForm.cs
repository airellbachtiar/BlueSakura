using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using Blue_Sakura_Application.Class;

namespace Blue_Sakura_Application.Forms
{
    public partial class RegisterForm : Form
    {
        AllUser users = new AllUser();
        AllEntertainment entertainments;

        public RegisterForm(AllUser users, AllEntertainment entertainments)
        {
            InitializeComponent();
            this.users = users;
            this.entertainments = entertainments;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(tbxEmail.Text, @"(\w@\w.\w)"))
                    throw new Exception();
                else if (tbxRepeatPassword.Text != tbxPassword.Text)
                    throw new Exception();
                else if (users.addUser(new User(tbxEmail.Text, tbxUsername.Text, tbxPassword.Text)))
                {
                    MessageBox.Show("You have been registered");
                    this.Hide();
                    Form loginForm = new LoginForm(users, entertainments);
                    loginForm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to create an account");
            }
            finally
            {
                tbxEmail.Text = null;
                tbxPassword.Text = null;
                tbxRepeatPassword.Text = null;
                tbxUsername.Text = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form loginForm = new LoginForm(users, entertainments);
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
