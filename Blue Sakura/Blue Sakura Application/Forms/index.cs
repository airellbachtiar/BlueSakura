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
using Blue_Sakura_Application.Forms;

namespace Blue_Sakura_Application
{
    public partial class index : Form
    {
        User loggedUser;
        AllUser users = new AllUser();
        AllEntertainment entertainments = new AllEntertainment();
        private bool myListState;

        public index(AllUser users, AllEntertainment entertainments)
        {
            InitializeComponent();
            this.users = users;
            this.entertainments = entertainments;
            lblLoggedUser.Text = "-";
            myListState = false;
            btnLogout.Enabled = false;
            btnLogout.Hide();
            UpdateListView();
            UpdateComboBox();
        }

        public index(AllUser users, AllEntertainment entertainments, User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.users = users;
            this.entertainments = entertainments;
            btnLogin.Enabled = false;
            btnLogin.Hide();
            lblLoggedUser.Text = loggedUser.Username;
            myListState = false;
            UpdateListView();
            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            cbxFilter.Items.Add("All");
            cbxFilter.Items.Add("Anime");
            cbxFilter.Items.Add("Manga");

            cbxFilter.SelectedIndex = 0;
        }

        private void UpdateListView()
        {
            try
            {
                lsvEntertainment.Items.Clear();
                if (!myListState)
                {
                    foreach (Entertainment e in entertainments.GetAllEntertainments)
                    {
                        ListViewItem listViewItem = new ListViewItem(e.Id.ToString());
                        listViewItem.SubItems.Add(e.Title);
                        listViewItem.SubItems.Add(e.AlternateTitle);
                        listViewItem.SubItems.Add(e.MainGenre.ToString());
                        listViewItem.SubItems.Add(e.StartDate.ToString("dd/MM/yyyy"));
                        listViewItem.SubItems.Add(e.EndDate?.ToString("dd/MM/yyyy"));
                        listViewItem.SubItems.Add(e.Status.ToString());
                        listViewItem.SubItems.Add(e.Synopsis);
                        listViewItem.SubItems.Add(e.Description);
                        listViewItem.SubItems.Add(e.Type());

                        lsvEntertainment.Items.Add(listViewItem);
                    }
                }
                else if (myListState && loggedUser != null)
                {
                    foreach (Entertainment e in loggedUser.GetEntertainments())
                    {
                        ListViewItem listViewItem = new ListViewItem(e.Id.ToString());
                        listViewItem.SubItems.Add(e.Title);
                        listViewItem.SubItems.Add(e.AlternateTitle);
                        listViewItem.SubItems.Add(e.MainGenre.ToString());
                        listViewItem.SubItems.Add(e.StartDate.ToString("dd/MM/yyyy"));
                        listViewItem.SubItems.Add(e.EndDate?.ToString("dd/MM/yyyy"));
                        listViewItem.SubItems.Add(e.Status.ToString());
                        listViewItem.SubItems.Add(e.Synopsis);
                        listViewItem.SubItems.Add(e.Description);
                        listViewItem.SubItems.Add(e.Type());

                        lsvEntertainment.Items.Add(listViewItem);
                    }
                }
            }
            catch (Exception)
            { MessageBox.Show("Failed to load data"); }
        }

        private ListViewItem UpdateListView(Entertainment e)
        {
            ListViewItem listViewItem = new ListViewItem(e.Id.ToString());
            listViewItem.SubItems.Add(e.Title);
            listViewItem.SubItems.Add(e.AlternateTitle);
            listViewItem.SubItems.Add(e.MainGenre.ToString());
            listViewItem.SubItems.Add(e.StartDate.ToString("dd/MM/yyyy"));
            listViewItem.SubItems.Add(e.EndDate?.ToString("dd/MM/yyyy"));
            listViewItem.SubItems.Add(e.Status.ToString());
            listViewItem.SubItems.Add(e.Synopsis);
            listViewItem.SubItems.Add(e.Description);
            listViewItem.SubItems.Add(e.Type());

            return listViewItem;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form loginForm = new LoginForm(users, entertainments);
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            loggedUser = null;
            btnLogin.Enabled = true;
            btnLogin.Show();
            lblLoggedUser.Text = "-";
            btnLogout.Enabled = false;
            btnLogout.Hide();
        }

        private void btnAddNewEntertainment_Click(object sender, EventArgs e)
        {
            if (loggedUser != null && loggedUser.IsAdmin)
            {
                this.Hide();
                Form entertainmentForm = new EntertainmentForm(users, entertainments, loggedUser);
                entertainmentForm.ShowDialog();
                this.Close();
            }

        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsvEntertainment.Items.Clear();
            //Selected all
            if (cbxFilter.SelectedIndex == 0)
            {
                UpdateListView();
            }
            //Selected Anime
            else if (cbxFilter.SelectedIndex == 1)
            {
                if (!myListState)
                {
                    foreach (Entertainment en in entertainments.GetAllEntertainments)
                    {
                        if (en is Anime)
                        {
                            lsvEntertainment.Items.Add(UpdateListView(en));
                        }
                    }
                }
                else if (myListState && loggedUser != null)
                {
                    foreach (Entertainment en in loggedUser.GetEntertainments())
                    {
                        if (en is Anime)
                        {
                            lsvEntertainment.Items.Add(UpdateListView(en));
                        }
                    }
                }
            }
            //Selected Manga
            else if (cbxFilter.SelectedIndex == 2)
            {
                if (!myListState)
                {
                    foreach (Entertainment en in entertainments.GetAllEntertainments)
                    {
                        if (en is Manga)
                        {
                            lsvEntertainment.Items.Add(UpdateListView(en));
                        }
                    }
                }
                else if (myListState && loggedUser != null)
                {
                    foreach (Entertainment en in loggedUser.GetEntertainments())
                    {
                        if (en is Manga)
                        {
                            lsvEntertainment.Items.Add(UpdateListView(en));
                        }
                    }
                }
            }
        }

        private void lsvEntertainment_DoubleClick(object sender, EventArgs e)
        {
            if (loggedUser != null && !myListState)
            {
                int idSelected = int.Parse(lsvEntertainment.Items[lsvEntertainment.SelectedIndices[0]].SubItems[0].Text);
                this.Hide();
                Form entertainmentForm = new EntertainmentForm(users, entertainments, loggedUser, entertainments.GetEntertainment(idSelected));
                entertainmentForm.ShowDialog();
                this.Close();
            }
            else if (loggedUser != null && myListState)
            {
                int idSelected = int.Parse(lsvEntertainment.Items[lsvEntertainment.SelectedIndices[0]].SubItems[0].Text);
                this.Hide();
                Form personalEntertainmentForm = new PersonalForm(users, entertainments, loggedUser, loggedUser.GetPersonalEntertainment(idSelected));
                personalEntertainmentForm.ShowDialog();
                this.Close();
            }
            else
            {
                int idSelected = int.Parse(lsvEntertainment.Items[lsvEntertainment.SelectedIndices[0]].SubItems[0].Text);
                this.Hide();
                Form personalEntertainmentForm = new EntertainmentForm(users, entertainments, entertainments.GetEntertainment(idSelected));
                personalEntertainmentForm.ShowDialog();
                this.Close();
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (loggedUser != null && lsvEntertainment.SelectedItems.Count > 0)
            {
                int idSelected = int.Parse(lsvEntertainment.Items[lsvEntertainment.SelectedIndices[0]].SubItems[0].Text);
                if (!loggedUser.AddPersonalEntertainment(new PersonalEntertainment(entertainments.GetEntertainment(idSelected))))
                {
                    MessageBox.Show("You already added this entertainment");
                }
            }
        }

        private void btnAllList_Click(object sender, EventArgs e)
        {
            myListState = false;
            UpdateListView();
        }

        private void btnMyList_Click(object sender, EventArgs e)
        {
            myListState = true;
            UpdateListView();
        }
    }
}
