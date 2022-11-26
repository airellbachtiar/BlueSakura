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
    public partial class EntertainmentForm : Form
    {
        AllUser users;
        AllEntertainment entertainments;
        User loggedUser;
        Entertainment entertainment;

        //Add item constructor
        public EntertainmentForm(AllUser users, AllEntertainment entertainments, User loggedUser)
        {
            InitializeComponent();
            this.users = users;
            this.entertainments = entertainments;
            this.loggedUser = loggedUser;
            btnEdit.Enabled = false;
            btnEdit.Hide();
            btnRemove.Enabled = false;
            btnRemove.Hide();
            InitializeComboBox();
            cbxMainGenre.SelectedIndex = 0;
            cbxType.SelectedIndex = 0;
            chbxEndDate.Checked = true;

            lblAuthor.Hide();
            lblVolumes.Hide();
            lblChapters.Hide();
            tbxAuthor.Hide();
            nudVolumes.Hide();
            nudChapters.Hide();
        }

        //Edit or view as user item constructor
        public EntertainmentForm(AllUser users, AllEntertainment entertainments, User loggedUser, Entertainment entertainment)
        {
            this.users = users;
            this.entertainments = entertainments;
            this.loggedUser = loggedUser;
            this.entertainment = entertainment;
            ViewEntertainmentSetup();
        }

        //View only
        public EntertainmentForm(AllUser users, AllEntertainment entertainments, Entertainment entertainment)
        {
            this.users = users;
            this.entertainments = entertainments;
            this.entertainment = entertainment;
            ViewEntertainmentSetup();
        }

        private void ViewEntertainmentSetup()
        {
            InitializeComponent();

            btnAdd.Hide();
            btnAdd.Enabled = false;
            InitializeComboBox();

            //Check if its admin or not
            if (loggedUser == null || !loggedUser.IsAdmin)
            {
                btnEdit.Hide();
                btnRemove.Hide();
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;

                tbxTitle.ReadOnly = true;
                tbxAlternateTitle.ReadOnly = true;
                cbxMainGenre.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                chbxEndDate.Enabled = false;
                cbxStatus.Enabled = false;
                tbxSynopsis.ReadOnly = true;
                tbxDescription.ReadOnly = true;
                cbxType.Enabled = false;

                tbxStudio.ReadOnly = true;
                nudNrOfEpisode.ReadOnly = true;
                nudDuration.ReadOnly = true;
                cbxPrequel.Enabled = false;
                cbxSequel.Enabled = false;

                tbxAuthor.ReadOnly = true;
                nudVolumes.ReadOnly = true;
                nudChapters.ReadOnly = true;
            }

            //Display all info
            tbxTitle.Text = entertainment.Title;
            tbxAlternateTitle.Text = entertainment.AlternateTitle;
            cbxMainGenre.SelectedItem = entertainment.MainGenre;
            dtpStartDate.Value = entertainment.StartDate;
            if (entertainment.EndDate != null)
            {
                dtpEndDate.Value = (DateTime)entertainment.EndDate;
            }
            else
            {
                chbxEndDate.Checked = true;
            }
            cbxStatus.SelectedItem = entertainment.Status;
            tbxSynopsis.Text = entertainment.Synopsis;
            tbxDescription.Text = entertainment.Description;

            //check manga or anime
            if (entertainment is Anime)
            {
                cbxType.SelectedIndex = 0;//selected Anime
                tbxStudio.Text = ((Anime)entertainment).Studio;
                nudNrOfEpisode.Value = ((Anime)entertainment).NrOfEpisode;
                nudDuration.Value = ((Anime)entertainment).Duration;
                if (((Anime)entertainment).Prequel != null)
                {
                    cbxPrequel.SelectedItem = ((Anime)entertainment).Prequel.Title;
                }
                if (((Anime)entertainment).Sequel != null)
                {
                    cbxSequel.SelectedItem = ((Anime)entertainment).Sequel.Title;
                }
            }
            else if (entertainment is Manga)
            {
                cbxType.SelectedIndex = 1;//selected manga
                tbxAuthor.Text = ((Manga)entertainment).Auhor;
                nudVolumes.Value = ((Manga)entertainment).Volumes;
                nudChapters.Value = ((Manga)entertainment).Chapters;
            }
        }

        private void InitializeComboBox()
        {
            cbxStatus.Items.Add(string.Empty);
            cbxPrequel.Items.Add(string.Empty);
            cbxSequel.Items.Add(string.Empty);
            foreach (GenreType g in System.Enum.GetValues(typeof(GenreType)))
            {
                cbxMainGenre.Items.Add(g);
            }
            foreach (EntertainmentStatusType e in System.Enum.GetValues(typeof(EntertainmentStatusType)))
            {
                cbxStatus.Items.Add(e);
            }
            if (entertainments != null)
            {
                foreach (Entertainment e in entertainments.GetAllEntertainments)
                {
                    if (e is Anime)
                    {
                        cbxSequel.Items.Add(e.Title);
                        cbxPrequel.Items.Add(e.Title);
                    }
                }
            }

            cbxType.Items.Add("Anime");
            cbxType.Items.Add("Manga");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string title;
                string alternateTitle = tbxAlternateTitle.Text;
                GenreType genreType;
                DateTime startDate;

                //Check Required Fields
                if (!string.IsNullOrWhiteSpace(tbxTitle.Text) || !string.IsNullOrWhiteSpace(cbxMainGenre.SelectedItem.ToString()) || !string.IsNullOrWhiteSpace(dtpStartDate.Value.ToString()))
                {
                    title = tbxTitle.Text;
                    genreType = (GenreType)(cbxMainGenre.SelectedItem);
                    startDate = dtpStartDate.Value;
                }
                else
                {
                    throw new Exception("Title is missing");
                }

                DateTime? endDate;
                if (chbxEndDate.Checked)
                { endDate = null; }
                else
                { endDate = dtpEndDate.Value; }

                EntertainmentStatusType? status = null;

                if (cbxStatus.SelectedItem != null)
                {
                    status = (EntertainmentStatusType?)(cbxStatus.SelectedItem);
                }

                string synopsis = tbxSynopsis.Text;
                string description = tbxDescription.Text;

                //Anime added
                if (cbxType.SelectedIndex == 0)
                {
                    string studio;
                    int nrOfEpisode = Convert.ToInt32(nudNrOfEpisode.Value);
                    int duration = Convert.ToInt32(nudNrOfEpisode.Value);

                    if (!string.IsNullOrWhiteSpace(tbxStudio.Text))
                    {
                        studio = tbxStudio.Text;
                    }
                    else
                    {
                        throw new Exception("Studio is missing");
                    }

                    Anime prequel = null;
                    if (cbxPrequel.SelectedItem != null)
                    {
                        foreach (Entertainment en in entertainments.GetAllEntertainments)
                        {
                            if (en.Title == cbxPrequel.SelectedItem.ToString() && en is Anime)
                            {
                                prequel = (Anime)en;
                            }
                        }
                    }

                    Anime sequel = null;
                    if (cbxSequel.SelectedItem != null)
                    {
                        foreach (Entertainment en in entertainments.GetAllEntertainments)
                        {
                            if (en.Title == cbxPrequel.SelectedItem.ToString() && en is Anime)
                            {
                                sequel = (Anime)en;
                            }
                        }
                    }

                    if (entertainments.AddEntertainment(new Anime(title, genreType, startDate, studio, status, alternateTitle, endDate, synopsis, description, nrOfEpisode, duration, prequel, sequel)))
                    {
                        MessageBox.Show("Anime Added");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add");
                    }
                }
                //Manga added
                else if (cbxType.SelectedIndex == 1)
                {
                    string author = tbxAuthor.Text;
                    int volumes = Convert.ToInt32(nudVolumes.Value);
                    int chapters = Convert.ToInt32(nudChapters.Value);

                    if (!string.IsNullOrWhiteSpace(tbxAuthor.Text))
                    {
                        author = tbxAuthor.Text;
                    }
                    else
                    {
                        throw new Exception("Author is missing");
                    }

                    if (entertainments.AddEntertainment(new Manga(title, genreType, startDate, author, status, alternateTitle, endDate, synopsis, description, volumes, chapters)))
                    {
                        MessageBox.Show("Manga Added");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to add");
            }
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 0)//selected anime
            {
                lblStudio.Show();
                lblNrOfEpisode.Show();
                lblDuration.Show();
                lblPrequel.Show();
                lblSequel.Show();
                tbxStudio.Show();
                nudNrOfEpisode.Show();
                nudDuration.Show();
                cbxPrequel.Show();
                cbxSequel.Show();

                lblAuthor.Hide();
                lblVolumes.Hide();
                lblChapters.Hide();
                tbxAuthor.Hide();
                nudVolumes.Hide();
                nudChapters.Hide();
            }
            else//selected manga
            {
                lblStudio.Hide();
                lblNrOfEpisode.Hide();
                lblDuration.Hide();
                lblPrequel.Hide();
                lblSequel.Hide();
                tbxStudio.Hide();
                nudNrOfEpisode.Hide();
                nudDuration.Hide();
                cbxPrequel.Hide();
                cbxSequel.Hide();

                lblAuthor.Show();
                lblVolumes.Show();
                lblChapters.Show();
                tbxAuthor.Show();
                nudVolumes.Show();
                nudChapters.Show();
            }
        }

        private void chbxEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxEndDate.Checked)
            {
                dtpEndDate.Enabled = false;
            }
            else
                dtpEndDate.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                this.Hide();
                Form index = new index(users, entertainments);
                index.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                Form index = new index(users, entertainments, loggedUser);
                index.ShowDialog();
                this.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string title;
                string alternateTitle = tbxAlternateTitle.Text;
                GenreType genreType;
                DateTime startDate;

                //Check Required Fields
                if (!string.IsNullOrWhiteSpace(tbxTitle.Text) || !string.IsNullOrWhiteSpace(cbxMainGenre.SelectedItem.ToString()) || !string.IsNullOrWhiteSpace(dtpStartDate.Value.ToString()))
                {
                    title = tbxTitle.Text;
                    genreType = (GenreType)(cbxMainGenre.SelectedItem);
                    startDate = dtpStartDate.Value;
                }
                else
                {
                    throw new Exception("Title is missing");
                }

                DateTime? endDate;
                if (chbxEndDate.Checked)
                { endDate = null; }
                else
                { endDate = dtpEndDate.Value; }

                EntertainmentStatusType? status = null;

                if (cbxStatus.SelectedItem != null)
                {
                    status = (EntertainmentStatusType?)(cbxStatus.SelectedItem);
                }

                string synopsis = tbxSynopsis.Text;
                string description = tbxDescription.Text;

                if (entertainment is Anime)
                {
                    string studio;
                    int nrOfEpisode = Convert.ToInt32(nudNrOfEpisode.Value);
                    int duration = Convert.ToInt32(nudNrOfEpisode.Value);

                    if (!string.IsNullOrWhiteSpace(tbxStudio.Text))
                    {
                        studio = tbxStudio.Text;
                    }
                    else
                    {
                        throw new Exception("Studio is missing");
                    }

                    Anime prequel = null;
                    if (cbxPrequel.SelectedItem != null)
                    {
                        foreach (Entertainment en in entertainments.GetAllEntertainments)
                        {
                            if (en.Title == cbxPrequel.SelectedItem.ToString() && en is Anime)
                            {
                                prequel = (Anime)en;
                            }
                        }
                    }

                    Anime sequel = null;
                    if (cbxSequel.SelectedItem != null)
                    {
                        foreach (Entertainment en in entertainments.GetAllEntertainments)
                        {
                            if (en.Title == cbxPrequel.SelectedItem.ToString() && en is Anime)
                            {
                                sequel = (Anime)en;
                            }
                        }
                    }

                    entertainment.Title = title;
                    entertainment.AlternateTitle = alternateTitle;
                    entertainment.MainGenre = (GenreType)genreType;
                    entertainment.StartDate = startDate;
                    entertainment.EndDate = endDate;
                    entertainment.Status = (EntertainmentStatusType)status;
                    entertainment.Synopsis = synopsis;
                    entertainment.Description = description;
                    ((Anime)entertainment).Studio = studio;
                    ((Anime)entertainment).NrOfEpisode = nrOfEpisode;
                    ((Anime)entertainment).Duration = duration;
                    ((Anime)entertainment).Prequel = prequel;
                    ((Anime)entertainment).Sequel = sequel;
                }
                else
                {
                    string author = tbxAuthor.Text;
                    int volumes = Convert.ToInt32(nudVolumes.Value);
                    int chapters = Convert.ToInt32(nudChapters.Value);

                    if (!string.IsNullOrWhiteSpace(tbxAuthor.Text))
                    {
                        author = tbxAuthor.Text;
                    }
                    else
                    {
                        throw new Exception("Author is missing");
                    }

                    entertainment.Title = title;
                    entertainment.AlternateTitle = alternateTitle;
                    entertainment.MainGenre = (GenreType)genreType;
                    entertainment.StartDate = startDate;
                    entertainment.EndDate = endDate;
                    entertainment.Status = (EntertainmentStatusType)status;
                    entertainment.Synopsis = synopsis;
                    entertainment.Description = description;
                    ((Manga)entertainment).Auhor = author;
                    ((Manga)entertainment).Volumes = volumes;
                    ((Manga)entertainment).Chapters = chapters;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            entertainments.GetAllEntertainments.Remove(entertainment);
            this.Hide();
            Form index = new index(users, entertainments, loggedUser);
            index.ShowDialog();
            this.Close();
        }
    }
}
