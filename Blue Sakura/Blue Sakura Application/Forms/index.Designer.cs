
namespace Blue_Sakura_Application
{
    partial class index
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.btnAllList = new System.Windows.Forms.Button();
            this.btnMyList = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lsvEntertainment = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.btnAddNewEntertainment = new System.Windows.Forms.Button();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.lblLoggedUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAllList
            // 
            this.btnAllList.Location = new System.Drawing.Point(71, 45);
            this.btnAllList.Name = "btnAllList";
            this.btnAllList.Size = new System.Drawing.Size(110, 39);
            this.btnAllList.TabIndex = 0;
            this.btnAllList.Text = "All List";
            this.btnAllList.UseVisualStyleBackColor = true;
            this.btnAllList.Click += new System.EventHandler(this.btnAllList_Click);
            // 
            // btnMyList
            // 
            this.btnMyList.Location = new System.Drawing.Point(258, 45);
            this.btnMyList.Name = "btnMyList";
            this.btnMyList.Size = new System.Drawing.Size(110, 39);
            this.btnMyList.TabIndex = 1;
            this.btnMyList.Text = "My List";
            this.btnMyList.UseVisualStyleBackColor = true;
            this.btnMyList.Click += new System.EventHandler(this.btnMyList_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(657, 45);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 39);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(541, 45);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 39);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lsvEntertainment
            // 
            this.lsvEntertainment.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvEntertainment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lsvEntertainment.FullRowSelect = true;
            this.lsvEntertainment.HideSelection = false;
            this.lsvEntertainment.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lsvEntertainment.Location = new System.Drawing.Point(71, 164);
            this.lsvEntertainment.Name = "lsvEntertainment";
            this.lsvEntertainment.Size = new System.Drawing.Size(532, 261);
            this.lsvEntertainment.TabIndex = 4;
            this.lsvEntertainment.UseCompatibleStateImageBehavior = false;
            this.lsvEntertainment.View = System.Windows.Forms.View.Details;
            this.lsvEntertainment.DoubleClick += new System.EventHandler(this.lsvEntertainment_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 31;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 89;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alternate Title";
            this.columnHeader3.Width = 94;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Main Genre";
            this.columnHeader4.Width = 96;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Start Date";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "End Date";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Status";
            this.columnHeader7.Width = 78;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Synopsis";
            this.columnHeader8.Width = 91;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Description";
            this.columnHeader9.Width = 99;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Type";
            // 
            // cbxFilter
            // 
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Location = new System.Drawing.Point(71, 137);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(163, 21);
            this.cbxFilter.TabIndex = 5;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // btnAddNewEntertainment
            // 
            this.btnAddNewEntertainment.Location = new System.Drawing.Point(620, 396);
            this.btnAddNewEntertainment.Name = "btnAddNewEntertainment";
            this.btnAddNewEntertainment.Size = new System.Drawing.Size(75, 29);
            this.btnAddNewEntertainment.TabIndex = 6;
            this.btnAddNewEntertainment.Text = "Add New";
            this.btnAddNewEntertainment.UseVisualStyleBackColor = true;
            this.btnAddNewEntertainment.Click += new System.EventHandler(this.btnAddNewEntertainment_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(620, 361);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 29);
            this.btnAddToList.TabIndex = 7;
            this.btnAddToList.Text = "Add";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // lblLoggedUser
            // 
            this.lblLoggedUser.AutoSize = true;
            this.lblLoggedUser.Location = new System.Drawing.Point(654, 19);
            this.lblLoggedUser.Name = "lblLoggedUser";
            this.lblLoggedUser.Size = new System.Drawing.Size(10, 13);
            this.lblLoggedUser.TabIndex = 8;
            this.lblLoggedUser.Text = "-";
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLoggedUser);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.btnAddNewEntertainment);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.lsvEntertainment);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnMyList);
            this.Controls.Add(this.btnAllList);
            this.Name = "index";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAllList;
        private System.Windows.Forms.Button btnMyList;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListView lsvEntertainment;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Button btnAddNewEntertainment;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}