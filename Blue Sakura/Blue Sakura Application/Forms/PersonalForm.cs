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
using Blue_Sakura_Application.Enum;

namespace Blue_Sakura_Application.Forms
{
    public partial class PersonalForm : Form
    {
        AllEntertainment entertainments;
        AllUser users;
        PersonalEntertainment personalEntertainment;
        User loggedUser;

        public PersonalForm(AllUser users, AllEntertainment entertainments, User loggedUser, PersonalEntertainment personalEntertainment)
        {
            InitializeComponent();
            this.entertainments = entertainments;
            this.users = users;
            this.personalEntertainment = personalEntertainment;
            this.loggedUser = loggedUser;

            tbxPersonalEntertainment.Text = personalEntertainment.Entertainment.Title;

            foreach (PersonalStatusType p in System.Enum.GetValues(typeof(PersonalStatusType)))
            {
                cbxPersonalStatus.Items.Add(p);
            }

            if (personalEntertainment.Entertainment is Anime)
            {
                cbxPersonalStatus.Items.Remove(PersonalStatusType.READING);
                lblProgress.Text = ((Anime)personalEntertainment.Entertainment).NrOfEpisode.ToString();
                nudProgress.Maximum = ((Anime)personalEntertainment.Entertainment).NrOfEpisode;
                nudProgress.Minimum = 1;
                nudProgress.Value = personalEntertainment.Progress;
            }
            else if (personalEntertainment.Entertainment is Manga)
            {
                cbxPersonalStatus.Items.Remove(PersonalStatusType.WATCHING);
                lblProgress.Text = ((Manga)personalEntertainment.Entertainment).Chapters.ToString();
                nudProgress.Maximum = ((Manga)personalEntertainment.Entertainment).Chapters;
                nudProgress.Minimum = 1;
                nudProgress.Value = personalEntertainment.Progress;
            }

            cbxPersonalStatus.SelectedItem = (PersonalStatusType)personalEntertainment.Status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            personalEntertainment.Progress = (int)nudProgress.Value;
            personalEntertainment.Status = (PersonalStatusType)cbxPersonalStatus.SelectedItem;
            MessageBox.Show("Changes have been applied");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            loggedUser.PersonalEntertainments.Remove(personalEntertainment);
            this.Hide();
            Form index = new index(users, entertainments, loggedUser);
            index.ShowDialog();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form index = new index(users, entertainments, loggedUser);
            index.ShowDialog();
            this.Close();
        }

    }
}
